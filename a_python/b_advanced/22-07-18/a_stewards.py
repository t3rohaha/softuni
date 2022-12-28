from collections import deque

seats = input().split(', ')
queue = deque(list(map(int, input().split(', '))))
stack = list(map(int, input().split(', ')))
matches = []
rotations = 0

while len(matches) < 3 and rotations < 10:
    a = queue.popleft()
    b = stack.pop()
    char = chr(a + b)
    seat_a = f'{a}{char}'
    seat_b = f'{b}{char}'

    if seat_a not in seats and seat_b not in seats:
        queue.append(a)
        stack.insert(0, b)
    else:
        if seat_a in seats and seat_a not in matches:
            matches.append(seat_a)
        elif seat_b in seats and seat_b not in matches:
            matches.append(seat_b)

    rotations += 1

print(f'Seat matches: {", ".join(matches)}')
print(f'Rotations count: {rotations}')
