walk_mins = int(input()) # [1; 50]
walk_count = int(input()) # [1; 10]
cal_intake = int(input()) # [100; 4000]

cal_burned = walk_mins * walk_count * 5
cal_target = cal_intake * 0.5

if cal_burned >= cal_target:
    print('Yes, the walk for your cat is enough. Burned calories per day: '
          + f'{cal_burned}.')
else:
    print(f'No, the walk for your cat is not enough. Burned calories per day: '
          + f'{cal_burned}.')
