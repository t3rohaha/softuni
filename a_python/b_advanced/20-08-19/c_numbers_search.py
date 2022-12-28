def numbers_searching(*args):
    sorted_numbers = sorted(args)

    duplicates = set()
    last = None
    for current in sorted_numbers:
        if current == last:
            duplicates.add(current)
        last = current

    unique_numbers = sorted(list(set(sorted_numbers)))
    last = unique_numbers.pop()
    unique_numbers.reverse()
    missing_number = None
    for current in unique_numbers:
        if current != last - 1:
            missing_number = last - 1
            break
        last = current

    return [missing_number, sorted(list(duplicates))]

