class Player:

    def __init__(self, name: str, hp: int, mp: int):
        self.name = name
        self.hp = hp
        self.mp = mp
        self.skills = {}
        self.guild = 'Unaffiliated'

    def add_skill(self, skill_name, mana_cost):
        if skill_name not in self.skills:
            self.skills[skill_name] = mana_cost
            return f'Skill {skill_name} added to the collection of the player {self.name}'
        else:
            return 'Skill already added'

    def player_info(self):
        output = f'Name: {self.name}'
        output += f'\nGuild: {self.guild}'
        output += f'\nHP: {self.hp}'
        output += f'\nMP: {self.mp}'
        for k, v in self.skills.items():
            output += f'\n==={k} - {v}'
        return output
