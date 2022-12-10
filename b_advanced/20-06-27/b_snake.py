def snake():
    matrix_size = int(input())
    matrix = []
    snake = []
    lairs = [[], []]

    for _ in range(matrix_size):
        matrix.append([*input()])

    for r in range(matrix_size):
        for c in range(matrix_size):
            if matrix[r][c] == 'S':
                matrix[r][c] = '.'
                snake.append(r)
                snake.append(c)
            elif matrix[r][c] == 'B':
                if not lairs[0]:
                    lairs[0].append(r)
                    lairs[0].append(c)
                else:
                    lairs[1].append(r)
                    lairs[1].append(c)

        if snake and lairs[0] and lairs[1]:
            break

    food = 0
    while food < 10:
        command = input()

        if command == 'left':
            snake[1] -= 1
        elif command == 'right':
            snake[1] += 1
        elif command == 'up':
            snake[0] -= 1
        elif command == 'down':
            snake[0] += 1

        if snake[0] < 0 or snake[0] > matrix_size - 1 or snake[1] < 0 or snake[1] > matrix_size - 1:
            print('Game over!')
            break

        pos = matrix[snake[0]][snake[1]]
        if pos == '*':
            food += 1
        elif pos == 'B':
            matrix[snake[0]][snake[1]] = '.'
            if lairs[0] == snake:
                snake[0] = lairs[1][0]
                snake[1] = lairs[1][1]
            else:
                snake[0] = lairs[0][0]
                snake[1] = lairs[0][1]

        matrix[snake[0]][snake[1]] = '.'
    else:
        matrix[snake[0]][snake[1]] = 'S'
        print('You won! You fed the snake.')

    print(f'Food eaten: {food}')
    for r in matrix:
        print(f'{"".join(r)}')

snake()

