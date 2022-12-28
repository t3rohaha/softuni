first_number = input()
second_number = input()

numbers = []
for thousands in range(int(first_number[0]), int(second_number[0])+1):
    if thousands % 2 != 0:
        for hundreds in range(int(first_number[1]), int(second_number[1])+1):
            if hundreds % 2 != 0:
                for tens in range(int(first_number[2]), int(second_number[2])+1):
                    if tens % 2 != 0:
                        for ones in range(int(first_number[3]), int(second_number[3])+1):
                            if ones % 2 != 0:
                                numbers.append(f'{thousands}{hundreds}{tens}{ones}')

print(' '.join(map(str,numbers)))

