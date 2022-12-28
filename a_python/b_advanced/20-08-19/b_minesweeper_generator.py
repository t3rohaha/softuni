def minesweeper_generator():
    matrix_size = int(input())
    bombs = int(input())
    bomb_positions = []

    for i in range(bombs):
        bomb_position = list(map(int, input().strip('()').split(', ')))
        bomb_positions.append(bomb_position)

    field = []
    for row in range(matrix_size):
        field.append([])
        for col in range(matrix_size):
            if [row, col] in bomb_positions:
                field[row].append('*')
            else:
                counter = 0
                if [row-1, col] in bomb_positions:              # up
                    counter += 1
                if [row-1, col+1] in bomb_positions:            # up right
                    counter += 1
                if [row, col+1] in bomb_positions:              # right
                    counter += 1
                if [row+1, col+1] in bomb_positions:            # down right
                    counter += 1
                if [row+1, col] in bomb_positions:              # down
                    counter += 1
                if [row+1, col-1] in bomb_positions:            # down left
                    counter += 1
                if [row, col-1] in bomb_positions:              # left
                    counter += 1
                if [row-1, col-1] in bomb_positions:            # up left
                    counter += 1
                field[row].append(counter)

    for r in field:
        print(' '.join(map(str, r)))

minesweeper_generator()
