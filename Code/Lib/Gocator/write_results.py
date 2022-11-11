# write_results.py
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

import csv
import random
from datetime import datetime
import os

# timestamp and tag_name are passed in, the rest are assumed to be Python variables already sent by LEonard
column_name = [
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

def micron_to_inch_format(micron):
  inch = float(micron) / 25400
  return f'{inch:.4f}'

def angle1000_format(angle1000):
  angle = float(angle1000) / 1000
  return f'{angle:.2f}'

def create_row(tag_name):
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
    micron_to_inch_format(gc_bevel_angle),
    angle1000_format(gc_xangle),
    angle1000_format(gc_yangle),
  ]

  return row

# Creates a new file (overwriting any existing) and places the heading labels in it
def start_file(filename):
  with open(filename, 'w') as f:
    writer = csv.writer(f, lineterminator='\r')
    writer.writerow(column_name)

# Collects the global LEonard return variables into a row and appends it to filename
def append_data(filename, tag_name):
  with open(filename, 'a') as f:
    writer = csv.writer(f, lineterminator='\r')
    row = create_row(tag_name)
    writer.writerow(row)


# Creates or appends latest Gocator data to filename
def write_results(filename, tag_name):
  if not os.path.exists(filename):
    start_file(filename)

  append_data(filename, tag_name)

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
def test1(filename):
  start_file(filename)

  for i in range(0,10):
    simulate_input()
    append_data(filename, 'demo')


def test2():
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

test1('demo.csv')
test2()
