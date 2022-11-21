# basic_comm.py
try:
  mycounter += 1
except NameError:
  mycounter = 1

le_write_var('mycounter', str(mycounter))

le_print('mycounter is ' + str(mycounter))

def to_client(msg):
    le_send('Command', msg)

def mul(a, b):
  return a * b

to_client('mycounter is ' + str(mycounter))
c = mul(3,5)
le_print('c=' + str(c))
to_client('c is ' + str(c))

