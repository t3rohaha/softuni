from project.mammal import Mammal
from unittest import TestCase, main


class MammalTests(TestCase):

    def test_initialization(self):
        mammal = Mammal('A', 'B', 'C')
        self.assertEqual(mammal.name, 'A')
        self.assertEqual(mammal.type, 'B')
        self.assertEqual(mammal.sound, 'C')
        self.assertEqual(mammal._Mammal__kingdom, 'animals')

    def test_make_sound(self):
        mammal = Mammal('A', 'B', 'C')
        result = mammal.make_sound()
        self.assertEqual(result, 'A makes C')

    def test_get_kingdom(self):
        mammal = Mammal('A', 'B', 'C')
        result = mammal.get_kingdom()
        self.assertEqual(result, 'animals')

    def test_info(self):
        mammal = Mammal('A', 'B', 'C')
        result = mammal.info()
        self.assertEqual(result, 'A is of type B')


if __name__ == '__main__':
    main()

