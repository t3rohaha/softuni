import unittest
from extended_list import IntegerList

class IntegerListTests(unittest.TestCase):

    def test_initialize_valid_input(self):
        intList = IntegerList(1, 2, 3)
        result = intList._IntegerList__data
        self.assertEqual(result, [1, 2, 3])

    def test_initialize_invalid_input(self):
        intList = IntegerList('str', [1, 2], True)
        result = intList._IntegerList__data
        self.assertEqual(result, [])

    def test_initialize_with_no_arguments(self):
        intList = IntegerList()
        result = intList._IntegerList__data
        self.assertEqual(result, [])

    def test_add_valid_input(self):
        intList = IntegerList(1, 2, 3)
        result = intList.add(10)
        self.assertEqual(result, [1, 2, 3, 10])

    def test_add_invalid_input(self):
        intList = IntegerList(1, 2, 3)
        with self.assertRaises(ValueError) as ex:
            result = intList.add('str')
        self.assertEqual(str(ex.exception), 'Element is not Integer')

    def test_remove_index_valid_input(self):
        intList = IntegerList(1, 2, 3)
        result = intList.remove_index(0)
        self.assertEqual(result, 1)
        self.assertEqual(intList.get_data(), [2, 3])

    def test_remove_index_invalid_input(self):
        intList = IntegerList(1, 2, 3)
        with self.assertRaises(IndexError) as ex:
            intList.remove_index(3)
        self.assertEqual(str(ex.exception), 'Index is out of range')

    def test_get_valid_input(self):
        intList = IntegerList(1, 2, 3)
        result = intList.get(0)
        self.assertEqual(result, 1)

    def test_get_invalid_input(self):
        intList = IntegerList(1, 2, 3)
        with self.assertRaises(IndexError) as ex:
            result = intList.get(3)
        self.assertEqual(str(ex.exception), 'Index is out of range')

    def test_insert_valid_input(self):
        intList = IntegerList(1, 2, 3)
        intList.insert(1, 10)
        result = intList.get_data()
        self.assertEqual(result, [1, 10, 2, 3])

    def test_insert_out_of_range(self):
        intList = IntegerList(1, 2, 3)
        with self.assertRaises(IndexError) as ex:
            intList.insert(3, 10)
        self.assertEqual(str(ex.exception), 'Index is out of range')

    def test_insert_element_not_integer(self):
        intList = IntegerList(1, 2, 3)
        with self.assertRaises(ValueError) as ex:
            intList.insert(1, 'str')
        self.assertEqual(str(ex.exception), 'Element is not Integer')

    def test_get_biggest(self):
        intList = IntegerList(1, 2, 3)
        result = intList.get_biggest()
        self.assertEqual(result, 3)

    def test_get_index(self):
        intList = IntegerList(1, 2, 3)
        result = intList.get_index(1)
        self.assertEqual(result, 0)


if __name__ == '__main__':
    unittest.main()

