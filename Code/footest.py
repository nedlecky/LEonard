def foo(a):
  le_print('foo(' + str(a) + ')')
  return a+3, a+4

b, c = foo(5)
le_print('b = ' + str(b) + '  c = ' + str(c))




