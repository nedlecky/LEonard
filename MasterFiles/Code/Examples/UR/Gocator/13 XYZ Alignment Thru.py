# 13 XYZ Alignment Thru.py
import os
import random
exec_python('Lib/leGocatorSupport.py')

output_datafile = os.path.splitext(sysSequenceFilename)[0]

start_operation()

count=5
loop:
movel_rel_part(0,0,0,0,0,0)
movel_rel_part(0.025,-0.108,0,0,0,0)

# Random +/- 0.25"
dx = random.uniform(-0.0064, 0.0064)
dy = random.uniform(-0.0064, 0.0064)
dz = random.uniform(-0.0064, 0.0064)
movel_incr_part(dx,dy,dz,0,0,0)

gocator_trigger(1000)
write_results(output_datafile, 'random_0.25in_offset')

adjust_alignment(1)
gocator_trigger(1000)
write_results(output_datafile, 'adjust_1')

count -= 1
jumpif(count > 0, 'loop')

end_operation()
