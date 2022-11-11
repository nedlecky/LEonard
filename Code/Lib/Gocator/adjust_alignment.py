# adjust_alignment.py
# LMI Gocator Interface Code for LEonard
# Lecky Engineering LLC
# Author:      Ned Lecky
# Description: Moves the robot to drive the offsets from Gocator to 0
#
# This version:
#   Implements 4 versions of alignemnt- see code below
#
# Customize as needed for your application

# Moves robot to (hopefully!) drive alignment values to zero
# Version:
#  1: only adjusts translation
#  2: only adjusts rotation
#  3: adjusts in translation first, pauses 1S, and then does rotation
#  4: adjusts all 5 axes suimulataneously but 3D calcs are not spot-on

import math
import time

def adjust_alignment(version):
  le_print('gocator_adjust_py starting...')
  dx = 0.0
  dy = 0.0
  dz = 0.0
  drx = 0.0
  dry = 0.0

  # Assumes using counterbore and thruhole tools. Uses counterbore if result, else tries thruhole
  # NOTE: dz and drx are negated below to match sensor/robot alignment!
  if gc_decision == '0':
    le_print('Using counterbore')
    dx = float(gc_offset_x) / 1e6
    dy = float(gc_offset_y) / 1e6
    dz = -float(gc_offset_z) / 1e6
    drx = -float(gc_xangle) / 1e3
    dry = float(gc_yangle) / 1e3
  elif gh_decision == '0':
    le_print('Using thruhole')
    dx = float(gh_offset_x) / 1e6
    dy = float(gh_offset_y) / 1e6
    dz = -float(gh_offset_z) / 1e6
    drx = -float(gp_xangle) / 1e3
    dry = float(gp_yangle) / 1e3
  else:
    le_print('No result found')
    return

  abs_dx = abs(dx)
  abs_dy = abs(dy)
  abs_dz = abs(dz)
  abs_drx = abs(drx)
  abs_dry = abs(dry)
  drx_rad = math.radians(drx)
  dry_rad = math.radians(dry)

  if version == 1:
    le_print('Version 1 Translation Only')
    if abs_dx > 0.020 or abs_dy > 0.020 or abs_dz > 0.020:
      le_print('Excessive gocator_adjust (' + str(dx) + ',' + str(dy) + ',' + str(dz) + ',0,0,0)')
    else:
      movel_incr_part(dx,dy,dz,0,0,0)
  elif version == 2:
    le_print('Version 2 Rotation Only')
    if abs_drx > 15 or abs_dry > 15:
      le_print('Excessive gocator_adjust (0,0,0,' + str(drx) + ',' + str(dry) + ',0)')
    else:
      movel_incr_tool(0,0,0,drx_rad,dry_rad,0)
  elif version == 3:
    le_print('Version 3 translate, Pause 1sec, Rotate')
    if abs_dx > 0.020 or abs_dy > 0.020 or abs_dz > 0.020 or abs_drx > 15 or abs_dry > 15:
      le_print('Excessive gocator_adjust (' + str(dx) + ',' + str(dy) + ',' + str(dz) + ',' + str(drx_rad) +',' + str(dry_rad) + ',0)')
    else:
      movel_incr_part(dx,dy,dz,0,0,0)
      time.sleep(1)
      movel_incr_tool(0,0,0,drx_rad,dry_rad,0)
  elif version == 4:
    le_print('Version 4 All 5 axes at once- not quite accurate!')
    if abs_dx > 0.020 or abs_dy > 0.020 or abs_dz > 0.020 or abs_drx > 15 or abs_dry > 15:
      le_print('Excessive gocator_adjust (' + str(dx) + ',' + str(dy) + ',' + str(dz) + ',' + str(drx) +',' + str(dry) + ',0)')
    else:
      movel_incr_tool(dx,dy,dz,drx_rad,dry_rad,0)

  le_print('gocator_adjust_py complete')
