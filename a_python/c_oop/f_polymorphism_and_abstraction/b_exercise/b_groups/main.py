class Person:

    def __init__(self, name: str, surname: str):
        self.name = name
        self.surname = surname

    def __add__(self, other):
        return Person(self.name, other.surname)

    def __repr__(self):
        return f'{self.name} {self.surname}'

class Group:

    def __init__(self, name: str, people: list):
        self.name = name
        self.people = people
        self.__index = -1

    def __len__(self):
        return len(self.people)

    def __add__(self, other):
        name = f'{self.name} {other.name}'
        people = self.people + other.people
        return Group(name, people)

    def __getitem__(self, index):
        return f'Person {index}: {str(self.people[index])}'

    def __iter__(self):
        return self

    def __next__(self):
        if self.__index == len(self.people) - 1:
            raise StopIteration
        self.__index += 1
        return f'Person {self.__index}: {self.people[self.__index]}'


    def __repr__(self):
        return f'Group {self.name} with members {", ".join([str(p) for p in self.people])}'

