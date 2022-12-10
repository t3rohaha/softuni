trunk_capacity = float(input()) # [100.0; 6 000.0]

counter = 1
suitcase_count = 0
total_vol = 0
while True:
    suitcase_vol = input() # [End, 100.0; 6 000.0]
    if suitcase_vol == 'End':
        print('Congratulations! All suitcases are loaded!')
        break

    if counter % 3 == 0:
        suitcase_vol = float(suitcase_vol) + (float(suitcase_vol) * 0.1)

    total_vol += float(suitcase_vol)

    if trunk_capacity < total_vol:
        print('No more space!')
        break

    suitcase_count += 1
    counter += 1

print(f'Statistic: {suitcase_count} suitcases loaded.')
