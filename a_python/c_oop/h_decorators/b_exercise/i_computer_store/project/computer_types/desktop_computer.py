from project.computer_types.computer import Computer

class DesktopComputer(Computer):
    def __init__(self, manufacturer: str, model: str):
        super().__init__(manufacturer, model)

    def compatible_processors(self):
        return {'AMD Ryzen 7 5700G': 500,
                'Intel Core i5-12600K': 600,
                'Apple M1 Max': 1800}

    def compatible_rams(self):
        return {2: 100, 4: 200, 8: 300, 16: 400, 32: 500, 64: 600, 128: 700}

    def configure_computer(self, processor: str, ram: int):
        return super().configure_computer(processor, ram)

