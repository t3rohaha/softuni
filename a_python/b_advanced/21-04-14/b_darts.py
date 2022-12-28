def darts():

    def play(matrix, players, name, row, col):
        players[name][1] += 1
        if row < 0 or row > 6 or col < 0 or col > 6:          # hit outside
            return False
        elif row == 0 or row == 6 or col == 0 or col == 6:    # hit number
            players[name][0] -= int(matrix[row][col])
        elif matrix[row][col] == 'D':
            row_sum = int(matrix[row][0]) + int(matrix[row][6])
            col_sum = int(matrix[0][col]) + int(matrix[6][col])
            players[name][0] -= (row_sum + col_sum) * 2
        elif matrix[row][col] == 'T':
            row_sum = int(matrix[row][0]) + int(matrix[row][6])
            col_sum = int(matrix[0][col]) + int(matrix[6][col])
            players[name][0] -= (row_sum + col_sum) * 3
        elif matrix[row][col] == 'B':
            print(f'{name} won the game with {players[name][1]} throws!')
            return True

        if players[name][0] <= 0:
            print(f'{name} won the game with {players[name][1]} throws!')
            return True

    p1_name, p2_name = input().split(', ')
    players = {p1_name: [501, 0], p2_name: [501, 0]}        # points, turns
    matrix = []
    for _ in range(7):
        matrix.append(input().split())

    first = True
    while True:
        row, col = input().strip('()').split(', ')

        if first:
            winner = play(matrix, players, p1_name, int(row), int(col))
            first = False
        else:
            winner = play(matrix, players, p2_name, int(row), int(col))
            first = True

        if winner:
            break

darts()
