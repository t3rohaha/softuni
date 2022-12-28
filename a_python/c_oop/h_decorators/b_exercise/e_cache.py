import functools

def cache(func):

    functools.wraps(func)
    def wrapper_cache(n):
        func_result = func(n)
        wrapper_cache.log[n] = func_result
        return func_result
    wrapper_cache.log = {}
    return wrapper_cache

@cache
def fibonacci(n):
    if n < 2:
        return n
    return fibonacci(n-1) + fibonacci(n-2)

