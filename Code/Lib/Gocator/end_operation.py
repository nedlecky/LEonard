# end_operation.py
# LMI Gocator Interface Code for LEonard
# Lecky Engineering LLC
# Author:      Ned Lecky
# Description: Cleanup called at end of all LMI Gocator demos
#
# This version:
#   Return robot position to 'cp_origin'
#
# Customize as needed for your application

def end_operation():
  move_linear('cp_origin')
