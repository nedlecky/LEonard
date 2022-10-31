if(typeof js_counter== 'undefined')
  js_counter= 1;
else
  js_counter= js_counter+ 1;

leWriteVariable('js_counter',js_counter)

lePrint('js_counter is ' + js_counter)

leSend('me','+')



