class custom_range:
    def __init__(self, start, end):
        self.start = start
        self.end = end
        self.n = self.start - 1

    def __iter__(self):
        return self

    def __next__(self):
        self.n += 1
        if self.n > self.end:
            raise StopIteration
        return  self.n

