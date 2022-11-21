// simple_comm.js
if(typeof js_counter== 'undefined')
  js_counter= 1;
else
  js_counter= js_counter+ 1;

le_write_var('js_counter', js_counter)

le_print('js_counter is ' + js_counter)

function to_client(msg) {
    le_send('Command', msg)
  }

function mul(a, b) {
  return a * b
}

to_client('js_counter is ' + js_counter)
c = mul(3,5)
le_print('c=' + c)
to_client('c is ' + c)

state = le_ask('UR-5eDash', 'programstate', 100)
le_print('UR state = ' + state)
