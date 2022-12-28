def vowel_filter(function):
    def wrapper():
        vowels = ['a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y']

        letters = function()

        output = []
        for l in letters:
            if l in vowels:
                output.append(l)

        return output
    return wrapper

