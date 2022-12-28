def north_pole():

    def check_item(items, item):
        if item in items:
            items[item] += 1
            items['count'] -= 1

    rows, cols = map(int, input().split(', '))
    matrix = []
    row, col = None, None                       # worker's position
    items = {'D': 0, 'G': 0, 'C': 0, 'count': 0}


    for _ in range(rows):                       # initialize Santa's workshop
        matrix.append(list(input().split()))

    for r in range(rows):                       # initialize worker's position
        for c in range(cols):                   # and items count
            if matrix[r][c] == 'Y':
                row, col = r, c
            elif matrix[r][c] in items:
                items['count'] += 1

    while True:
        args = input().split('-')
        cmd = args[0]                           # recieve command
        if cmd == 'End':
            matrix[row][col] = 'Y'
            break
        steps = int(args[1])                    # recieve steps

        if cmd == 'right':
            for s in range(steps):
                matrix[row][col] = 'x'          # mark path
                col += 1                        # move right
                if col > cols-1:
                    col = 0                     # move to first
                item = matrix[row][col]
                check_item(items, item)
                if items['count'] == 0:
                    break                       # all items collected
        elif cmd == 'left':
            for s in range(steps):
                matrix[row][col] = 'x'          # mark path
                col -= 1                        # move left
                if col < 0:
                    col = cols - 1              # move to last
                item = matrix[row][col]
                check_item(items, item)
                if items['count'] == 0:
                    break                       # all items collected
        elif cmd == 'up':
            for s in range(steps):
                matrix[row][col] = 'x'          # mark path
                row -= 1                        # move up
                if row < 0:
                    row = rows - 1              # move to last
                item = matrix[row][col]
                check_item(items, item)
                if items['count'] == 0:
                    break                       # all items collected
        elif cmd == 'down':
            for s in range(steps):
                matrix[row][col] = 'x'          # mark path
                row += 1                        # move down
                if row > rows-1:
                    row = 0                     # move to first
                item = matrix[row][col]
                check_item(items, item)
                if items['count'] == 0:
                    break                       # all items collected

        if items['count'] == 0:
            matrix[row][col] = 'Y'              # mark workers position
            print('Merry Christmas!')
            break

    print('You\'ve collected:')
    print(f'- {items["D"]} Christmas decorations')
    print(f'- {items["G"]} Gifts')
    print(f'- {items["C"]} Cookies')
    for r in matrix:
        print(' '.join(r))

north_pole()
