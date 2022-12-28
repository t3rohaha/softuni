def solution():

    def integers():
        i = 1
        while True:
            yield i
            i += 1

    def halves():
        for i in integers():
            yield i / 2

    def take(n, seq):
        rv = []

        for _ in range(n):
            rv.append(next(seq))

        return rv

    return (take, halves, integers)

