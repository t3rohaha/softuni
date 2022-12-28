def words_sorting(*args):
    d = {}
    for string in args:
        s = sum([ord(c) for c in string])
        d[string] = s

    if sum(d.values()) % 2 == 0:
        d = dict(sorted(d.items()))
    else:
        d = dict(sorted(d.items(), key=lambda item: item[1], reverse=True))

    output = ''
    for k, v in d.items():
        output += f'{k} - {v}\n'

    return output.strip('\n')

