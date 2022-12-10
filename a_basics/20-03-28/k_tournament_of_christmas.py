days = int(input()) # [1; 20]

total_funds = 0
total_wins = 0
total_loses = 0
counter = 0
while True:
    counter += 1
    wins = 0
    loses = 0
    funds = 0

    while True:
        sport = input() # Finish or [different sports]
        if sport == 'Finish':
            break

        result = input() # win or lose

        if result == 'win':
            funds += 20
            wins += 1

        if result == 'lose':
            loses += 1

    total_wins += wins
    total_loses += loses

    if wins > loses:
        # 10% bonus on winning day
        funds += funds * 0.1

    total_funds += funds

    if days == counter:
        break;

# total_wins == total_loses will never happen
if total_wins > total_loses:
    # 20% bonus for winning the tournament
    total_funds += total_funds * 0.2
    print(f'You won the tournament! Total raised money: {total_funds:.2f}')
else:
    print(f'You lost the tournament! Total raised money: {total_funds:.2f}')
