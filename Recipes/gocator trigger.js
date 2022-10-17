if(typeof nGocatotTriggers== 'undefined')
  nGocatotTriggers= 1;
else
  nGocatotTriggers= nGocatotTriggers+ 1;

lePrint('nGocatotTriggers = ' + nGocatorTriggers);

leWriteVariable('nGocatotTriggers',nGocatotTriggers)

leExec('gocator_trigger(1000)')

