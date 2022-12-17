class Account:

    def __init__(self, owner: str, amount: int = 0):
        self.owner = owner
        self.amount = amount
        self._transactions = []
        self.__index = -1

    def handle_transaction(self, transaction_amount):
        if transaction_amount + self.balance >= 0:
            self._transactions.append(transaction_amount)
            return f'New balance: {self.balance}'
        raise ValueError('sorry cannot go in debt!')

    def add_transaction(self, amount):
        if isinstance(amount, int):
            return self.handle_transaction(amount)
        raise ValueError('please use int for amount')

    @property
    def balance(self):
        balance = self.amount
        for t in self._transactions:
            balance += t
        return balance

    def __getitem__(self, index):
        return self._transactions[index]

    def __iter__(self):
        return self

    def __next__(self):
        if self.__index == len(self._transactions) - 1:
            raise StopIteration
        self.__index += 1
        return self._transactions[self.__index]

    def __reversed__(self):
        return self._transactions[::-1]

    def __add__(self, other):
        name = f'{self.owner}&{other.owner}'
        amount = self.amount + other.amount
        account = Account(name, amount)
        account._transactions = self._transactions + other._transactions
        return account

    def __eq__(self, other):
        return self.balance == other.balance

    def __ne__(self, other):
        return self.balance != other.balance

    def __gt__(self, other):
        return self.balance > other.balance

    def __lt__(self, other):
        return self.balance < other.balance

    def __ge__(self, other):
        return self.balance >= other.balance

    def __le__(self, other):
        return self.balance <= other.balance

    def __len__(self):
        return len(self._transactions)

    def __str__(self):
        return f'Account of {self.owner} with starting amount: {self.amount}'

    def __repr__(self):
        return f'Account({self.owner}, {self.amount})'

