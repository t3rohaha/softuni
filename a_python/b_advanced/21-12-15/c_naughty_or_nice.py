def naughty_or_nice_list(kids_list, *cmd_tuple, **cmd_dict):
    dictionary = {'Nice': [], 'Naughty': [], 'Not found': []}

    for cmd in cmd_tuple:                           # check arguments
        args = cmd.split('-')
        number = int(args[0])
        attitude = args[1]
        temp_kids =  []

        for kid in kids_list:
            if kid[0] == number:
                temp_kids.append(kid)

        if len(temp_kids) == 1:
            kid = temp_kids.pop()
            dictionary[attitude].append(kid[1])
            kids_list.remove(kid)

    for name, attitude in cmd_dict.items():         # check keywords
        temp_kids = []

        for kid in kids_list:
            if kid[1] == name:
                temp_kids.append(kid)

        if len(temp_kids) == 1:
            kid = temp_kids.pop()
            dictionary[attitude].append(kid[1])
            kids_list.remove(kid)

    for kid in kids_list:                           # check not found
        dictionary['Not found'].append(kid[1])

    output = ''
    for k, v in dictionary.items():
        if v:
            output += f'{k}: {", ".join(v)}\n'

    return output.strip('\n')

