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

## array
```
string[] fraudulentOrderIDs = new string[3]
```
- `new` creates new instance of an array in the computer's memory
- `string[3]` = can hold 3 string values

if try to add beyond the length of the array will get an error `System.IndexOutOfRangeException`

## readable code
best to write code that's clear and easy to understand

working in a team
- writing code that someone else will be maintaining

### choose variable names that follow rules and conventions
variable name rules
- using underscore to start a variable name is typically reserved for private instance fields
- must NOT be a C# keyword

variable name conventions
- use **camel case**
- var names should be descriptive and meaningful
- should be one or more entire words appended together (don't use contractions)
- should't include the data type of the var

the rules avove are for local variables
- vars that is scoped within the body of the method
- variable in a console app that uses top-level statements

classes have their own associated conventions

### code comments
- when leaving a note about the intent of a passage of code
    - describe the purpose or the thought process
- temporarily remove code from app to try a different approach
- adding a message like a `TODO`
- best to use comments for higher level ideas and not to add comments about how an individual line of code works
- low quality comments
    - merely explain how C# or methods of the .NET library work
    - don't provide context to the problem being solved by the code
    - reader doesn't gain any insight into the purpose of the code as it relates to the larger system

### using whitespace to improve readability
- code blocks separated to make boundaries easier to visually discern
- separate declaration of variables to code lines used to assign values to variables
    - separation makes it easier to see how the variable is used in the code
- group code lines that includes related variables
    - draws the eyes to similarities and helps to expose the differences
- group related statements of nested `if` statements
    - related by purpose rather than appearance
    - focused on the value achieved
- `{` and `}` create code blocks
    - should be placed on a separate line
    - boundaries visible and readable
- line up the code block symbols under the keyword they belong to
    - easy to understand where the code block begins and ends

### readability of single-line from if statements
```
if (flag) Console.WriteLine(flag);
```
conventions:
- never use single line form
- using braces is always accepted
    - required if 
        - any block in `if/else if/ else` compoind statement use braces
        - single statement body spans multiple lines
- braces may be omitted only if the body of every block associated with the `if/ else if/ else` statement is placed on a single line

## switch
- best used when have a single value that you want to match against many possible values.
- for any given match, you need to execute a couple of lines of code at most.

## do-while and while loop
`do-while` ensures that the loop will iterate at least once
- might continue to iterate based on a boolean expression

`while` statement evaluates a boolean expression first

# floating point types
- `float` and `double` stores values as binary
    - useful because large numbers can be stored using a small memory footpirnt
    - should only be used when an approximation is useful
    - math on binary floating point math is an approximation of the real value

- `decimal` stored in decimal (base 10) format
    - when need a more precise answer
    - large memory footprint
    - used when working with financial data or any scenario where you need an accurate result from a calculation

**E notation**
- times 10 raised to the power of
- `5E+2` = 5 * 10^2 = 500

# reference types
```
int[] data;
```
- at this point, `data` is merely a variable that could hold a reference to a value in the heap
- it is a _null reference_ because not pointing to a memory address

```
data = new int[3];
```
- create an instance of `int` array using the `new` keyword
- `new` informs .NET Runtime to create an instance of `int` array
- coordinate to stroe the array sized for 3 int values in memory
- the .NET Runtime returns a memory address of the new `int` array
- the memory address is then stored in the variable
- default value for `int` = 0 => the `int` array's elements default to the value `0`

# changing data types
`Convert` class is best for converting fractuinal numbers into whole numbers because it rounds up the way you would expect
- casting `(int)1.5m` truncates into 1
- converting `Convert.ToInt32(1.5m)` rounds up to 2

to convert int to string, use `TryParse()` when possible

`TryParse()`
- attempts to parse a string into a given numeric data type
- if successful, stores the converted value in an out parameter
- returns a `bool` to indicate whether the action succeded or failed