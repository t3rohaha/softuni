def multiply(times):
    def decorator(function):
        def wrapper(number):
            func_result = function(number)
            return func_result * times
        return wrapper
    return decorator

