import unittest
from car_manager import Car


class CarTest(unittest.TestCase):

    def test_initialization(self):
        car = Car('A', 'B', 10, 100)
        self.assertEqual(car._Car__make, 'A')
        self.assertEqual(car._Car__model, 'B')
        self.assertEqual(car._Car__fuel_consumption, 10)
        self.assertEqual(car._Car__fuel_capacity, 100)
        self.assertEqual(car._Car__fuel_amount, 0)

    def test_make_setter_valid_input(self):
        car = Car('A', 'B', 10, 100)
        car.make = 'X'
        self.assertEqual(car.make, 'X')

    def test_make_setter_null(self):
        car = Car('A', 'B', 10, 100)
        with self.assertRaises(Exception) as ex:
            car.make = None
        self.assertEqual(str(ex.exception), 'Make cannot be null or empty!')

    def test_make_setter_invalid_input(self):
        car = Car('A', 'B', 10, 100)
        with self.assertRaises(Exception) as ex:
            car.make = ''
        self.assertEqual(str(ex.exception), 'Make cannot be null or empty!')

    def test_model_setter_valid_input(self):
        car = Car('A', 'B', 10, 100)
        car.model = 'X'
        self.assertEqual(car.model, 'X')

    def test_model_setter_invalid_input(self):
        car = Car('A', 'B', 10, 100)
        with self.assertRaises(Exception) as ex:
            car.model = ''
        self.assertEqual(str(ex.exception), 'Model cannot be null or empty!')

    def test_fuel_consumption_setter_valid_input(self):
        car = Car('A', 'B', 10, 100)
        car.fuel_consumption = 20
        self.assertEqual(car.fuel_consumption, 20)

    def test_fuel_consumption_setter_invalid_input(self):
        car = Car('A', 'B', 10, 100)
        with self.assertRaises(Exception) as ex:
            car.fuel_consumption = -1
        self.assertEqual(str(ex.exception), 'Fuel consumption cannot be zero or negative!')

    def test_fuel_capacity_setter_valid_input(self):
        car = Car('A', 'B', 10, 100)
        car.fuel_capacity = 200
        self.assertEqual(car.fuel_capacity, 200)

    def test_fuel_capacity_setter_invalid_input(self):
        car = Car('A', 'B', 10, 100)
        with self.assertRaises(Exception) as ex:
            car.fuel_capacity = -1
        self.assertEqual(str(ex.exception), 'Fuel capacity cannot be zero or negative!')

    def test_fuel_amount_setter_valid_input(self):
        car = Car('A', 'B', 10, 100)
        car.fuel_amount = 50
        self.assertEqual(car.fuel_amount, 50)

    def test_make_setter_invalid_input(self):
        car = Car('A', 'B', 10, 100)
        with self.assertRaises(Exception) as ex:
            car.fuel_amount = -1
        self.assertEqual(str(ex.exception), 'Fuel amount cannot be negative!')

    def test_refuel_valid_input(self):
        car = Car('A', 'B', 10, 100)
        car.refuel(100)
        self.assertEqual(car.fuel_amount, 100)

    def test_refuel_with_too_much_fuel(self):
        car = Car('A', 'B', 10, 100)
        car.refuel(200)
        self.assertEqual(car.fuel_amount, 100)

    def test_refuel_with_invalid_input(self):
        car = Car('A', 'B', 10, 100)
        with self.assertRaises(Exception) as ex:
            car.refuel(0)
        self.assertEqual(str(ex.exception), 'Fuel amount cannot be zero or negative!')

    def test_drive_valid_input(self):
        car = Car('A', 'B', 10, 100)
        car.refuel(100)
        car.drive(100)
        self.assertEqual(car.fuel_amount, 90)

    def test_drive_too_much_distance(self):
        car = Car('A', 'B', 10, 100)
        car.refuel(100)
        with self.assertRaises(Exception) as ex:
            car.drive(1100)
        self.assertEqual(str(ex.exception), 'You don\'t have enough fuel to drive!')


if __name__ == '__main__':
    unittest.main()

