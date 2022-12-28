from project.computer_types.desktop_computer import DesktopComputer
from project.computer_types.laptop import Laptop

class ComputerStoreApp:
    def __init__(self):
        self.warehouse = []
        self.profit = 0

    def build_computer(self, type_computer: str, manufacturer: str, model: str, processor: str, ram: int):
        if type_computer in ['Desktop Computer', 'Laptop']:
            computer = None

            if type_computer == 'Desktop Computer':
                computer = DesktopComputer(manufacturer, model)
            elif type_computer == 'Laptop':
                computer = Laptop(manufacturer, model)

            message = computer.configure_computer(processor, ram)
            self.warehouse.append(computer)
            return message

        raise ValueError(f'{type_computer} is not a valid type computer!')

    def sell_computer(self, client_budget: int, wanted_processor: str, wanted_ram: int):
        computer = None
        for c in self.warehouse:
            processor_available = c.processor == wanted_processor
            ram_available = c.ram >= wanted_ram
            budget_is_enough = client_budget >= c.price
            if processor_available and ram_available and budget_is_enough:
                computer = c
                break

        if computer:
            self.profit += client_budget - computer.price
            self.warehouse.remove(computer)
            return f'{repr(computer)} sold for {client_budget}$.'

        raise Exeption('Sorry, we don\'t have a computer for you.')

