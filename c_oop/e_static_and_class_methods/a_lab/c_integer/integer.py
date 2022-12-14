import math

class Integer:

    def __init__(self, value: int):
        self.value = value

    @classmethod
    def from_float(cls, float_value: float):
        if type(float_value) == float:
            return cls(math.floor(float_value))
        return 'value is not a float'

    @classmethod
    def from_string(cls, value):
        if type(value) == str:
            return cls(int(value))
        return 'wrong type'

    @classmethod
    def from_roman(cls, roman_num):
        numerals = {'I': 1, 'V': 5, 'X': 10, 'L': 50, 'C': 100, 'D': 500, 'M': 1000}
        result = 0
        for i, c in enumerate(roman_num):
            if (i+1) == len(roman_num) or numerals[c] >= numerals[roman_num[i+1]]:
                result += numerals[c]
            else:
                result -= numerals[c]
        return cls(result)

