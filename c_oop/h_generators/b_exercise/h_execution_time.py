from functools import wraps
from time import time

def exec_time(func):
    @wraps(func)
    def wrapper_exec_time(*args, **kvargs):
        start = time()
        func_result = func(*args, **kvargs)
        stop = time()
        exec_time_result = stop - start
        return exec_time_result
    return wrapper_exec_time

