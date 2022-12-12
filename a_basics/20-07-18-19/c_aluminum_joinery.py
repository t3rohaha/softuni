count = int(input())
type_ = input()
delivery = input()

if count > 10:
    price = 0
    if type_ == '90X130':
        price = 110 * count
        if count > 60:
            price -= price * 0.08
        elif count > 30:
            price -= price * 0.05
    elif type_ == '100X150':
        price = 140 * count
        if count > 80:
            price -= price * 0.1
        elif count > 40:
            price -= price * 0.06
    elif type_ == '130X180':
        price = 190 * count
        if count > 50:
            price -= price * 0.12
        elif count > 20:
            price -= price * 0.07
    else:
        price = 250 * count
        if count > 50:
            price -= price * 0.14
        elif count > 25:
            price -= price * 0.09

    if delivery == 'With delivery':
        price += 60

    if count > 99:
        price -= price * 0.04

    print(f'{price:.2f} BGN')
else:
    print('Invalid order')

