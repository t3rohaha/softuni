from unittest import TestCase, main
from project.truck_driver import TruckDriver

class TruckDriverTests(TestCase):

    def test_initialization(self):
        truck_driver = TruckDriver('A', 1)
        self.assertEqual(truck_driver.name, 'A')
        self.assertEqual(truck_driver.money_per_mile, 1)
        self.assertEqual(truck_driver.available_cargos, {})
        self.assertEqual(truck_driver.earned_money, 0)
        self.assertEqual(truck_driver.miles, 0)

    def test_earned_money_setter_below_zero(self):
        truck_driver = TruckDriver('A', 1)
        with self.assertRaises(ValueError) as ex:
            truck_driver.earned_money -= 1
        self.assertEqual(str(ex.exception), 'A went bankrupt.')

    def test_earned_money_setter_with_valid_input(self):
        truck_driver = TruckDriver('A', 1)
        truck_driver.earned_money += 1
        self.assertEqual(truck_driver.earned_money, 1)

    def test_add_cargo_offer_with_existing_location(self):
        truck_driver = TruckDriver('A', 1)
        truck_driver.available_cargos['B'] = 1
        with self.assertRaises(Exception) as ex:
            truck_driver.add_cargo_offer('B', 1)
        self.assertEqual(str(ex.exception), 'Cargo offer is already added.')

    def test_add_cargo_offer_with_valid_input(self):
        truck_driver = TruckDriver('A', 1)
        message = truck_driver.add_cargo_offer('B', 1)
        self.assertEqual(truck_driver.available_cargos, {'B': 1})
        self.assertEqual(message, 'Cargo for 1 to B was added as an offer.')

    def test_drive_best_cargo_offer_without_available_cargos(self):
        truck_driver = TruckDriver('A', 1)
        message = truck_driver.drive_best_cargo_offer()
        self.assertEqual(message, 'There are no offers available.')

    def test_drive_best_cargo_offer_with_valid_input(self):
        truck_driver = TruckDriver('A', 1)
        truck_driver.available_cargos['B'] = 1
        truck_driver.available_cargos['C'] = 2
        message = truck_driver.drive_best_cargo_offer()
        self.assertEqual(truck_driver.earned_money, 2)
        self.assertEqual(truck_driver.miles, 2)
        self.assertEqual(message, 'A is driving 2 to C.')

    def test_drive_best_cargo_offer_with_10_000_miles(self):
        truck_driver = TruckDriver('A', 2)
        truck_driver.available_cargos['B'] = 10_000
        message = truck_driver.drive_best_cargo_offer()
        self.assertEqual(truck_driver.earned_money, 20_000-(800+450+3000+7500))
        self.assertEqual(truck_driver.miles, 10_000)

    def test_check_for_activities_below_250(self):
        truck_driver = TruckDriver('A', 1)
        truck_driver.check_for_activities(1)
        self.assertEqual(truck_driver.earned_money, 0)

    def test_check_for_activities_over_10_000(self):
        truck_driver = TruckDriver('A', 1)
        truck_driver.earned_money = 800 + 450 + 3000 + 7500
        truck_driver.check_for_activities(10_000)
        self.assertEqual(truck_driver.earned_money, 0)

    def test_eat_below_250(self):
        truck_driver = TruckDriver('A', 1)
        truck_driver.eat(1)
        self.assertEqual(truck_driver.earned_money, 0)

    def test_eat_over_250(self):
        truck_driver = TruckDriver('A', 1)
        truck_driver.earned_money = 20
        truck_driver.eat(250)
        self.assertEqual(truck_driver.earned_money, 0)

    def test_sleep_below_1000(self):
        truck_driver = TruckDriver('A', 1)
        truck_driver.sleep(1)
        self.assertEqual(truck_driver.earned_money, 0)

    def test_sleep_over_1000(self):
        truck_driver = TruckDriver('A', 1)
        truck_driver.earned_money = 45
        truck_driver.sleep(1000)
        self.assertEqual(truck_driver.earned_money, 0)

    def test_pump_gas_below_1500(self):
        truck_driver = TruckDriver('A', 1)
        truck_driver.pump_gas(1)
        self.assertEqual(truck_driver.earned_money, 0)

    def test_pump_gas_over_1500(self):
        truck_driver = TruckDriver('A', 1)
        truck_driver.earned_money = 500
        truck_driver.pump_gas(1500)
        self.assertEqual(truck_driver.earned_money, 0)

    def test_repair_truck_below_10_000(self):
        truck_driver = TruckDriver('A', 1)
        truck_driver.repair_truck(1)
        self.assertEqual(truck_driver.earned_money, 0)

    def test_repair_truck_over_10_000(self):
        truck_driver = TruckDriver('A', 1)
        truck_driver.earned_money = 7500
        truck_driver.repair_truck(10_000)
        self.assertEqual(truck_driver.earned_money, 0)

    def test_repr(self):
        truck_driver = TruckDriver('A', 1)
        message = repr(truck_driver)
        self.assertEqual(message, 'A has 0 miles behind his back.')



if __name__ == '__main__':
    main()
