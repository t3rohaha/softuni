food_reserve = int(input()) # [1; 100] kg
food_reserve = food_reserve * 1000 # Convert kg to g

food_total = 0
while True:
    food_serving = input() # [10; 1 000] g
    if food_serving == 'Adopted':
        break

    food_total += int(food_serving)

if food_reserve >= food_total:
    print(f'Food is enough! Leftovers: {food_reserve - food_total} grams.')
else:
    print(f'Food is not enough. You need {food_total - food_reserve} grams more.')
