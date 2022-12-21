def even_numbers(function):
    def wrapper(numbers):
        all_numbers = function(numbers)

        even_numbers = []
        for n in all_numbers:
            if n % 2 == 0:
                even_numbers.append(n)
        return even_numbers
    return wrapper

