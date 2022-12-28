from collections import deque

def taxi_express():
    customers = deque(map(int, input().split(', ')))
    taxis = list(map(int, input().split(', ')))
    total_time = 0

    while customers and taxis:
        first_customer = customers.popleft()
        last_taxi = taxis.pop()

        if last_taxi >= first_customer:
            total_time += first_customer
            continue

        customers.insert(0, first_customer)

    if not customers:
        print('All customers were driven to their destinations')
        print(f'Total time: {total_time} minutes')
    else:
        print('Not all customers were driven to their destinations')
        print(f'Customers left: {", ".join(map(str, customers))}')

taxi_express()
