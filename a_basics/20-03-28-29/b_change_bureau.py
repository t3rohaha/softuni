btc = float(input()) # [0, 20]
rmb = float(input()) # [0.00, 50 000.00]
comm_perc = float(input()) #[0.00%; 5.00%]

btc_eur = (btc * 1168) / 1.95
rmb_eur = (rmb * 0.15 * 1.76) / 1.95
eur_sum = sum([btc_eur, rmb_eur])
total = eur_sum - (eur_sum * (comm_perc / 100))

print(f'{total:.2F}')
