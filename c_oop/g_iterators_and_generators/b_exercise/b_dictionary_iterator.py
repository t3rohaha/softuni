class dictionary_iter:
    def __init__(self, dictionary):
        self.dictionary = dictionary
        self.tuples = self.convert()
        self.i = -1

    def convert(self):
        li = []
        for k, v in self.dictionary.items():
            li.append((k, v))
        return li

    def __iter__(self):
        return self

    def __next__(self):
        self.i += 1
        if self.i == len(self.tuples):
            raise StopIteration
        return self.tuples[self.i]

