luggage_price = float(input())
luggage_weight = float(input())
days = int(input())
luggage_count = int(input())

total_price = 0

if luggage_weight < 10:
    total_price = luggage_price * 0.2
elif luggage_weight <= 20:
    total_price = luggage_price * 0.5
else:
    total_price = luggage_price

if days < 7:
    total_price += total_price * 0.4
elif days <= 30:
    total_price += total_price * 0.15
else:
    total_price += total_price * 0.1

total_price *= luggage_count

print(f'The total price of bags is: {total_price:.2f} lv. ')

