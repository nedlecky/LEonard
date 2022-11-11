# start_operation.py
# LMI Gocator Interface Code for LEonard
# Lecky Engineering LLC
# Author:      Ned Lecky
# Description: General startup called at start of in all LMI Gocator demos
#
# This version:
#   Clears all LEonard variables
#   Sets global 'filename' to the name of the executing sequence in LEonard to help in pairing output with input
#   Moves to the (hopefully predefined) position 'cp_origin' and sets that as the part origin
#
# Customize as needed for your application
def start_operation():
  le_clear_variables()
  global filename
  filename = le_read_var('LEScriptFilename')
  move_linear('cp_origin')
  movel_rel_set_part_origin_here()
