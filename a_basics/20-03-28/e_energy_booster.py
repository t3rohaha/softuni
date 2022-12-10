fruit = input() # Watermelon || Mango || Pineapple || Raspberry
size = input() # small (*2) || big (*5)
quantity = int(input()) # [1; 10 000]

price = 0
if fruit == 'Watermelon':
    if size == 'small':
        price = 56 * 2
    else:
        price = 28.7 * 5
elif fruit == 'Mango':
    if size == 'small':
        price = 36.66 * 2
    else:
        price = 19.6 * 5
elif fruit == 'Pineapple':
    if size == 'small':
        price = 42.1 * 2
    else:
        price = 24.8 * 5
else:
    if size == 'small':
        price = 20 * 2
    else:
        price = 15.20 * 5

price *= quantity

if price >= 400 and price <= 1000:
    price -= price * 0.15
elif price > 1000:
    price -= price * 0.5

print(f'{price:.2f} lv.')
