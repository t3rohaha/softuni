from project.formula_teams.formula_team import FormulaTeam

class MercedesTeam(FormulaTeam):
    EXPENSE_PER_RACE = 200_000

    def calculate_revenue_after_race(self, race_pos: int):
        sponsor_prizes = {1: 1_100_000, 3: 600_000, 5: 100_000, 7: 50_000}
        revenue = sponsor_prizes.get(race_pos, 0) - MercedesTeam.EXPENSE_PER_RACE

        self.budget += revenue

        return f'The revenue after the race is {revenue}$. '\
            + f'Current budget {self.budget}$'

