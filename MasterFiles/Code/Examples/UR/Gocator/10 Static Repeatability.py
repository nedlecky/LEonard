# 10 Static Repeatability.py
import os
exec_python('Lib/leGocatorSupport.py')

output_datafile = os.path.splitext(sysSequenceFilename)[0]

start_operation()

movel_rel_part(0.025,0.100,0,0,0,0)

count = 5
loop:
gocator_trigger(1000)
write_results(output_datafile,'static_pose')
count -= 1
jumpif(count > 0, 'loop')

end_operation()
