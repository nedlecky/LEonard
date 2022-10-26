if(typeof nGocatorTriggers== 'undefined')
  nGocatorTriggers= 1;
else
  nGocatorTriggers= nGocatorTriggers+ 1;

lePrint('nGocatorTriggers = ' + nGocatorTriggers);

leWriteVariable('nGocatorTriggers',nGocatorTriggers)

leExec('gocator_trigger(1000)')

