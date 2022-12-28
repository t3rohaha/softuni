def get_magic_triangle(n):
    triangle = []

    triangle.append([1])
    for _ in range(n-1):
        last_row = triangle[len(triangle) - 1]
        new_row = []

        for i in range(len(triangle) + 1):
            if i == 0 or i == len(triangle):
                new_row.append(1)
            else:
                new_row.append(last_row[i-1] + last_row[i])

        triangle.append(new_row)

    return triangle

