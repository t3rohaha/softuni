from project.vehicle import Vehicle
from unittest import TestCase, main


class VehicleTest(TestCase):

    def test_initialization(self):
        vehicle = Vehicle(200, 300)
        self.assertEqual(vehicle.fuel, 200)
        self.assertEqual(vehicle.capacity, 200)
        self.assertEqual(vehicle.horse_power, 300)
        self.assertEqual(vehicle.fuel_consumption, Vehicle.DEFAULT_FUEL_CONSUMPTION)

    def test_drive_valid_input(self):
        vehicle = Vehicle(200, 300)
        vehicle.drive(100)
        self.assertEqual(vehicle.fuel, 75)

    def test_drive_too_much_kilometers(self):
        vehicle = Vehicle(100, 300)
        with self.assertRaises(Exception) as ex:
            vehicle.drive(100)
        self.assertEqual(str(ex.exception), 'Not enough fuel')

    def test_refuel_valid_input(self):
        vehicle = Vehicle(200, 300)
        vehicle.fuel = 100
        vehicle.refuel(100)
        self.assertEqual(vehicle.fuel, 200)

    def test_refuel_too_much_fuel(self):
        vehicle = Vehicle(200, 300)
        with self.assertRaises(Exception) as ex:
            vehicle.refuel(1)
        self.assertEqual(str(ex.exception), 'Too much fuel')

    def test_str(self):
        vehicle = Vehicle(200, 300)
        self.assertEqual(str(vehicle), 'The vehicle has 300 horse power ' \
                         'with 200 fuel left and 1.25 fuel consumption')


if __name__ == '__main__':
    main()
