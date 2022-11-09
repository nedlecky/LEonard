if(typeof nGocatorTriggers== 'undefined')
  nGocatorTriggers= 1;
else
  nGocatorTriggers= nGocatorTriggers+ 1;

le_print('nGocatorTriggers = ' + nGocatorTriggers);

leWriteVariable('nGocatorTriggers',nGocatorTriggers)

leExec('gocator_trigger(1000)')

