Convert .csv files created in NetLogo to correct format
=======================

This is a simple C# utility to convert output from NetLogo into a properly formatted .csv file.

For example, the NetLogo code:

```NetLogo
let spacer ","
file-open "test.csv"
file-print (list behaviorspace-run-number spacer ticks spacer (count patches))
file-close
```

will produce a .csv file containing:
    [0 , 0 , 25 ]

Running NetLogo CSV Converter.exe in the same directory as test.csv will convert the contents to
    0,0,25

The program reads all .csv files in the same directory as the executable.

Parallel mode
=============
By default, the program converts each .csv file in its directory in a single thread. It can convert multiple files in parallel by executing the program with any command line argument (doesn't matter what).
WARNING: I haven't implemented multithreading in any clever way so if you have lots of files in the same directory, the program might crash.
