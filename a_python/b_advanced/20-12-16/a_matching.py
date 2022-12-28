from collections import deque

def matching():
    males = list(map(int, input().split()))
    females = deque(map(int, input().split()))
    matches = 0

    while males and females:
        last_male = males.pop()
        first_female = females.popleft()

        if last_male < 1:
            females.insert(0, first_female)
            continue
        if first_female < 1:
            males.append(last_male)
            continue

        if last_male % 25 == 0:
            females.insert(0, first_female)
            males.pop()
            continue
        if first_female % 25 == 0:
            males.append(last_male)
            females.popleft()
            continue

        if last_male == first_female:
            matches += 1
        else:
            last_male -= 2
            males.append(last_male)

    print(f'Matches: {matches}')

    if males:
        males.reverse()
        print(f'Males left: {", ".join(map(str, males))}')
    else:
        print(f'Males left: none')
    if females:
        print(f'Females left: {", ".join(map(str, females))}')
    else:
        print(f'Females left: none')

matching()
