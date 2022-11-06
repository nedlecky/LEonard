# General Gocator support functions
import csv

def start_test():
  leClearVariables()
  global filename
  filename = leReadVar('LEScriptFilename')
  move_linear('cp_origin')
  movel_rel_set_part_origin_here()

def finish_test():
  move_linear('cp_origin')
  
# Offset from Gocator 0,0,0 to tip of the allen wrench!
def offset_to_probe():
  movel_incr_part(-0.0235,0,0.165,0,0,0)

def file_loader(filename):
  global file_rows
  global file_row_count
  
  root = leReadVar('LEonardRoot')
  csv_file = open(root + '/Data/HoleData.csv')
  csv_reader = csv.DictReader(csv_file)
  file_rows = []
  file_row_count = 0
  for row in csv_reader:
    file_rows.append(row)
    file_row_count = file_row_count + 1


lePrint('Support loaded')