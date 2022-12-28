groups_count = int(input()) # [1; 1 000]

group = 1
groups = {
    'Мусала': 0,
    'Монблан': 0,
    'Килиманджаро': 0,
    'К2': 0,
    'Еверест': 0
}
while True:
    group_size = int(input())

    if group_size < 6:
        groups['Мусала'] += group_size
    elif group_size > 5 and group_size < 13:
        groups['Монблан'] += group_size
    elif group_size > 12 and group_size < 26:
        groups['Килиманджаро'] += group_size
    elif group_size > 25 and group_size < 41:
        groups['К2'] += group_size
    else:
        groups['Еверест'] += group_size

    if group == groups_count:
        break

    group += 1

total = sum(groups.values())

for v in groups.values():
    perc = (v * 100) / total
    print(f'{perc:.2f}%')
