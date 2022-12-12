rent = float(input()) # float [100.00; 10000.00]

cake = rent * (20 / 100)
drinks = cake - (cake * (45 / 100))
animator = rent / 3
total = sum([rent, cake, drinks, animator])

print(total)
