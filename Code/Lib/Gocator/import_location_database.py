# import_location_database.py
# LMI Gocator Interface Code for LEonard
# Lecky Engineering LLC
# Author:      Ned Lecky
# Description: Import a CSV file of inspection locations to be used to drive the robot
#
# This version:
#   Reads filename in as a CSV and return all rows as dictionary entries
#
# Customize as needed for your application

import csv

def import_location_database(filename):
  csv_file = open(filename)
  csv_reader = csv.DictReader(csv_file)
  file_rows = []
  for row in csv_reader:
      file_rows.append(row)

  return file_rows  
