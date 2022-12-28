class Player:
    def __init__(self, name, sprint, dribble, passing, shooting):
        self.name = name
        self.__sprint = sprint
        self.__dribble = dribble
        self.__passing = passing
        self.__shooting = shooting

    @property
    def name(self):
        return self.__name

    @name.setter
    def name(self, value):
        self.__name = value

    def __str__(self):
        output = f'Player: {self.__name}'
        output += f'\nSprint: {self.__sprint}'
        output += f'\nDribble: {self.__dribble}'
        output += f'\nPassing: {self.__passing}'
        output += f'\nShooting: {self.__shooting}'
        return output
