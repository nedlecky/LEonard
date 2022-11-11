# offset_to_probe.py
# LMI Gocator Interface Code for LEonard
# Lecky Engineering LLC
# Author:      Ned Lecky
# Description: Mmove incrementally from a perfect Gocator alignment to a perfect (assumed) tool alignment
#
# This version:
#   Just offsets the robot to the assumed new location
#
# Customize as needed for your application

  
# Offset from Gocator 0,0,0 to tip of the allen wrench!
def offset_to_probe():
  movel_incr_part(-0.0235,0,0.165,0,0,0)
