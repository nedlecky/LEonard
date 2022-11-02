try:
  py_counter += 1
except NameError:
  py_counter = 1

leWriteVariable('py_counter', str(py_counter))
lePrint('py_counter is ' + str(py_counter))
def mp(s):
  leSend('Command', str(s))

leSend('Command', 'py_counter is ' + str(py_counter))
mp("Howdy")
leSend('Dataman1','+')
leSend('Dataman2','+')
state = leInquiryResponse('UR-5eDash','programstate',100)
lePrint('state = ' + state)

