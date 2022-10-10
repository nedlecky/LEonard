print("Starting...");
if(typeof a == 'undefined') a = 5;
else a = a + 1;

b = 7.12;
c = a * b;
aStr = "A string " + a;
print(c);
logInfo(c);
logError("Test error message");

for(name in this) {
  print(name + " " + typeof name + " " + this[name]);
  logInfo(name + " " + typeof name + " " + this[name]);
}
print(b)