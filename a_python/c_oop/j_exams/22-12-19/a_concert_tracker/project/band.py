from project.band_members.musician import Musician


class Band:

    def __init__(self, name: str):
        self.name = name
        self.members: list[Musician] = []

    @property
    def name(self):
        return self.__name
    @name.setter
    def name(self, value):
        if not value.strip():
            raise ValueError('Band name should contain at least one character!')
        self.__name = value

    def get_guitarists(self):
        guitarists = []
        for m in self.members:
            if type(m).__name__ == 'Guitarist':
                guitarists.append(m)
        return guitarists

    def get_drummers(self):
        drummers = []
        for m in self.members:
            if type(m).__name__ == 'Drummer':
                drummers.append(m)
        return drummers

    def get_singers(self):
        singers = []
        for m in self.members:
            if type(m).__name__ == 'Singer':
                singers.append(m)
        return singers

    def __str__(self):
        return f'{self.name} with {len(self.members)} members.'

