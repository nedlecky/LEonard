//reset();

if(typeof js_counter== 'undefined')
  js_counter= 1;
else
  js_counter= js_counter+ 1;

leWriteVariable('js_counter',js_counter);

lePrint('js_counter is ' + js_counter)

leSend('Command', 'js_counter is ' + js_counter)
leSend('Dataman1','+')
leSend('Dataman2','+')
state = leInquiryResponse('UR-5eDash','programstate',100)
lePrint('state = ' + state)



