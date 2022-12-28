class sequence_repeat:
    def __init__(self, sequence, number):
        self.sequence = sequence
        self.number = number
        self.n = self.number
        self.index = -1

    def __iter__(self):
        return self

    def __next__(self):
        if self.n == 0:
            raise StopIteration
        self.n -= 1

        self.index += 1
        if self.index == len(self.sequence):
            self.index = 0

        return self.sequence[self.index]

