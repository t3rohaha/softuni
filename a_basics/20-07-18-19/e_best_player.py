best_player = ''
best_player_goals = -1

while True:
    name = input()

    if name == 'END':
        break

    goals = int(input())

    if goals > best_player_goals:
        best_player = name
        best_player_goals = goals

    if goals >= 10:
        break

print(f'{best_player} is the best player!')
if best_player_goals < 3:
    print(f'He has scored {best_player_goals} goals.')
else:
    print(f'He has scored {best_player_goals} goals and made a hat-trick !!!')

