def race():
    sq_matrix_size = int(input())
    race_car_number = input()
    sq_matrix = []                  # race track
    row, col = 0, 0                 # car position
    distance = 0

    for i in range(sq_matrix_size):
        sq_matrix.append(input().split(' '))

    def find_end_of_tunnel(sq_matrix):
       for r in range(len(sq_matrix)):
           for c in range(len(sq_matrix[r])):
               if sq_matrix[r][c] == 'T':
                   return r, c

    while True:
        command = input()
        if command == 'End':
            print(f'Racing car {race_car_number} DNF.')
            break
        elif command == 'left':
            col -= 1
        elif command == 'right':
            col += 1
        elif command == 'up':
            row -= 1
        elif command == 'down':
            row += 1

        if sq_matrix[row][col] == 'T':
           distance += 30
           sq_matrix[row][col] = '.'
           row, col = find_end_of_tunnel(sq_matrix)
           sq_matrix[row][col] = '.'
        elif sq_matrix[row][col] == 'F':
           distance += 10
           print(f'Racing car {race_car_number} finished the stage!')
           break
        else:
            distance += 10

    print(f'Distance covered {distance} km.')

    sq_matrix[row][col] = 'C'       # mark last known position of the car
    for r in sq_matrix:
        print(''.join(r))           # print race track
