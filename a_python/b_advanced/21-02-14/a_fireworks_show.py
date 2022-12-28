from collections import deque

def fireworks_show():
    fireworks = deque(map(int, input().split(', ')))
    explosives = list(map(int, input().split(', ')))
    mixes = {'Palm': 0, 'Willow': 0, 'Crossette': 0}

    while fireworks and explosives:
        first_fw = fireworks.popleft()
        if first_fw < 1:
            continue
        last_x = explosives.pop()
        if last_x < 1:
            fireworks.insert(0, first_fw)
            continue
        mix = first_fw + last_x


        if mix % 3 == 0 and mix % 5 == 0:
            mixes['Crossette'] += 1
        elif mix % 5 == 0:
            mixes['Willow'] += 1
        elif mix % 3 == 0:
            mixes['Palm'] += 1
        else:
            fireworks.append(first_fw - 1)
            explosives.append(last_x)

        if mixes['Palm'] > 2 and mixes['Willow'] > 2 and mixes['Crossette'] > 2:
            print('Congrats! You made the perfect firework show!')
            break
    else:
        print('Sorry. You can\'t make the perfect firework show.')

    if fireworks:
        print(f'Firework Effects left: {", ".join(map(str, fireworks))}')
    if explosives:
        print(f'Explosive Power left: {", ".join(map(str, explosives))}')

    for k, v in mixes.items():
        print(f'{k} Fireworks: {v}')

fireworks_show()
