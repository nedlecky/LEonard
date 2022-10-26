try:
  py_counter += 1
except NameError:
  py_counter = 13

leWriteVariable('py_counter', str(py_counter))
lePrint('py_counter is ' + str(py_counter))
