def pawn_wars():

    def format_pos(pos):
        colPos = {
            0: 'a',
            1: 'b',
            2: 'c',
            3: 'd',
            4: 'e',
            5: 'f',
            6: 'g',
            7: 'h'
        }
        return f'{colPos[pos[1]]}{abs(pos[0]-8)}'

    w_pos = None
    b_pos = None
    board = []
    for _ in range(8):
        board.append(input().split(' '))

    for row in range(8):
        for col in range(8):
            if not w_pos:
                if board[row][col] == 'w':
                    w_pos = [row, col]
            if not b_pos:
                if board[row][col] == 'b':
                    b_pos = [row, col]
            if w_pos and b_pos:
                break

    while True:
        w_pos[0] = w_pos[0] - 1
        if w_pos[0] == 0:
            print(f'Game over! White pawn is promoted to a queen at {format_pos(w_pos)}.')
            break
        if w_pos[0] == b_pos[0] and abs(w_pos[1] - b_pos[1]) == 1:
            print(f'Game over! White win, capture on {format_pos(b_pos)}.')
            break

        b_pos[0] = b_pos[0] + 1
        if b_pos[0] == 7:
            print(f'Game over! Black pawn is promoted to a queen at {format_pos(b_pos)}.')
            break
        if b_pos[0] == w_pos[0] and abs(b_pos[1] - w_pos[1]) == 1:
            print(f'Game over! Black win, capture on {format_pos(w_pos)}.')
            break

pawn_wars()
