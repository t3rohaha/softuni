def shopping_list(budget, **products):
    output = ''
    if budget >= 100:
        products_bought = 0
        for name, info in products.items():
            price = info[0] * info[1]               # price * quantity
            if budget >= price:
                products_bought += 1
                budget -= price
                output += f'You bought {name} for {price:.2f} leva.\n'
            if products_bought == 5:
                break

    else:
        output += 'You do not have enough budget.'

    return output.strip('\n')

