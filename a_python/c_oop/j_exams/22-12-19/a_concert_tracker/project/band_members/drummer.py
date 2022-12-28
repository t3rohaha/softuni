from project.band_members.musician import Musician

class Drummer(Musician):

    def get_available_skill_types(self):
        return ['play the drums with drumsticks',
                'play the drums with drum brushes',
                'read sheet music']

    def learn_new_skill(self, new_skill: str):
        return super().learn_new_skill(new_skill)

