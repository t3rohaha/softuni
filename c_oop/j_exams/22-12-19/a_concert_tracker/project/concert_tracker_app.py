from project.band_members.musician import Musician
from project.band_members.guitarist import Guitarist
from project.band_members.drummer import Drummer
from project.band_members.singer import Singer
from project.band import Band
from project.concert import Concert

class ConcertTrackerApp:
    VALID_MUSICIAN_TYPES = ['Guitarist', 'Drummer', 'Singer']

    def __init__(self):
        self.bands: list[Band] = []
        self.musicians: list[Musician] = []
        self.concerts: list[Concert] = []

    def create_musician(self, musician_type: str, name: str, age: int):
        if musician_type not in self.VALID_MUSICIAN_TYPES:
            raise ValueError('Invalid musician type!')
        if any(m.name == name for m in self.musicians):
            raise Exception(f'{name} is already a musician!')

        musician = None
        if musician_type == 'Guitarist':
            musician = Guitarist(name, age)
        elif musician_type == 'Drummer':
            musician = Drummer(name, age)
        elif musician_type == 'Singer':
            musician = Singer(name, age)
        self.musicians.append(musician)

        return f'{name} is now a {musician_type}.'

    def create_band(self, name: str):
        if any(b.name == name for b in self.bands):
            raise Exception(f'{name} band is already created!')
        band = Band(name)
        self.bands.append(band)
        return f'{name} was created.'

    def create_concert(self, genre: str, audience: int, ticket_price: float, expenses: float, place: str):
        for c in self.concerts:
            if c.place == place:
                raise Exception(f'{place} is already registered for {c.genre} concert!')
        concert = Concert(genre, audience, ticket_price, expenses, place)
        self.concerts.append(concert)
        return f'{genre} concert in {place} was added.'

    def add_musician_to_band(self, musician_name: str, band_name: str):
        musician = None
        for m in self.musicians:
            if m.name == musician_name:
                musician = m
                break
        if not musician:
            raise Exception(f'{musician_name} isn\'t a musician!')

        band = None
        for b in self.bands:
            if b.name == band_name:
                band = b
                break
        if not band:
            raise Exception(f'{band_name} isn\'t a band!')

        band.members.append(musician)
        self.musicians.remove(musician)
        return f'{musician_name} was added to {band_name}.'

    def remove_musician_from_band(self, musician_name: str, band_name: str):
        band = None
        for b in self.bands:
            if b.name == band_name:
                b = band
                break
        if not band:
            raise Exception(f'{band_name} isn\'t a band!')

        musician = None
        for m in band.members:
            if m.name == musician_name:
                musician = m
                break
        if not musician:
            raise Exception(f'{musician_name} isn\'t a member of {band_name}!')

        band.members.remove(musician)
        self.musicians.append(musician)
        return f'{musician_name} was removed from {band_name}.'

    def check_concert_genre_skills_needed(self, band_name: str, drummers, singers, guitarists,
                                          drummer_skills: str, singer_skills: list, guitarist_skills: str):
        for d in drummers:
            if drummer_skills not in d.skills:
                raise Exception(f'The {band_name} band is not ready to'\
                                ' play at the concert!')
        for s in singers:
            for ss in singer_skills:
                if ss not in s.skills:
                    raise Exception(f'The {band_name} band is not ready to'\
                                    ' play at the concert!')
        for g in guitarists:
            if guitarist_skills not in g.skills:
                raise Exception(f'The {band_name} band is not ready to'\
                                ' play at the concert!')

    # concert place and band name will always be valid
    def start_concert(self, concert_place: str, band_name: str):
        concert = None
        for c in self.concerts:
            if c.place == concert_place:
                concert = c
                break
        band = None
        for b in self.bands:
            if b.name == band_name:
                band = b
                break

        guitarists = band.get_guitarists()
        drummers = band.get_drummers()
        singers = band.get_singers()

        if not guitarists or not drummers or not singers:
            raise Exception(f'{band_name} can\'t start the concert because'\
                            f' it doesn\'t have enough members!')

        if concert.genre == 'Rock':
            self.check_concert_genre_skills_needed(band_name, drummers, singers, guitarists,
                                                   'play the drums with drumsticks',
                                                   ['sing high pitch notes'],
                                                   'play rock')
        elif concert.genre == 'Metal':
            self.check_concert_genre_skills_needed(band_name, drummers, singers, guitarists,
                                                   'play the drums with drumsticks',
                                                   ['sing low pitch notes'],
                                                   'play metal')
        elif concert.genre == 'Jazz':
            self.check_concert_genre_skills_needed(band_name, drummers, singers, guitarists,
                                                   'play the drums with drum brushes',
                                                   ['sing high pitch notes', 'sing low pitch notes'],
                                                   'play jazz')

        profit = (concert.audience * concert.ticket_price) - concert.expenses
        self.concerts.remove(concert)
        return f'{band_name} gained {profit:.2f}$ from the {concert.genre} concert in {concert_place}.'


