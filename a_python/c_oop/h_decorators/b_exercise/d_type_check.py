def type_check(type_to_check):
    def decorator(func):
        def wrapper(arg):
            if not isinstance(arg, type_to_check):
                return 'Bad Type'
            func_result = func(arg)
            return func_result
        return wrapper
    return decorator

