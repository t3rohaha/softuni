def get_primes(integers):
    for x in integers:
        if x != 0 and x != 1:
            is_prime = True
            for y in range(2, x):
                if x % y == 0:
                    is_prime = False
                    break
            if is_prime:
                yield x

