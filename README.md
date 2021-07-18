# Car Park
Simple project written in C#

To run it, simply write and execute the `dotnet run` command. How it works depends on the arguments the user provided.
1. If there are no arguments or less than nine, the console will print example instance of the main Vehicle class.
2. If there will be provided one argument, it will be treated as a file name in which the output data should be saved to. Those would be plurar and also purely demonstrational.
3. If there will be provided nine or more arguments, the returned output will be Vehicle instance made with them. The formula goes as below:
  `dotnet run "<price-per-day>" "<customer-name>" "2020 01 05"<date-of-rent> "2020 01 10"<date-of-return> "2018 12 30"<date-of-production> "<value>" "<mileage>" "<brand>" "<model>" "<file-name>"(the last is optional, this tenth argument is the file, in which the data will be stored)`
