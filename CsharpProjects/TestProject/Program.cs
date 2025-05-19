/*

Random dice = new();

int[] diceResults = [];
int number;

for (int i = 0; i < 3; i++)
{
    number = dice.Next(1, 7);
    diceResults = [.. diceResults, number];

}

var duplicates = diceResults
    .GroupBy(d => d)
    .Where(g => g.Count() > 1)
    .Select(g => new { Roll = g.Key, Count = g.Count() })
    .ToList();

int total = diceResults.Sum();

Console.Write("Dice roll: ");
for (int j = 0; j < diceResults.Length; j++)
{
    Console.Write(diceResults[j]);
    if (j != diceResults.Length - 1)
    {
        Console.Write(" + ");
    }
    else
    {
        Console.Write(" = ");
    }
}

Console.WriteLine(diceResults.Sum());
foreach (var item in duplicates)
{
    if (item.Count <= 2)
    {
        Console.WriteLine("You rolled doubles! +2 bonus to total!");
        total += 2;
    }
    else
    {
        Console.WriteLine("You rolled triples! +6 bonus to total!");
        total += 6;
    }
}

Console.WriteLine();
if (total >= 16)
{
    Console.WriteLine("You win a new car!");
}
else if (total >= 10)
{
    Console.WriteLine("You win a new laptop!");
}
else if (total == 7)
{
    Console.WriteLine("You win a trip for two!");
}
else
{
    Console.WriteLine("You win a kitten!");
}


Random random = new Random();
int daysUntilExpiration = random.Next(12);
int discountPercentage = 0;

if (daysUntilExpiration == 0)
{
    Console.WriteLine("Your subscription has expired");
}
else if (daysUntilExpiration is >= 1 and <= 5)
{
    if (daysUntilExpiration == 1)
    {
        Console.WriteLine("Your subscription expires within a day!");
        discountPercentage = 20;
    }
    else
    {
        Console.WriteLine($"Your subscription expires in {daysUntilExpiration} days.");
        discountPercentage = 10;
    }

    Console.WriteLine($"Renew now and save {discountPercentage}%!");
}
else
{
    Console.WriteLine("Your subscription will expire soon. Renew now!");
}


string[] fraudulentOrderIDs = [
    "B123",
    "C234",
    "A345",
    "C15",
    "B177",
    "G3003",
    "C235",
    "B179"
];

foreach (var orderIDs in fraudulentOrderIDs)
{
    if (orderIDs.StartsWith("B")) {
        Console.WriteLine(orderIDs);
    }
}

Random random = new();
string suffix = 2.ToString("000"); // pad the number with zeroes
Console.WriteLine(suffix);

Dictionary<string, List<int>> students = new()
{
    {"sophia", [90, 86, 87, 98, 100, 94, 90]},
    {"andrew", [92, 89, 81, 96, 90, 89]},
    {"emma", [90, 85, 87, 98, 68, 89, 89, 89]},
    {"logan", [90, 95, 87, 88, 96, 96]},
    {"becky", [92, 91, 90, 91, 92, 92, 92 ]},
    {"chris", [84, 86, 88, 90, 92, 94, 96, 98 ]},
    {"eric", [ 80, 90, 100, 80, 90, 100, 80, 90 ]},
    {"gregor", [91, 91, 91, 91, 91, 91, 91]}
};

Dictionary<int, char> grades = new()
{
    {9, 'A'},
    {8, 'B'},
    {7, 'C'},
    {6, 'D'}
};
string gradeSymbol = "";

Console.WriteLine("{0,-20} {1,0}\n", "Student", "Grade");

foreach (var student in students)
{
    float averageGrade = (float)student.Value.Sum() / student.Value.ToArray().Length;
    if ((int)averageGrade % 10 > 6)
    {
        gradeSymbol = "+";
    }
    else if ((int)averageGrade % 10 < 3)
    {
        gradeSymbol = "-";
    }
    else
    {
        gradeSymbol = "";
    }

    Console.WriteLine("{0,-20} {1,-8:0.##} {2,0}",
    student.Key.First().ToString().ToUpper() + student.Key[1..],
    averageGrade,
    (int)averageGrade / 10 > 5 ?
        averageGrade == 100 ?
            "A+" :
            grades[(int)averageGrade / 10] + gradeSymbol
        : "F");
}

Console.WriteLine("\nPress the Enter key to continue");

Random random = new();
Console.WriteLine((random.Next(0,2) == 0) ? "Heads" : "Tails");

string permission = "Manager";
int level = 19;

if (permission.Contains("Admin"))
{
    Console.WriteLine($"Welcome, {(level > 55 ? "Super Admin" : "Admin")} user.");
}
else if (permission.Contains("Manager") && level >= 20)
{
    Console.WriteLine("Contact and Admin for access.");
}
else
{
    Console.WriteLine("You do not have sufficient privileges.");
}

int[] numbers = [4, 8, 15, 16, 23, 42];
int total = 0;
bool found = false;

foreach (int number in numbers)
{
    total += number;

    if (number == 42)
        found = true;
}

if (found) 
    Console.WriteLine("Set contains 42");



Console.WriteLine($"Total: {total}");

int employmentLevel = 200;
string employeeName = "John Doe";

string title = "";

title = employmentLevel switch
{
    > 300 or > 200 => "Senior Associate",
    _ => "Junior Associate",
};

Console.WriteLine($"{employeeName}, {title}");

string sku = "01-MN-L";

string[] product = sku.Split('-');

string type = product[0] switch
{
    "01" => "Sweat shirt",
    "02" => "T-Shirt",
    "03" => "Sweat pants",
    _ => "Other",
};

string color = product[1] switch
{
    "BL" => "Black",
    "MN" => "Maroon",
    _ => "White",
};

string size = product[2] switch
{
    "S" => "Small",
    "M" => "Medium",
    "L" => "Large",
    _ => "One Size Fits All",
};

Console.WriteLine($"Product: {size} {color} {type}");

for (int i = 1; i < 21; i++)
{
    string rules = i switch
    {
        int n when n % 3 == 0 && n % 5 == 0 => " - FizzBuzz",
        int n when n % 3 == 0 => " - Fizz",
        int n when n % 5 == 0 => " - Buzz",
        _ => "",
    };
    Console.WriteLine($"{i}{rules}");
}

int heroHealth = 10;
int monsterHealth = 10;

Random random = new();

do
{
    int heroAttack = random.Next(1, 11);
    monsterHealth -= heroAttack;

    Console.WriteLine("Hero attacks!");
    Console.WriteLine($"Monster took {heroAttack} damage!");

    if (monsterHealth <= 0) continue;

    Console.WriteLine($"Monsther have {monsterHealth}HP left");

    int monsterAttack = random.Next(1, 11);
    heroHealth -= monsterAttack;

    Console.WriteLine("Monster attacks!");
    Console.WriteLine($"Hero took {monsterAttack} damage!");

    if (heroHealth <= 0) continue;

    Console.WriteLine($"Hero have {heroHealth}HP left");

} while (heroHealth > 0 && monsterHealth > 0);

Console.WriteLine($"{(heroHealth > monsterHealth ? "Hero" : "Monster")} wins!");


Console.WriteLine("Enter a number between 5 and 10:");
bool validEntry = int.TryParse(Console.ReadLine(), out int userInput);
while (!validEntry || (validEntry && (userInput is < 5 or > 10)))
{
    if (!validEntry)
        Console.WriteLine("Sorry, you entered an invalid number, please try again");
    else
        Console.WriteLine($"You entered {userInput}. Please enter a valid number between 5 and 10.");

    validEntry = int.TryParse(Console.ReadLine(), out userInput);
}

Console.WriteLine($"Your input value({userInput}) has been accepted.");


string[] userRole = ["administrator", "manager", "user"];
string listOfValidRoles = "";
for (int i = 0; i < userRole.ToArray().Length; i++)
{
    string role = userRole[i].First().ToString().ToUpper() + userRole[i][1..];
    if (i != userRole.ToArray().Length - 1)
    {
        listOfValidRoles += $"{role}, ";
    }
    else
    {
        listOfValidRoles += $"or {role}";
    }
}
Console.WriteLine($"Enter your role name ({listOfValidRoles})");

string? userInput = Console.ReadLine();

while (userInput == null || !userRole.Contains(userInput.Trim().ToLower()))
{
    Console.WriteLine($"The role name you entered, \"{userInput}\" is not valid. Enter your role name ({listOfValidRoles})");
    userInput = Console.ReadLine();
}

Console.WriteLine($"Your input value ({userInput.Trim().First().ToString().ToUpper() +  userInput.Trim()[1..].ToLower()}) has been accepted.");


string[] myStrings = ["I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices"];

foreach (var strings in myStrings)
{
    foreach (var sentence in strings.Split('.'))
    {
        Console.WriteLine(sentence.Trim());
    }
}

*/

List<string> ourAnimals = [];