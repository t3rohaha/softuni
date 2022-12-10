def best_list_pureness(li, n):
    best_pureness = 0
    rotation = 0
    for i in range(n+1):
        pureness = 0
        for j in li:
            pureness += j * li.index(j)

        if pureness > best_pureness:
            best_pureness = pureness
            rotation = i

        li.insert(0, li.pop())

    return f'Best pureness {best_pureness} after {rotation} rotations'

