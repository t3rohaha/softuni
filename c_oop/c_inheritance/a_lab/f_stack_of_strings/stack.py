class Stack:
    def __init__(self):
        self.data = []

    def push(self, element):
        self.data.append(element)

    def pop(self):
        last_element = self.data.pop()
        return last_element

    def top(self):
        return self.data[-1]

    def is_empty(self):
        if not self.data:
            return True
        else:
            return False

    def __str__(self):
        return f'[{", ".join(self.data[::-1])}]'

