from collections import deque

def pizza_orders():
    orders = deque(map(int, input().split(', ')))
    employees = list(map(int, input().split(', ')))
    pizzas_made = 0

    while orders and employees:
        o = orders.popleft()

        if o < 1 or o > 10:             # invalid order
            continue

        e = employees.pop()

        if o <= e:                      # order can be completed
            pizzas_made += o
            continue

        o -= e                          # order can be partially completed
        pizzas_made += e
        orders.insert(0, o)

    if not orders:
        print('All orders are successfully completed!')
        print(f'Total pizzas made: {pizzas_made}')
        print(f'Employees: {", ".join(map(str, employees))}')
    else:
        print('Not all orders are completed.')
        print(f'Orders left: {", ".join(map(str, orders))}')

pizza_orders()
