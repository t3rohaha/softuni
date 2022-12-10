from collections import deque

def flowers_finder():
    vowels = deque(input().split())
    consonants = input().split()

    words = {
        'rose': ['r', 'o', 's', 'e'],
        'tulip': ['t', 'u', 'l', 'i', 'p'],
        'lotus': ['l', 'o', 't', 'u', 's'],
        'daffodil': ['d', 'a', 'f', 'o', 'i', 'l']
    }

    found = False
    while not found and vowels and consonants:
        vow_first = vowels.popleft()
        cons_last = consonants.pop()

        for w in words.keys():
            if vow_first in words[w]:
                words[w].remove(vow_first)
            if cons_last in words[w]:
                words[w].remove(cons_last)
            if not words[w]:
                found = True
                print(f'Word found: {w}')
                break

    if not found:
        print('Cannot find any word!')
    if vowels:
        print(f'Vowels left: {" ".join(vowels)}')
    if consonants:
        print(f'Consonants left: {" ".join(consonants)}')


flowers_finder()
