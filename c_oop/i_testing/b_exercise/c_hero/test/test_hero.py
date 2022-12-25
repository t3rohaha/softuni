from unittest import TestCase, main
from project.hero import Hero


class HeroTests(TestCase):

    def test_initialization(self):
        hero = Hero('A', 1, 100, 5)
        self.assertEqual(hero.username, 'A')
        self.assertEqual(hero.level, 1)
        self.assertEqual(hero.health, 100)
        self.assertEqual(hero.damage, 5)

    def test_battle_enemy_with_same_username(self):
        hero = Hero('A', 1, 100, 5)
        enemy_hero = Hero('A', 2, 100, 5)
        with self.assertRaises(Exception) as ex:
            hero.battle(enemy_hero)
        self.assertEqual(str(ex.exception), 'You cannot fight yourself')

    def test_battle_low_health(self):
        hero = Hero('A', 1, 0, 5)
        enemy_hero = Hero('B', 1, 100, 5)
        with self.assertRaises(Exception) as ex:
            hero.battle(enemy_hero)
        self.assertEqual(str(ex.exception), 'Your health is lower than or ' \
                         'equal to 0. You need to rest')

    def test_battle_low_enemy_health(self):
        hero = Hero('A', 1, 100, 5)
        enemy_hero = Hero('B', 1, 0, 5)
        with self.assertRaises(Exception) as ex:
            hero.battle(enemy_hero)
        self.assertEqual(str(ex.exception), 'You cannot fight B. He needs to rest')

    def test_battle_draw(self):
        hero = Hero('A', 1, 5, 5)
        enemy_hero = Hero('B', 1, 5, 5)
        result = hero.battle(enemy_hero)
        self.assertEqual(result, 'Draw')

    def test_battle_hero_win(self):
        hero = Hero('A', 1, 6, 5)
        enemy_hero = Hero('B', 1, 5, 5)
        result = hero.battle(enemy_hero)
        self.assertEqual(hero.level, 2)
        self.assertEqual(hero.health, 6)
        self.assertEqual(hero.damage, 10)
        self.assertEqual(result, 'You win')

    def test_battle_hero_lose(self):
        hero = Hero('A', 1, 5, 5)
        enemy_hero = Hero('B', 1, 6, 5)
        result = hero.battle(enemy_hero)
        self.assertEqual(enemy_hero.level, 2)
        self.assertEqual(enemy_hero.health, 6)
        self.assertEqual(enemy_hero.damage, 10)
        self.assertEqual(result, 'You lose')

    def test_str(self):
        hero = Hero('A', 1, 5, 5)
        self.assertEqual(str(hero), 'Hero A: 1 lvl\nHealth: 5\nDamage: 5\n')


if __name__ == '__main__':
    main()

