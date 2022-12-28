def game_of_words():
    word = [*input()]
    matrix_size = int(input())
    matrix = []
    row, col = None, None

    for r in range(matrix_size):
        matrix.append([*input()])
        for c in range(matrix_size):
            if not row and not col:
                if matrix[r][c] == 'P':
                    row, col = r, c
                    matrix[r][c] = '-'

    commands_n = int(input())
    for _ in range(commands_n):
        command = input()

        if command == 'down':
            row += 1
            if row > matrix_size - 1:
                row = matrix_size - 1
                if word:
                    word.pop()
        elif command == 'up':
            row -= 1
            if row < 0:
                row = 0
                if word:
                    word.pop()
        elif command == 'right':
            col += 1
            if col > matrix_size - 1:
                col = matrix_size - 1
                if word:
                    word.pop()
        elif command == 'left':
            col -= 1
            if col < 0:
                col = 0
                if word:
                    word.pop()

        if matrix[row][col] != '-':
            word.append(matrix[row][col])
            matrix[row][col] = '-'

    matrix[row][col] = 'P'

    print(''.join(word))
    for r in matrix:
        print(''.join(r))


game_of_words()
