try:
  py_counter += 1
except NameError:
  py_counter = 1

leWriteVariable('py_counter', str(py_counter))
lePrint('py_counter is ' + str(py_counter))

leSend('Command', 'py_counter is ' + str(py_counter))
leSend('Dataman1','+')
leSend('Dataman2','+')
state = leInquiryResponse('UR-5eDash','programstate',100)
lePrint('state = ' + state)
