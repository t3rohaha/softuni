from project.room import Room

class Hotel:

    def __init__(self, name: str):
        self.name = name
        self.rooms = []

    @property
    def guests(self):
        value = 0
        for r in self.rooms:
            value += r.guests
        return value

    @classmethod
    def from_stars(cls, stars_count: int):
        return cls(f'{stars_count} stars Hotel')

    def add_room(self, room: Room):
        self.rooms.append(room)

    def take_room(self, room_number: int, people: int):
        for r in self.rooms:
            if r.number == room_number:
                r.take_room(people)
                break

    def free_room(self, room_number: int):
        for r in self.rooms:
            if r.number == room_number:
                r.free_room()
                break

    def status(self):
        free_rooms = []
        taken_rooms = []
        for r in self.rooms:
            if r.is_taken:
                taken_rooms.append(r.number)
            else:
                free_rooms.append(r.number)

        output = f'Hotel {self.name} has {self.guests} total guests'
        output += f'\nFree rooms: {", ".join(map(str, free_rooms))}'
        output += f'\nTaken rooms: {", ".join(map(str, taken_rooms))}'

        return output

