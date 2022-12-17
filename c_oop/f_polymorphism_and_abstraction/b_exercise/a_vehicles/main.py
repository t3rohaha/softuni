from abc import ABC, abstractmethod

class Vehicle(ABC):

    @abstractmethod
    def drive(self, distance):
        pass

    @abstractmethod
    def refuel(self, fuel):
        pass

class Car(Vehicle):

    CONSUMPTION_MULTIPLIER = 0.9

    def __init__(self, fuel_quantity, fuel_consumption):
        self.fuel_quantity = fuel_quantity
        self.fuel_consumption = fuel_consumption

    def drive(self, distance):
        fuel_needed = distance * (self.fuel_consumption + self.CONSUMPTION_MULTIPLIER)
        if fuel_needed <= self.fuel_quantity:
            self.fuel_quantity -= fuel_needed

    def refuel(self, fuel):
        self.fuel_quantity += fuel

class Truck(Vehicle):

    CONSUMPTION_MULTIPLIER = 1.6
    REFUEL_MULTIPLIER = 0.95

    def __init__(self, fuel_quantity, fuel_consumption):
        self.fuel_quantity = fuel_quantity
        self.fuel_consumption = fuel_consumption

    def drive(self, distance):
        fuel_needed = distance * (self.fuel_consumption + self.CONSUMPTION_MULTIPLIER)
        if fuel_needed <= self.fuel_quantity:
            self.fuel_quantity -= fuel_needed

    def refuel(self, fuel):
        self.fuel_quantity += fuel * self.REFUEL_MULTIPLIER

