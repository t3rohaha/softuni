from collections import deque

def bombs():
    bomb_effects = deque(map(int, input().split(', ')))
    bomb_casings = list(map(int, input().split(', ')))
    bombs = {'Cherry': [60, 0], 'Datura': [40, 0], 'Smoke Decoy': [120, 0]}

    while bomb_effects and bomb_casings:
        first_effect = bomb_effects.popleft()
        last_casing = bomb_casings.pop()
        mix = first_effect + last_casing

        if mix == bombs['Datura'][0]:
            bombs['Datura'][1] += 1
        elif mix == bombs['Cherry'][0]:
            bombs['Cherry'][1] += 1
        elif mix == bombs['Smoke Decoy'][0]:
            bombs['Smoke Decoy'][1] += 1
        else:
            last_casing -= 5
            bomb_casings.append(last_casing)
            bomb_effects.insert(0, first_effect)

        if bombs['Datura'][1] > 2 and bombs['Cherry'][1] > 2 and bombs['Smoke Decoy'][1] > 2:
            print('Bene! You have successfully filled the bomb pouch!')
            break
    else:
        print('You don\'t have enough materials to fill the bomb pouch.')

    if not bomb_effects:
        print('Bomb Effects: empty')
    else:
        print(f'Bomb Effects: {", ".join(map(str, bomb_effects))}')

    if not bomb_casings:
        print('Bomb Casings: empty')
    else:
        print(f'Bomb Casings: {", ".join(map(str, bomb_casings))}')

    for k, v in bombs.items():
        print(f'{k} Bombs: {v[1]}')

bombs()

