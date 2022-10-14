//reset();

if(typeof counter == 'undefined')
  counter = 1;
else
  counter = counter + 1;

print('Ran Counter=' + counter);

LeWriteVariable('counter',counter)
LeExec('prompt(abc)')

rg = LeReadVariable('robot_geometry');

