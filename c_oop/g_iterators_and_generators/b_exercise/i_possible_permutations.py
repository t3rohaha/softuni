from itertools import permutations

def possible_permutations(numbers):
    p = permutations(numbers)
    for i in p:
        yield list(i)

