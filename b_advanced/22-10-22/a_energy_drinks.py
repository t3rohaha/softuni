from collections import deque

caf_input = list(map(int, input().split(', ')))
drinks_input = deque(map(int, input().split(', ')))

caf_stamat = 0
max_caf_stamat = 300

while len(caf_input) > 0 and len(drinks_input) > 0:
    caf = caf_input.pop()
    drink = drinks_input.popleft()
    total = caf * drink

    if total + caf_stamat <= max_caf_stamat:
        caf_stamat += total
        continue

    drinks_input.append(drink)
    caf_stamat -= 30
    if caf_stamat < 0:
        caf_stamat = 0

if len(drinks_input) > 0:
    print(f'Drinks left: {", ".join(map(str, drinks_input))}')
else:
    print(f'At least Stamat wasn\'t exceeding the maximum caffeine.')
print(f'Stamat is going to sleep with {caf_stamat} mg caffeine.')
