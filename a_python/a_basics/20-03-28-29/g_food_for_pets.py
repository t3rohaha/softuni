days_input = int(input()) # [1; 30]
food_input = float(input()) # [0.00; 10 000.00]

day = 1
bisquits = 0
dog_total = 0
cat_total = 0
while True:
    dog_day = int(input()) # [10; 500]
    cat_day = int(input()) # [10; 500]

    dog_total += dog_day
    cat_total += cat_day
    total_day = sum([dog_day, cat_day])

    if day % 3 == 0:
        bisquits += total_day * 0.1

    if day == days_input:
        break

    day += 1

total = sum([dog_total, cat_total])
eaten_perc = (total * 100) / food_input
eaten_dog_perc = (dog_total * 100) / total
eaten_cat_perc = (cat_total * 100) / total
print(f'Total eaten biscuits: {int(bisquits)}gr.')
print(f'{eaten_perc:.2f}% of the food has been eaten.')
print(f'{eaten_dog_perc:.2f}% eaten from the dog.')
print(f'{eaten_cat_perc:.2f}% eaten from the cat.')
