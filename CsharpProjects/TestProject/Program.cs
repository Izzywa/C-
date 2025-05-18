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
*/

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