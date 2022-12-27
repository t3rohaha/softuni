from unittest import TestCase, main
from project.toy_store import ToyStore

class ToyStoreTests(TestCase):


    def test_initialization(self):
        ts = ToyStore()
        self.assertEqual(ts.toy_shelf, {'A': None,
                                   'B': None,
                                   'C': None,
                                   'D': None,
                                   'E': None,
                                   'F': None,
                                   'G': None})


    def test_add_toy_invalid_shelf(self):
        ts = ToyStore()
        with self.assertRaises(Exception) as ex:
            ts.add_toy('Z', 'a')
        self.assertEqual(str(ex.exception), 'Shelf doesn\'t exist!')


    def test_add_toy_toy_already_in_shelf(self):
        ts = ToyStore()
        ts.toy_shelf['A'] = 'a'
        with self.assertRaises(Exception) as ex:
            ts.add_toy('A', 'a')
        self.assertEqual(str(ex.exception), 'Toy is already in shelf!')


    def test_add_toy_shelf_already_taken(self):
        ts = ToyStore()
        ts.toy_shelf['A'] = 'a'
        with self.assertRaises(Exception) as ex:
            ts.add_toy('A', 'b')
        self.assertEqual(str(ex.exception), 'Shelf is already taken!')


    def test_add_toy_valid_input(self):
        ts = ToyStore()
        message = ts.add_toy('A', 'a')
        self.assertEqual(message, 'Toy:a placed successfully!')
        self.assertEqual(ts.toy_shelf['A'], 'a')


    def test_remove_toy_unexisting_shelf(self):
        ts = ToyStore()
        with self.assertRaises(Exception) as ex:
            ts.remove_toy('Z', 'a')
        self.assertEqual(str(ex.exception), 'Shelf doesn\'t exist!')


    def test_remove_toy_toy_not_in_shelf(self):
        ts = ToyStore()
        ts.toy_shelf['A'] = 'a'
        with self.assertRaises(Exception) as ex:
            ts.remove_toy('A', 'b')
        self.assertEqual(str(ex.exception), 'Toy in that shelf doesn\'t exists!')


    def test_remove_toy_valid_input(self):
        ts = ToyStore()
        ts.toy_shelf['A'] = 'a'
        message = ts.remove_toy('A', 'a')
        self.assertEqual(message, 'Remove toy:a successfully!')
        self.assertEqual(ts.toy_shelf['A'], None)



if __name__ == '__main__':
    main()
