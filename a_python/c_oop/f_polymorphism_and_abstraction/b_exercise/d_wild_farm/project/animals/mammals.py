from abc import ABC
from project.food import Food, Vegetable, Fruit, Meat
from project.animals.animal import Mammal

class Mouse(Mammal):

    def make_sound(self):
        return 'Squeak'

    def feed(self, food: Food):
        if not isinstance(food, (Vegetable, Fruit)):
            return f'{self.__class__.__name__} does not eat {food.__class__.__name__}!'
        self.food_eaten += food.quantity
        self.weight += food.quantity * 0.1

class Dog(Mammal):

    def make_sound(self):
        return 'Woof!'

    def feed(self, food: Food):
        if not isinstance(food, Meat):
            return f'{self.__class__.__name__} does not eat {food.__class__.__name__}!'
        self.food_eaten += food.quantity
        self.weight += food.quantity * 0.4

class Cat(Mammal):

    def make_sound(self):
        return 'Meow'

    def feed(self, food: Food):
        if not isinstance(food, (Vegetable, Meat)):
            return f'{self.__class__.__name__} does not eat {food.__class__.__name__}!'
        self.food_eaten += food.quantity
        self.weight += food.quantity * 0.3

class Tiger(Mammal):

    def make_sound(self):
        return 'ROAR!!!'

    def feed(self, food: Food):
        if not isinstance(food, Meat):
            return f'{self.__class__.__name__} does not eat {food.__class__.__name__}!'
        self.food_eaten += food.quantity
        self.weight += food.quantity

