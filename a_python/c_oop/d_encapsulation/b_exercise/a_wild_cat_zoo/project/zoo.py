from project.animal import Animal
from project.lion import Lion
from project.tiger import Tiger
from project.cheetah import Cheetah
from project.worker import Worker
from project.keeper import Keeper
from project.caretaker import Caretaker
from project.vet import Vet
# 01 Zoo (100/100)
class Zoo:
    def __init__(self, name, budget, animal_capacity, workers_capacity):
        self.name = name
        self.__budget = budget
        self.__animal_capacity = animal_capacity
        self.__workers_capacity = workers_capacity
        self.animals = []
        self.workers = []

    def add_animal(self, animal, price):
        if self.__budget >= price:
            if len(self.animals) < self.__animal_capacity:
                self.animals.append(animal)
                self.__budget -= price
                return f'{animal.name} the {type(animal).__name__} added to the zoo'
            else:
                return 'Not enough space for animal'
        else:
            return 'Not enough budget'

    def hire_worker(self, worker):
        if len(self.workers) < self.__workers_capacity:
            self.workers.append(worker)
            return f'{worker.name} the {type(worker).__name__} hired successfully'
        else:
            return 'Not enough space for worker'

    def fire_worker(self, worker_name):
        for w in self.workers:
            if worker_name == w.name:
                self.workers.remove(w)
                return f'{worker_name} fired successfully'
        return f'There is no {worker_name} in the zoo'

    def pay_workers(self):
        total_salaries = 0
        for w in self.workers:
            total_salaries += w.salary

        if total_salaries <= self.__budget:
            self.__budget -= total_salaries
            return f'You payed your workers. They are happy. Budget left: {self.__budget}'
        else:
            return 'You have no budget to pay your workers. They are unhappy'

    def tend_animals(self):
        total_money_for_care = 0
        for a in self.animals:
            total_money_for_care += a.money_for_care

        if total_money_for_care <= self.__budget:
            self.__budget -= total_money_for_care
            return f'You tended all the animals. They are happy. Budget left: {self.__budget}'
        else:
            return 'You have no budget to tend the animals. They are unhappy.'

    def profit(self, amount):
        self.__budget += amount

    def animals_status(self):
        output = f'You have {len(self.animals)} animals'
        lions_count = 0
        lions_output = ''
        tigers_count = 0
        tigers_output = ''
        cheetahs_count = 0
        cheetahs_output = ''

        for a in self.animals:
            if isinstance(a, Lion):
                lions_count += 1
                lions_output += f'\n{a.__repr__()}'
            elif isinstance(a, Tiger):
                tigers_count += 1
                tigers_output += f'\n{a.__repr__()}'
            else:
                cheetahs_count += 1
                cheetahs_output += f'\n{a.__repr__()}'

        output += f'\n----- {lions_count} Lions:'
        output += lions_output
        output += f'\n----- {tigers_count} Tigers:'
        output += tigers_output
        output += f'\n----- {cheetahs_count} Cheetahs:'
        output += cheetahs_output

        return output

    def workers_status(self):
        output = f'You have {len(self.workers)} workers'
        keepers_count = 0
        keepers_output = ''
        caretakers_count = 0
        caretakers_output = ''
        vets_count = 0
        vets_output = ''

        for w in self.workers:
            if isinstance(w, Keeper):
                keepers_count += 1
                keepers_output += f'\n{w.__repr__()}'
            elif isinstance(w, Caretaker):
                caretakers_count += 1
                caretakers_output += f'\n{w.__repr__()}'
            else:
                vets_count += 1
                vets_output += f'\n{w.__repr__()}'

        output += f'\n----- {keepers_count} Keepers:'
        output += keepers_output
        output += f'\n----- {caretakers_count} Caretakers:'
        output += caretakers_output
        output += f'\n----- {vets_count} Vets:'
        output += vets_output

        return output
