from project.customer import Customer
from project.dvd import DVD

class MovieWorld:

    def __init__(self, name: str):
        self.name = name
        self.customers = []
        self.dvds = []

    @classmethod
    def dvd_capacity(cls):
        return 15

    @classmethod
    def customer_capacity(cls):
        return 10

    def add_customer(self, customer: Customer):
        if len(self.customers) < self.customer_capacity():
            self.customers.append(customer)

    def add_dvd(self, dvd: DVD):
        if len(self.dvds) < self.dvd_capacity():
            self.dvds.append(dvd)

    def rent_dvd(self, customer_id: int, dvd_id: int):
        customer = self.get_customer(customer_id)
        dvd = self.get_dvd(dvd_id)

        if dvd in customer.rented_dvds:
            return f'{customer.name} has already rented {dvd.name}'

        if dvd.is_rented:
            return 'DVD is already rented'

        if customer.age < dvd.age_restriction:
            return f'{customer.name} should be at least {dvd.age_restriction} to rent this movie'

        customer.rented_dvds.append(dvd)
        dvd.is_rented = True
        return f'{customer.name} has successfully rented {dvd.name}'

    def return_dvd(self, customer_id, dvd_id):
        customer = self.get_customer(customer_id)
        dvd = self.get_dvd(dvd_id)

        if dvd in customer.rented_dvds:
            customer.rented_dvds.remove(dvd)
            dvd.is_rented = False
            return f'{customer.name} has successfully returned {dvd.name}'

        return f'{customer.name} does not have that DVD'

    def __repr__(self):
        NL = '\n'
        output = ''

        for c in self.customers:
            output += f'{c}' + NL

        for d in self.dvds:
            output += f'{d}' + NL

        return output.strip()

    # Additional methods #

    def get_customer(self, customer_id: int):
        customer = None
        for c in self.customers:
            if c.id == customer_id:
                customer = c
                break
        return customer

    def get_dvd(self, dvd_id: int):
        dvd = None
        for temp_dvd in self.dvds:
            if temp_dvd.id == dvd_id:
                dvd = temp_dvd
                break
        return dvd


