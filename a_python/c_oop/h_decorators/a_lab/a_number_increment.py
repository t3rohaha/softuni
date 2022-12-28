def number_increment(numbers):
    def increase():
        new_numbers = []
        for n in numbers:
            new_numbers.append(n+1)
        return new_numbers
    return increase()

