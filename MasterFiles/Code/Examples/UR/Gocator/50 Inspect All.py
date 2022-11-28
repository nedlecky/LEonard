# 50 Inspect All.py
import os
import csv_addons as cp
exec_python('Lib/leGocatorSupport.py')

output_datafile = os.path.splitext(sysSequenceFilename)[0]

start_operation()

datafile = sysLEonardRoot + '/Data/HoleData.csv'
rows = cp.import_location_database(datafile)

row = 1
next_hole:
le_print(str(rows[row]))
ID = rows[row]['ID']
X = float(rows[row]['X']) * 0.0254
Y = float(rows[row]['Y']) * 0.0254
Z = float(rows[row]['Z']) * 0.0254
le_print('Inspecting ID=' + ID)
call('inspect')

row += 1
jumpif(row < len(rows), 'next_hole')

end_operation()
stop()

inspect:
movel_rel_part(X,Y,Z,0,0,0)

gocator_trigger(1000)
write_results(output_datafile, ID + '_initial')

adjust_alignment(3)
gocator_trigger(1000)
write_results(output_datafile, ID + '_adjust_3-1')

adjust_alignment(3)
gocator_trigger(1000)
write_results(output_datafile, ID + '_adjust_1-2')

adjust_alignment(1)
gocator_trigger(1000)
write_results(output_datafile, ID + '_adjust_1')

ret()
