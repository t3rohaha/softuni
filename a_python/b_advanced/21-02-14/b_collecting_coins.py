import math

def collecting_coins():
    matrix_size = int(input())
    matrix = []
    row, col = None, None
    for r in range(matrix_size):
        matrix.append(input().split())
        if not row and not col:
            for c in range(matrix_size):
                if matrix[r][c] == 'P':
                    row, col = r, c

    coins = 0
    path = [[row, col]]
    while coins < 100:
        command = input()

        if command == 'up':
            row -= 1
            if row < 0:
                row = matrix_size - 1
        elif command == 'down':
            row += 1
            if row > matrix_size - 1:
                row = 0
        elif command == 'left':
            col -= 1
            if col < 0:
                col = matrix_size - 1
        elif command == 'right':
            col += 1
            if col > matrix_size - 1:
                col = 0

        if matrix[row][col].isnumeric():
            if [row, col] not in path:
                coins += int(matrix[row][col])
        elif matrix[row][col] == 'X':
            path.append([row, col])
            coins = math.floor(coins / 2)
            print(f'Game over! You\'ve collected {coins} coins.')
            break

        path.append([row, col])
    else:
        print(f'You won! You\'ve collected {coins} coins.')

    print('Your path:')
    for p in path:
        print(p)

collecting_coins()

