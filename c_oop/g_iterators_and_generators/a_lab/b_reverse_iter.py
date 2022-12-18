class reverse_iter:
    def __init__(self, iterable):
        self.iterable = iterable
        self.i = len(iterable)

    def __iter__(self):
        return self

    def __next__(self):
        self.i -= 1
        if self.i < 0:
            raise StopIteration
        return self.iterable[self.i]

