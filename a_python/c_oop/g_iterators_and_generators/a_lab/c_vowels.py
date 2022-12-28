class vowels:
    def __init__(self, string):
        self.string = string
        self.v = self.get_vowels()
        self.index = -1

    def get_vowels(self):
        v = []
        for s in self.string:
            if s in ['a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y']:
                v.append(s)
        return v

    def __iter__(self):
        return self

    def __next__(self):
        self.index += 1
        if self.index == len(self.v):
            raise StopIteration
        return self.v[self.index]

