from functools import cmp_to_key

def forecast(*args):
    def weather_sort(t1, t2):
        w1 = t1[1]
        w2 = t2[1]

        if w1 == 'Sunny' and (w2 == 'Cloudy' or w2 == 'Rainy'):
            return 1
        elif w2 == 'Sunny' and (w1 == 'Cloudy' or w1 == 'Rainy'):
            return -1
        elif w1 == 'Cloudy' and w2 == 'Rainy':
            return 1
        elif w2 == 'Cloudy' and  w1 == 'Rainy':
            return -1
        else:
            return 0

    weather = list(args)
    weather_sorted = sorted(weather, key=lambda w: w[0])    # sort by city
    weather_sorted = sorted(weather_sorted,
                            key=cmp_to_key(weather_sort),   # sort by weather
                            reverse=True)

    output = ''
    for w in weather_sorted:
        output += f'{w[0]} - {w[1]}\n'

    return output.strip()
