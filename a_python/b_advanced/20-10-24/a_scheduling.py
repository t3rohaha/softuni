def scheduling():
    jobs = list(map(int, input().split(', ')))
    index = int(input())
    dictionary = {}

    for i in range(len(jobs)):
        dictionary[i] = jobs[i]

    dictionary = dict(sorted(dictionary.items(), key=lambda i: i[1]))

    cycles = 0
    for i, j in dictionary.items():
        cycles += dictionary[i]
        if i == index:
            break

    print(cycles)

scheduling()

