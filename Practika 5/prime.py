from math import sqrt
def Number(p):
    div = 2
    while sqrt(p) >= div:
        if p % div == 0:
            return False
        div += 1
    return p