from operator import itemgetter

def shopping_cart(*args):
    meals = {'Pizza': [], 'Soup': [], 'Dessert': []}

    for cmd in args:
        if cmd == 'Stop':
            break
        elif cmd[0] == 'Pizza' and len(meals['Pizza']) == 4:
            continue
        elif (cmd[0] == 'Soup' and len(meals['Soup']) == 3):
            continue
        elif cmd[0] == 'Dessert' and len(meals['Dessert']) == 2:
            continue

        if cmd[1] not in meals[cmd[0]]:
            meals[cmd[0]].append(cmd[1])

    for k, v in meals.items():                      # sort meal products
        meals[k] = sorted(v)

    meals = dict(sorted(meals.items()))             # sort meals by name

                                                    # sort meals by prod count
    meals = dict(sorted(meals.items(), key=lambda i: len(i[1]), reverse=True))

    output = ''

    if meals['Pizza'] or meals['Soup'] or meals['Dessert']:
        for k in meals:
            output += f'{k}:\n'
            for v in meals[k]:
                output += f' - {v}\n'
    else:
        output = 'No products in the cart!'

    return output.strip('\n')

