from collections import deque

ramen = list(map(int, input().split(', ')))
customers = deque(map(int, input().split(', ')))

while ramen and customers:
    r_end = ramen.pop()
    c_start = customers.popleft()

    if r_end == c_start:
        continue
    elif r_end > c_start:
        r_end -= c_start
        ramen.append(r_end)
    elif c_start > r_end:
        c_start -= r_end
        customers.insert(0, c_start)

if not customers:
    print('Great job! You served all the customers.')
    if ramen:
        print(f'Bowls of ramen left: {", ".join(map(str, ramen))}')
else:
    print('Out of ramen! You didn\'t manage to serve all customers.')
    print(f'Customers left: {", ".join(map(str, customers))}')
