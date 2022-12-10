player1, player2 = input().split(', ')
matrix = []
for _ in range(6):
    matrix.append(input().split(' '))

rest = {'Tom': False, 'Jerry': False}
while True:
    r, c = map(int, input().strip('()').split(', '))

    if not rest[player1]:
        if matrix[r][c] == 'E':
            print(f'{player1} found the Exit and wins the game!')
            break
        elif matrix[r][c] == 'T':
            print(f'{player1} is out of the game! The winner is {player2}.')
            break
        elif matrix[r][c] == 'W':
            print(f'{player1} hits a wall and needs to rest.')
            rest[player1] = True
    else:
        rest[player1] = False

    player1, player2 = player2, player1

