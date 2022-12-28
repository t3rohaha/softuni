import math

sec_target = float(input()) # [0.00; 100 000.00]
met_distance = float(input()) # [0.00; 100 000.00]
personal_sec_per_met = float(input()) # [0.00; 1 000.00]

record = personal_sec_per_met * met_distance
incline_penalty = 0

if met_distance >= 50:
    incline_penalty = math.floor(met_distance / 50) * 30

record += incline_penalty

diff = abs(sec_target - record)
if sec_target > record:
    print(f'Yes! The new record is {record:.2f} seconds.')
else:
    print(f'No! He was {diff:.2f} seconds slower.')
