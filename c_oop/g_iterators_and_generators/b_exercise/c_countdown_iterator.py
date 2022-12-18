class countdown_iterator:
    def __init__(self, count):
        self.count = count
        self.n = count + 1

    def __iter__(self):
        return self

    def __next__(self):
        self.n -= 1
        if self.n < 0:
            raise StopIteration
        return self.n

