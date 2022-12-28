def ball_in_the_bucket():

    def is_bucket(row, col, matrix):
        return matrix[row][col] == 'B'

    def already_hit(col, buckets):
        return col in buckets

    def miss(row, col):
        return row < 0 or row > 5 or col < 0 or col > 5

    matrix = []
    buckets = []
    score = 0

    for _ in range(6):                                  # initialize matrix
        matrix.append(input().split())

    for _ in range(3):
        row, col = map(int, input().strip('()').split(', '))

        if not miss(row, col):
            if is_bucket(row, col, matrix):
                if not already_hit(col, buckets):
                    buckets.append(col)
                    for r in range(6):
                        if r != row:
                            score += int(matrix[r][col])

    prize = ''
    if score >= 100 and score <= 199:
        print(f'Good job! You scored {score} points, and you\'ve won Football.')
    elif score >= 200 and score <= 299:
        print(f'Good job! You scored {score} points, and you\'ve won Teddy Bear.')
    elif score >= 300:
        print(f'Good job! You scored {score} points, and you\'ve won Lego Construction Set.')
    else:
        print(f'Sorry! You need {100 - score} points more to win a prize.')

ball_in_the_bucket()
