def logged(function):
    def wrapper(*args):
        func_result = function(*args)
        output = [f'you called {function.__name__}({", ".join(map(str, args))})',
                 f'it returned {func_result}']
        return '\n'.join(output)
    return wrapper

