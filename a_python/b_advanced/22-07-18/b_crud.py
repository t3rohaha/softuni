matrix = []
for i in range(6):
    matrix.append(input().split(' '))
row, col = map(int, input().strip('()').split(', '))
empty = '.'

while True:
    cmd = input()
    if cmd == 'Stop':
        break

    cmd_args = cmd.split(', ')
    operation, direction = cmd_args[0], cmd_args[1]

    if direction == 'up':
        row -= 1
    elif direction == 'down':
        row += 1
    elif direction == 'left':
        col -= 1
    elif direction == 'right':
        col += 1

    if operation == 'Create':
        val = cmd_args[2]
        if matrix[row][col] is empty:
            matrix[row][col] = val
    elif operation == 'Update':
        val = cmd_args[2]
        if matrix[row][col] != empty:
            matrix[row][col] = val
    elif operation == 'Delete':
        matrix[row][col] = empty
    elif operation == 'Read':
        if matrix[row][col] != empty:
            print(matrix[row][col])

for r in matrix:
    print(' '.join(r))
