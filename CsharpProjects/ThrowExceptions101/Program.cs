/*// Prompt the user for the lower and upper bounds
Console.Write("Enter the lower bound: ");
int lowerBound = int.Parse(Console.ReadLine());

Console.Write("Enter the upper bound: ");
int upperBound = int.Parse(Console.ReadLine());

decimal averageValue = 0;
bool exit = false;

// Calculate the sum of the even numbers between the bounds
do
{
    try
    {
        averageValue = AverageOfEvenNumbers(lowerBound, upperBound);
        Console.WriteLine($"The average of even numbers between {lowerBound} and {upperBound} is {averageValue}.");
        exit = true;
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine("An error occurred");
        Console.WriteLine(ex.Message);
        Console.WriteLine("The upper bound must be higher than the lower bound");
        Console.WriteLine("Enter a new upper bound (or enter exit to quit)");
        string? userResponse = Console.ReadLine();
        if ( userResponse != null && userResponse.Contains("exit", StringComparison.CurrentCultureIgnoreCase))
        {
            exit = true;
        }
        else
        {
            bool validUpperBound = int.TryParse(userResponse, out upperBound);
        }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
} while (!exit);

// Display the value returned by AverageOfEvenNumbers in the console

// Wait for user input
Console.ReadLine();

static decimal AverageOfEvenNumbers(int lowerBound, int upperBound)
{
    int sum = 0;
    int count = 0;
    decimal average = 0;

    //ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(lowerBound, upperBound, "lower bound");
    if (lowerBound >= upperBound)
    {
        throw new ArgumentOutOfRangeException(nameof(upperBound), "upper bound must be greater than lower bound");
    }

    for (int i = lowerBound; i <= upperBound; i++)
    {
        if (i % 2 == 0)
        {
            sum += i;
            count++;
        }
    }

    average = (decimal)sum / count;

    return average;
}
*/
string[][] userEnteredValues = new string[][]
{
            ["1", "2", "3"],
            ["1", "two", "3"],
            ["0", "1", "2"]
};


try
{
    Workflow1(userEnteredValues);
    Console.WriteLine("'Workflow1' completed successfully.");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("An error occurred during 'Workflow1'.");
    Console.WriteLine(ex.Message);

}

static void Workflow1(string[][] userEnteredValues)
{

    foreach (string[] userEntries in userEnteredValues)
    {
        try
        {
            Process1(userEntries);
            Console.WriteLine("'Process1' completed successfully.");
            Console.WriteLine();
        }
        catch (FormatException ex)
        {
            Console.WriteLine("'Process1' encountered an issue, process aborted.");
            Console.WriteLine(ex.Message);
        }
        catch (DivideByZeroException)
        {
            throw new DivideByZeroException("Invalid data. User input values must be non-zero values.");
        }
    }
}

static void Process1(String[] userEntries)
{

    foreach (string userValue in userEntries)
    {
        bool integerFormat = int.TryParse(userValue, out int valueEntered);

        if (integerFormat == true)
        {
            int calculatedValue = 4 / valueEntered;
        }
        else
        {
            throw new FormatException("Invalid data. User input values must be valid integers.");
        }
    }
}