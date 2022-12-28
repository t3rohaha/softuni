from project.formula_teams.formula_team import FormulaTeam

class RedBullTeam(FormulaTeam):
    EXPENSE_PER_RACE = 250_000

    def calculate_revenue_after_race(self, race_pos: int):
        sponsor_prizes = {1: 1_520_000, 2: 820_000, 8: 20_000, 10: 10_000}
        revenue = sponsor_prizes.get(race_pos, 0) - RedBullTeam.EXPENSE_PER_RACE

        self.budget += revenue

        return f'The revenue after the race is {revenue}$. '\
            + f'Current budget {self.budget}$'

