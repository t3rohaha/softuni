import unittest
from cat import Cat # remove before submission


class CatTests(unittest.TestCase):

    def test_cat_eat_size(self):
        cat = Cat('Tom')
        cat.eat()
        result = cat.size
        self.assertEqual(result, 1)

    def test_cat_eat_fed(self):
        cat = Cat('Tom')
        cat.eat()
        self.assertTrue(cat.fed)

    def test_cat_eat_already_fed(self):
        cat = Cat('Tom')
        cat.eat()
        with self.assertRaises(Exception) as ex:
            cat.eat()
        self.assertEqual(str(ex.exception), 'Already fed.')

    def test_cat_sleep_not_fed(self):
        cat = Cat('Tom')
        with self.assertRaises(Exception) as ex:
            cat.sleep()
        self.assertEqual(str(ex.exception), 'Cannot sleep while hungry')

    def test_cat_sleep_sleepy(self):
        cat = Cat('Tom')
        cat.eat()
        cat.sleep()
        self.assertFalse(cat.sleepy)


if __name__ == '__main__':
    unittest.main()

