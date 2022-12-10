matrix = []
for _ in range(6):
    matrix.append(list(input().split()))

r, c = 0, 0
for row in range(6):
    for col in range(6):
        if matrix[row][col] == 'E':
            r, c = row, col

found = {'W': 0, 'M': 0, 'C': 0}

cmd_args = list(input().split(', '))

for cmd in cmd_args:
    if cmd == 'up':
        r -= 1
    elif cmd == 'down':
        r += 1
    elif cmd == 'left':
        c -= 1
    elif cmd == 'right':
        c += 1

    if r < 0:
        r = 5
    if r > 5:
        r = 0
    if c < 0:
        c = 5
    if c > 5:
        c = 0

    if matrix[r][c] == 'W':
        print(f'Water deposit found at ({r}, {c})')
        found['W'] += 1
    elif matrix[r][c] == 'M':
        print(f'Metal deposit found at ({r}, {c})')
        found['M'] += 1
    elif matrix[r][c] == 'C':
        print(f'Concrete deposit found at ({r}, {c})')
        found['C'] += 1
    elif matrix[r][c] == 'R':
        print(f'Rover got broken at ({r}, {c})')
        break

if found['W'] and found['M'] and found['C']:
    print('Area suitable to start the colony.')
else:
    print('Area not suitable to start the colony.')
