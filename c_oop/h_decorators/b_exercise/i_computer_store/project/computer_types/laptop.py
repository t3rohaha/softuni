from project.computer_types.computer import Computer

class Laptop(Computer):
    def __init__(self, manufacturer: str, model: str):
        super().__init__(manufacturer, model)

    def compatible_processors(self):
        return {'AMD Ryzen 9 5950X': 900,
                'Intel Core i9-11900H': 1050,
                'Apple M1 Pro': 1200}

    def compatible_rams(self):
        return {2: 100, 4: 200, 8: 300, 16: 400, 32: 500, 64: 600}

    def configure_computer(self, processor: str, ram: int):
        return super().configure_computer(processor, ram)

