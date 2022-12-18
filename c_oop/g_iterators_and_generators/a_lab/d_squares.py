import math

def squares(n):
    i = 1
    while i <= n:
        yield int(math.pow(i, 2))
        i += 1

