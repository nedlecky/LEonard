//reset();

if(typeof counter == 'undefined')
  counter = 1;
else
  counter = counter + 1;

lePrint('Ran Counter=' + counter);

leWriteVariable('counter',counter)
leExec('prompt(abc)')
lePrompt('ppp')

rg = leReadVariable('robot_geometry');

