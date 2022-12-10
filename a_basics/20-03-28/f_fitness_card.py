cash = int(input()) # [10.00; 1 000.00]
gender = input() # m or f
age = int(input()) # [5; 105]
sport = input() # Gym or Boxing or Yoga or Zumba or Dances or Pilates

sports = {
    'Gym': {'m': 42, 'f': 35},
    'Boxing': {'m': 41, 'f': 37},
    'Yoga': {'m': 45, 'f': 42},
    'Zumba': {'m': 34, 'f': 31},
    'Dances': {'m': 51, 'f': 53},
    'Pilates': {'m': 39, 'f': 37}
}

price = sports[sport][gender]

if age <= 19:
    price -= price * 0.2

if cash >= price:
    print(f'You purchased a 1 month pass for {sport}.')
else:
    diff = price - cash
    print(f'You don\'t have enough money! You need ${diff:.2f} more.')
