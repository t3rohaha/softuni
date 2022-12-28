def start_spring(**args):
    d = {}
    for k, v in args.items():
        if v not in d:
            d[v] = []
        d[v].append(k)

    for k, v in d.items():
        d[k] = sorted(v)

    sorted_d = dict(sorted(d.items()))
    sorted_d = dict(sorted(sorted_d.items(), key=lambda i: len(i[1]), reverse=True))

    output = ""
    for k, v in sorted_d.items():
        output += f'{k}:\n'
        for i in v:
            output += f'-{i}\n'

    return output.strip('\n')

