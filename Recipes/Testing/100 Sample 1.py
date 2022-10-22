lePrint('Running 100 Sample1.py...')

a = 5
b = 7.12
c = a * b
print(a,b,c)
lePrint(str(a)+' '+str(b)+' '+str(c))

leWriteVariable('py1',str(b))

leExec('py1 += 13')