def list_manipulator(numbers, *args):
    operation = args[0]
    position = args[1]
    number_args = list(args[2:])
    new_numbers = []

    if operation == 'add':                  # add
        if position == 'end':               # end
            new_numbers = numbers + number_args
        else:                               # start
            new_numbers = number_args + numbers
    else:                                   # remove
        remove_count = 1
        if number_args:
            remove_count = number_args[0]

        if position == 'end':               # end
            new_numbers = numbers[:len(numbers)-remove_count]
        else:                               # start
            new_numbers = numbers[remove_count:]

    return new_numbers

