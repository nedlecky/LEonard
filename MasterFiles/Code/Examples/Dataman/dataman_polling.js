// dataman_polling.js
// Cognex Dataman polling example

count = 0
repeat:
le_send('Dataman1','+')
le_send('Dataman2','+')
le_print('DM1=' + DM1_result + ' ' + DM1_counter)
le_print('DM2=' + DM2_result + ' ' + DM2_counter)
count++
jumpif(count < 10,'repeat')
