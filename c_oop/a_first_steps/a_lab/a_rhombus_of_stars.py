def rhombus():

    n = int(input())

    rhombus = ''

    for i in range(1, n+1):
        rhombus += ' ' * (n-i)
        rhombus += '* ' * i
        rhombus += '\n'

    for i in range(n-1, 0, -1):
        rhombus += ' ' * (n-i)
        rhombus += '* ' * i
        rhombus += '\n'

    print(rhombus.strip('\n'))

rhombus()

