from collections import deque

eggs = deque(list(map(int, input().split(', '))))
papers = list(map(int, input().split(', ')))
box_size = 50
boxes = 0

while eggs and papers:
    e = eggs.popleft()
    p = papers.pop()
    if e > 0:
        if e == 13:
            papers.append(papers[0])
            papers[0] = p
            continue
        if (e + p) <= box_size:
            boxes += 1
        continue
    papers.append(p)

if boxes:
    print(f'Great! You filled {boxes} boxes.')
else:
    print(f'Sorry! You couldn\'t fill any boxes!')
if eggs:
    print(f'Eggs left: {", ".join(map(str, eggs))}')
if papers:
    print(f'Pieces of paper left: {", ".join(map(str, papers))}')

