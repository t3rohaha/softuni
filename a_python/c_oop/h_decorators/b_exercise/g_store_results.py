import functools

class store_results:
    def __init__(self, func):
        functools.update_wrapper(self, func)
        self.func = func

    def __call__(self, *args, **kwargs):
        func_name = self.func.__name__
        func_result = self.func(*args, **kwargs)
        self.write_text(f'Function {func_name} was called. Result: {func_result}')
        return func_result

    def write_text(self, text):
        with open('results.txt', 'a') as f:
            f.write(text)
            f.write('\n')

