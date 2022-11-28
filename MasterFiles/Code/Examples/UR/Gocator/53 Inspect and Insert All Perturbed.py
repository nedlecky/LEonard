# 53 Inspect and Insert All Perturbed.py
import os
import random
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

# Random +/- 0.25"
dx = random.uniform(-0.0064, 0.0064)
dy = random.uniform(-0.0064, 0.0064)
dz = random.uniform(-0.0064, 0.0064)
movel_incr_part(dx, dy, dz, 0, 0, 0)

# Random +/- 5 degrees
drx = random.uniform(-0.0873, 0.0873)
dry = random.uniform(-0.0873, 0.0873)
movel_incr_tool(0,0,0,drx,dry,0)

gocator_trigger(1000)
write_results(output_datafile, ID + '_initial')

#prompt('align 3?')
adjust_alignment(3)
gocator_trigger(1000)
write_results(output_datafile, ID + '_adjust_3-1')

#prompt('align 3-2?')
adjust_alignment(3)
gocator_trigger(1000)
write_results(output_datafile, ID + '_adjust_3-2')

#prompt('align 1?')
adjust_alignment(1)
gocator_trigger(1000)
write_results(output_datafile, ID + '_adjust_1')

# Insertion Routine
offset_to_probe()
#prompt('Hit enter to insert')
movel_incr_part(0,0,0.030,0,0,0)
movel_incr_part(0,0,-0.030,0,0,0)
movel_incr_part(0,0,0.030,0,0,0)
movel_incr_part(0,0,-0.030,0,0,0)

ret()
