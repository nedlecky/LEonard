# 11 Robot Repeatability.py
import os
exec_python('Lib/leGocatorSupport.py')

output_datafile = os.path.splitext(sysSequenceFilename)[0]

start_operation()

count = 5
loop:
movel_rel_part(0,0,0,0,0,0)
movel_rel_part(0.025,0.100,0,0,0,0)

gocator_trigger(1000)
write_results(output_datafile, 'move_and_return')
count -= 1
jumpif(count > 0, 'loop')

end_operation()
