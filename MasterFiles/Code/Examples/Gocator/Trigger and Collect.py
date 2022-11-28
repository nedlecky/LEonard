# Trigger and Collect.py
import os
exec_python('Lib/leGocatorSupport.py')

output_datafile = os.path.splitext(sysSequenceFilename)[0]

count = 5
loop:
gocator_trigger(0)
write_results(output_datafile,'example')
count -= 1
jumpif(count > 0, 'loop')
