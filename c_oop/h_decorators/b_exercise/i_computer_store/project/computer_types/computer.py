from abc import ABC, abstractmethod

class Computer(ABC):
    def __init__(self, manufacturer: str, model: str):
        self.manufacturer = manufacturer
        self.model = model
        self.processor = None
        self.ram = None
        self.price = 0

    @property
    def manufacturer(self):
        return self.__manufacturer

    @manufacturer.setter
    def manufacturer(self, value: str):
        if isinstance(value, str) and value and not value.isspace():
            self.__manufacturer = value
        else:
            raise ValueError('Manufacturer name cannot be empty.')

    @property
    def model(self):
        return self.__model

    @model.setter
    def model(self, value: str):
        if isinstance(value, str) and value and not value.isspace():
            self.__model = value
        else:
            raise ValueError('Model name cannot be empty.')

    @abstractmethod
    def compatible_processors(self):
        pass

    @abstractmethod
    def compatible_rams(self):
        pass

    def configure_computer(self, processor: str, ram: int):
        computer_type = 'desktop computer' if self.__class__.__name__ == 'DesktopComputer' else 'laptop'
        if processor in self.compatible_processors():
            if ram in self.compatible_rams():
                self.processor = processor
                self.ram = ram
                self.price = self.compatible_processors()[processor] + self.compatible_rams()[ram]
                return f'Created {self.manufacturer} {self.model}'\
                    f' with {self.processor} and {self.ram}GB RAM for {self.price}$.'

            raise ValueError(f'{ram}GB RAM is not compatible with'\
                             f' {computer_type} {self.manufacturer} {self.model}!')

        raise ValueError(f'{processor} is not compatible with'\
                         f' {computer_type} {self.manufacturer} {self.model}!')

    def __repr__(self):
        return f'{self.manufacturer} {self.model} with {self.processor} and {self.ram}GB RAM'

