def even_parameters(func):
    def wrapper(*args):
        for a in args:
            if not isinstance(a, int) or a % 2 != 0:
                return 'Please use only even numbers!'
        func_result = func(*args)
        return func_result
    return wrapper

