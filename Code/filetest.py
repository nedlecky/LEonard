import random

a = random.uniform(3,4)

lePrint(str(a))

import csv
root = leReadVar('LEonardRoot')
csv_file = open(root + '/Data/HoleData.csv')
csv_reader = csv.DictReader(csv_file)

rows = []
row_count = 0
for row in csv_reader:
  rows.append(row)
  row_count = row_count + 1

lePrint(str(row_count))
lePrint(str(rows[2]))




