import random

a = random.uniform(3,4)

le_print(str(a))

import csv
root = leReadVar('LEonardRoot')
csv_file = open(root + '/Data/HoleData.csv')
csv_reader = csv.DictReader(csv_file)

rows = []
row_count = 0
for row in csv_reader:
  rows.append(row)
  row_count = row_count + 1

le_print(str(row_count))
le_print(str(rows[2]))




