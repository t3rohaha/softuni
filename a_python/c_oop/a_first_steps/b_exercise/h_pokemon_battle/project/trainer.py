from project.pokemon import Pokemon

class Trainer:
    def __init__(self, name):
        self.name = name
        self.pokemons = []

    def add_pokemon(self, pokemon):
        if any(pokemon.name == p.name for p in self.pokemons):
            return f'This pokemon is already caught'
        else:
            self.pokemons.append(pokemon)
            return f'Caught {pokemon.pokemon_details()}'

    def release_pokemon(self, pokemon_name):
        for p in self.pokemons:
            if p.name == pokemon_name:
                self.pokemons.remove(p)
                return f'You have released {pokemon_name}'
        return f'Pokemon is not caught'

    def trainer_data(self):
        output = f'Pokemon Trainer {self.name}'
        output += f'\nPokemon count {len(self.pokemons)}'
        for p in self.pokemons:
            output += f'\n- {p.pokemon_details()}'

        return output

