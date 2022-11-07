# LEonard Add-ons for interfacing with CSV files
import csv

def DictRows(filename):
  csv_file = open(filename)
  csv_reader = csv.DictReader(csv_file)
  file_rows = []
  for row in csv_reader:
      file_rows.append(row)

  return file_rows  
