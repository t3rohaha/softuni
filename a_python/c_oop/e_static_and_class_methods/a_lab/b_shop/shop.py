class Shop:

    def __init__(self, name: str, type_: str, capacity: int):
        self.name = name
        self.type = type_
        self.capacity = capacity
        self.items = {}

    @classmethod
    def small_shop(cls, name: str, type_: str):
        return cls(name, type_, 10)

    def add_item(self, item_name: str):
        if sum(self.items.values()) < self.capacity:
            if item_name not in self.items:
                self.items[item_name] = 0
            self.items[item_name] += 1
            return f'{item_name} added to the shop'
        return f'Not enough capacity in the shop'

    def remove_item(self, item_name: str, amount: int):
        if item_name in self.items and self.items[item_name] >= amount:
            self.items[item_name] -= amount
            if self.items[item_name] == 0:
                del self.items[item_name]
            return f'{amount} {item_name} removed from the shop'
        return f'Cannot remove {amount} {item_name}'

    def __repr__(self):
        return f'{self.name} of type {self.type} with capacity {self.capacity}'

