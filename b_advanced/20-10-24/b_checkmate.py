def checkmate():
    matrix = []
    king_row, king_col = None, None

    for r in range(8):
        row = input().split()
        matrix.append(row)
        if not king_row:
            for c in range(8):
                if matrix[r][c] == 'K':
                    king_row, king_col = r, c

    captures = []

    col = king_col - 1                                  # horizontal left
    while col > -1:
        if matrix[king_row][col] == 'Q':
            captures.append([king_row, col])
            break
        col -= 1


    col = king_col + 1                                  # horizontal right
    while col < 8:
        if matrix[king_row][col] == 'Q':
            captures.append([king_row, col])
            break
        col += 1

    row = king_row - 1                                  # vertical up
    while row > -1:
        if matrix[row][king_col] == 'Q':
            captures.append([row, king_col])
            break
        row -= 1

    row = king_row + 1                                  # vertical down
    while row < 8:
        if matrix[row][king_col] == 'Q':
            captures.append([row, king_col])
            break
        row += 1

    row, col = king_row - 1, king_col - 1               # diagonal up left
    while row > -1 and col > -1:
        if matrix[row][col] == 'Q':
            captures.append([row, col])
            break
        row -= 1
        col -= 1

    row, col = king_row - 1, king_col + 1               # diagonal up right
    while row > -1 and col < 8:
        if matrix[row][col] == 'Q':
            captures.append([row, col])
            break
        row -= 1
        col += 1

    row, col = king_row + 1, king_col - 1               # diagonal down left
    while row < 8 and col > -1:
        if matrix[row][col] == 'Q':
            captures.append([row, col])
            break
        row += 1
        col -= 1

    row, col = king_row + 1, king_col + 1               # diagonal down right
    while row < 8 and col < 8:
        if matrix[row][col] == 'Q':
            captures.append([row, col])
            break
        row += 1
        col += 1

    if captures:
        for c in captures:
            print(c)
    else:
        print('The king is safe!')

checkmate()
