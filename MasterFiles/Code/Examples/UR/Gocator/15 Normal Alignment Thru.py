# 15 Normal Alignment Thru.py
import os
import random
exec_python('Lib/leGocatorSupport.py')

output_datafile = os.path.splitext(sysSequenceFilename)[0]

start_operation()

count=5
loop:
movel_rel_part(0,0,0,0,0,0)
movel_rel_part(0.025,-0.108,0,0,0,0)

# Random +/- 10 degrees
drx = random.uniform(-0.175, 0.175)
dry = random.uniform(-0.175, 0.175)
movel_incr_tool(0,0,0,drx,dry,0)

gocator_trigger(1000)
write_results(output_datafile, 'random_10deg_tilt')

adjust_alignment(2)
gocator_trigger(1000)
write_results(output_datafile, 'adjust_2')

count -= 1
jumpif(count > 0, 'loop')

end_operation()
