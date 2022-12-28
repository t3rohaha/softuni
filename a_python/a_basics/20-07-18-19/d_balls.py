import math

n = int(input())

points, red, orange, yellow, white, black, other = 0, 0, 0, 0, 0, 0, 0
for _ in range(n):
    color = input()

    if color == 'red':
        red += 1
        points += 5
    elif color == 'orange':
        orange += 1
        points += 10
    elif color == 'yellow':
        yellow += 1
        points += 15
    elif color == 'white':
        white += 1
        points += 20
    elif color == 'black':
        black += 1
        points = math.floor(points/2)
    else:
        other += 1

print(f'Total points: {points}')
print(f'Red balls: {red}')
print(f'Orange balls: {orange}')
print(f'Yellow balls: {yellow}')
print(f'White balls: {white}')
print(f'Other colors picked: {other}')
print(f'Divides from black balls: {black}')

