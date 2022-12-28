def make_bold(func):
    def wrapper(*args):
        func_result = func(*args)
        output = f'<b>{func_result}</b>'
        return output
    return wrapper

def make_italic(func):
    def wrapper(*args):
        func_result = func(*args)
        output = f'<i>{func_result}</i>'
        return output
    return wrapper

def make_underline(func):
    def wrapper(*args):
        func_result = func(*args)
        output = f'<u>{func_result}</u>'
        return output
    return wrapper

