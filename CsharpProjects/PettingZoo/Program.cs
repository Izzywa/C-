using System;

string[] pettingZoo =
{
    "alpacas", "capybaras", "chickens", "ducks", "emus", "geese",
    "goats", "iguanas", "kangaroos", "lemurs", "llamas", "macaws",
    "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises",
};

/*
- There will be three visiting schools
    - School A has six visiting groups (the default number)
    - School B has three visiting groups
    - School C has two visiting groups

- For each visiting school, perform the following tasks
    - Randomize the animals
    - Assign the animals to the correct number of groups
    - Print the school name
    - Print the animal groups
*/

Dictionary<string, int> visitingSchools = new()
{
    {"School A", 6},
    {"School B", 3},
    {"School C", 2},
    { "School D", 4}
};

foreach (var school in visitingSchools)
{
    Console.WriteLine(school.Key);

    var groups = AssignGroup(school.Value);
    foreach (var item in groups)
    {
        Console.WriteLine("{0}: {1}",
        item.Key, string.Join(',', item.Value));
    }
    Console.WriteLine();
}

static string[] RandomizeAnimals(string[] animals)
{
    Random random = new();
    var duplicateAnimals = animals.ToArray();
    Random.Shared.Shuffle(duplicateAnimals);

    return duplicateAnimals;
}

// AssignGroup();
Dictionary<string, List<string>> AssignGroup(int groupSize)
{
    Dictionary<string, List<string>> assignedGroups = [];
    var animals = RandomizeAnimals(pettingZoo);
    var animalChunks = animals.Chunk(animals.Length/groupSize).ToList();

    for (int i = 0; i < groupSize; i++)
    {
        assignedGroups.Add($"Group {i + 1}", [.. animalChunks[i]]);
    }

    if (animals.Length % groupSize != 0)
    {
        var leftoverAnimals = animalChunks.Last();

        for (int i = 0; i < leftoverAnimals.Length; i++)
        {
            assignedGroups[$"Group {i + 1}"].Add(leftoverAnimals[i]);
        }
    }
    return assignedGroups;
}