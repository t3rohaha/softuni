def tags(tag):
    def decorator(func):
        def wrapper(*args):
            func_result = func(*args)
            output = f'<{tag}>{func_result}</{tag}>'
            return output
        return wrapper
    return decorator

