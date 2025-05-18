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
*/
