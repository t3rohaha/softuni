from collections import deque

def alladins_gifts():

    def check_gifts(gifts, mix):
        if mix >= 100 and mix <= 199:
            gifts['Gemstone'] += 1
            return True
        elif mix >= 200 and mix <= 299:
            gifts['Porcelain Sculpture'] += 1
            return True
        elif mix >= 300 and mix <= 399:
            gifts['Gold'] += 1
            return True
        elif mix >= 400 and mix <= 499:
            gifts['Diamond Jewellery'] += 1
            return True
        else:
            return False
                                                        # INPUT
    materials = list(map(int, input().split()))         # stack
    magic_levels = deque(map(int, input().split()))     # queue
    gifts = {
        'Diamond Jewellery': 0,
        'Gemstone': 0,
        'Gold': 0,
        'Porcelain Sculpture': 0
    }

                                                        # OPERATIONS
    while materials and magic_levels:
        last_material = materials.pop()
        first_level = magic_levels.popleft()
        mix = last_material + first_level

        if mix < 100:                                   # increase mix
            if mix % 2 == 0:
                last_material *= 2
                first_level *= 3
                mix = last_material + first_level
            else:
                mix *= 2

        success = check_gifts(gifts, mix)
        if success:
            continue

        if mix > 499:                                   # decrease mix
            mix /= 2

        check_gifts(gifts, mix)

                                                        # OUTPUT
    if (gifts['Gemstone'] and gifts['Porcelain Sculpture']) or (gifts['Gold'] and gifts['Diamond Jewellery']):
        print('The wedding presents are made!')
    else:
        print('Aladdin does not have enough wedding presents.')

    if materials:
        print(f'Materials left: {", ".join(map(str, materials))}')
    if magic_levels:
        print(f'Magic left: {", ".join(map(str, magic_levels))}')

    for name, count in gifts.items():
        if count > 0:
            print(f'{name}: {count}')


alladins_gifts()
