# C# tutorial

create console app
```
dotnet new console -o ./CsharpProjects/TetProject
```
- `dotnet` = driver
- `new console` = command
- `-o ./CsharpProjects/TestProject` = command arguments
    - optional
    - can be used to provide additional information

- `TestProject` = name of your `.csproj` file

the `Program.cs` file in the project folder is the file containing the C# code
- before running a `build` or `run` command, ensure that the Terminal is open to your project folder

## compile a build of your app
```
dotnet build
```

- build the project and its dependencies into a set of binaries
- binaries include the project's code in IL (intermediate language) files with a .dll extension

run the application
```
dotnet run
```
- runs the source code
- convenient option to run app from the source code with one command
- the command depends on the dotnet build command to build the code

## .NET Class Library
- collection of classes containing methods
- class = container for methods
- even data types are part of the .NET class library
    - provide built-in methods

don't need to research classes and methods without a reason
- can search after encountering a problem
- find sample code you can try

calling methods
```
Console.WriteLine("Hello World!")
```
- `Console` = class name
- `.` = member access operator
- `WriteLine` = method name
- `()` = method invocation operator
- `"Hello World!"` = specify the arguments that are passed to the method between the parentheses

depending on how the developer designed and implemented the given method, may also need to:
- pass additional values as input parameters
- accept a return value

## stateful vs stateless methods
```
Random dice = new Random();
int roll = dice.Next(1, 7);
Console.WriteLine(dice.Next(1,7));
```

**state** = condition of the execution at a specific moment in time

executing code line by line = values stored in variables
- during execution, the current state of the application = collection of all values stored in memory

some methods don't rely on the current state of the app to work
- **stateless methods**  = can work without referencing or changing any values already stored in memory
- aka static methods
- `Console.WriteLine()` doesn't rely on any values stored in memory
    - performs function and finishes without impacting the state of the app in any way

other methods must have access to the state of the app to work properly
- **stateful methods** = rely on values stored in memory by previous line of code that have already been executed
- or modify the state of the app by updating values or storing new values in memory
- aka instance methods
- keep track of their state in _fields_
    - variables defined on the class
- each new instance of the class gets its own copy of those fields to store the state

a single class can support both stateful and stateless methods
- when need to call stateful methods => first create an instance of the class
    - so that method can access state

creating an instance of a class
- instance of class = _object_
- create new instance with `new` operator
    - first request an address in the computer memory to store a new object based on the class
    - creates a new object, and stores it at the memory address
    - returns the memory address => can be saved in the `dice` object

- the `dice` object is used like a variable that stores the state of the `Random` class
    - when `Next()` is called = use the state stored in the `dice` object

can instantiate an object without having to repeat the tupe name
```
Random dice = new()
```

how to determine if you need to create an instance of a class before calling its methods?
- consult the documentation
- attempt to access the method directly

## return values

**void methods** = don't return a value when they finish

a method can be designed to return any data type
- possible to call the method without using the return value (but piontless)

**method signature** = define the number of parameters that the method will accept
- the data type of each parameter