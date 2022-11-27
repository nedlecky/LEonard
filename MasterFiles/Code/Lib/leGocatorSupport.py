# LMI Gocator Interface Code for LEonard
# Lecky Engineering LLC
# Author:      Ned Lecky
# Description: LMI Gocator support functions used in LEonard demo programs
# Use at your own risk and feel free to modify to suit your application

# General LMI Gocator Support Functions
import os
import math
import time
import random
from datetime import datetime
import csv

# adjust_alignment.py
# LMI Gocator Interface Code for LEonard
# Lecky Engineering LLC
# Author:      Ned Lecky
# Description: Moves the robot to drive the offsets from Gocator to 0
#
# This version:
#   Implements 4 versions of alignmnt- see code below
#
# Customize as needed for your application

# Moves robot to (hopefully!) drive alignment values to zero
# Version:
#  1: only adjusts translation
#  2: only adjusts rotation
#  3: adjusts in translation first, pauses 1S, and then does rotation
#  4: adjusts all 5 axes simultaneously but 3D calcs are not spot-on
def adjust_alignment(version):
  le_print('adjust_alignment starting...')
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

  le_print('adjust_alignment complete')


# start_operation
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
  move_linear('cp_origin')
  movel_rel_set_part_origin_here()


# end_operation
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


# offset_to_probe
# LMI Gocator Interface Code for LEonard
# Lecky Engineering LLC
# Author:      Ned Lecky
# Description: Move incrementally from a perfect Gocator alignment to a perfect (assumed) tool alignment
#
# This version:
#   Just offsets the robot to the assumed new location
#
# Customize as needed for your application
# Offset from Gocator 0,0,0 to tip of the allen wrench!
def offset_to_probe():
  movel_incr_part(-0.0235,0,0.165,0,0,0)


# write_results
# LMI Gocator Interface Code for LEonard
# Lecky Engineering LLC
# Author:      Ned Lecky
# Description: Writes the variables returned by the LMI Gocator to a CSV file for later use
#
# This version:
#   Assumes a long list of variables returned by your Gocator job! See column_name
#   Provides write_results(filename, tag_name) which creates if necessary, and appends results to filename
#   Results are converted from Gocator micron, degree*1000 units to float inches, degrees
#
# Customize as needed for your application

# timestamp and tag_name are passed in, the rest are assumed to be Python variables already sent by LEonard
def get_column_names():
  column_names = [
        "time_stamp",
        "tag_name",
        "gc_decision",
        "gc_offset_x",
        "gc_offset_y",
        "gc_offset_z",
        "gc_outer_radius",
        "gc_depth",
        "gc_bevel_radius",
        "gc_bevel_angle",
        "gc_xangle",
        "gc_yangle",
        "gc_cb_depth",
        "gc_axis_tilt",
        "gc_axis_orient",
        "gh_decision",
        "gh_offset_x",
        "gh_offset_y",
        "gh_offset_z",
        "gh_radius",
        "gp_xangle",
        "gp_yangle",
        "gp_z_offset",
        "gp_std_dev"
  ]
  return column_names

# Gocator returns distances in microns (or INVALID) and we'd like inches
def micron_to_inch_format(micron):
  ret = ''
  try:
    inch = float(micron) / 25400
    ret = '{:.4f}'.format(inch)
  except:
    ret = 'INVALID'
  return ret

# Gocator returns angles in deg*1000 (or INVALID) and we'd like degrees
def angle1000_format(angle1000):
  ret = ''
  try:
    angle = float(angle1000) / 1000
    ret = '{:.2f}'.format(angle)
  except:
    ret = 'INVALID'
  return ret

def create_row(tag_name):
  global gc_decision
  global gc_offset_x
  global gc_decision
  global gc_offset_x
  global gc_offset_y
  global gc_offset_z
  global gc_outer_radius
  global gc_depth
  global gc_bevel_radius
  global gc_bevel_angle
  global gc_xangle
  global gc_yangle
  global gc_cb_depth
  global gc_axis_tilt
  global gc_axis_orient
  global gh_decision
  global gh_offset_x
  global gh_offset_y
  global gh_offset_z
  global gh_radius
  global gp_xangle
  global gp_yangle
  global gp_z_offset
  global gp_std_dev
  
  now = datetime.now()
  time_stamp = now.strftime("%Y-%m-%dT%H:%M:%S.%f")
  row = [
    time_stamp,
    tag_name,
    gc_decision,
    micron_to_inch_format(gc_offset_x),
    micron_to_inch_format(gc_offset_y),
    micron_to_inch_format(gc_offset_z),
    micron_to_inch_format(gc_outer_radius),
    micron_to_inch_format(gc_depth),
    micron_to_inch_format(gc_bevel_radius),
    angle1000_format(gc_bevel_angle),
    angle1000_format(gc_xangle),
    angle1000_format(gc_yangle),
    micron_to_inch_format(gc_cb_depth),
    angle1000_format(gc_axis_tilt),
    angle1000_format(gc_axis_orient),
    gh_decision,
    micron_to_inch_format(gh_offset_x),
    micron_to_inch_format(gh_offset_y),
    micron_to_inch_format(gh_offset_z),
    micron_to_inch_format(gh_radius),
    angle1000_format(gp_xangle),
    angle1000_format(gp_yangle),
    micron_to_inch_format(gp_z_offset),
    micron_to_inch_format(gp_std_dev),
  ]
  return row

# Creates a new file (overwriting any existing) and places the heading labels in it
def start_file(filename):
  with open(filename, 'w') as f:
    writer = csv.writer(f, lineterminator='\r')
    writer.writerow(get_column_names())

# Collects the global LEonard return variables into a row and appends it to filename
def append_data(filename, tag_name):
  with open(filename, 'a') as f:
    writer = csv.writer(f, lineterminator='\r')
    row = create_row(tag_name)
    writer.writerow(row)

# Creates or appends latest Gocator data to filename
def write_results(filename, tag_name):
  #root = le_read_var('sysLEonardRoot').replace(os.sep, '/')
  root = sysLEonardRoot.replace(os.sep, '/')
  full_filename = root + '/Data/' + filename + '.csv'
  le_log_info('write_results(' + filename + ',' + tag_name + ') ==> ' + full_filename)

  if not os.path.exists(full_filename):
    start_file(full_filename)

  append_data(full_filename, tag_name)


######################################################################################
# TEST CODE
######################################################################################

def simulate_input():
  global gc_decision
  global gc_offset_x
  global gc_offset_y
  global gc_offset_z
  global gc_outer_radius
  global gc_depth
  global gc_bevel_radius
  global gc_bevel_angle
  global gc_xangle
  global gc_yangle
  global gc_cb_depth
  global gc_axis_tilt
  global gc_axis_orient
  global gh_decision
  global gh_offset_x
  global gh_offset_y
  global gh_offset_z
  global gh_radius
  global gp_xangle
  global gp_yangle
  global gp_z_offset
  global gp_std_dev
  gc_decision = 0
  gc_offset_x = random.uniform(-6000,6000)
  gc_offset_y = random.uniform(-6000,6000)
  gc_offset_z = random.uniform(-6000,6000)
  gc_outer_radius = random.uniform(6000,11000)
  gc_depth = random.uniform(6000,12000)
  gc_bevel_radius = random.uniform(6000.0,10000)
  gc_bevel_angle = random.uniform(80000,95000)
  gc_xangle = random.uniform(-10000.0,10000.0)
  gc_yangle = random.uniform(-10000.0,10000.0)

def go_test1(filename):
  start_file(filename)

  for i in range(0,10):
    simulate_input()
    append_data(filename, 'demo')


def go_test2():
  new_file = 'new_file.csv'
  growing_file = 'growing_file.csv'
  
  try:
    os.remove(new_file)
  except:
    ()

  for i in range(0,10):
    simulate_input()
    write_results(new_file, 'new_tag')
    write_results(growing_file, 'grow_tag')

#go_test1('demo.csv')
#go_test2()
