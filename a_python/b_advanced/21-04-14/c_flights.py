def flights(*args):
    dictionary = {}

    i = 0
    while True:
        destination = args[i]

        if destination == 'Finish':
            break

        i += 1
        passangers = args[i]

        if destination not in dictionary:
            dictionary[destination] = 0

        dictionary[destination] += passangers

        i += 1

    return dictionary

