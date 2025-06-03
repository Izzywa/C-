// the ourAnimals array will store the following: 
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";

List<Dictionary<string, string>> animals = [];

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 6];

// TODO: Convert the if-elseif-else construct to a switch statement

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;

    animals = [.. animals, new Dictionary<string, string>
    {
        { "ID", animalID },
        { "Species", animalSpecies },
        { "Age", animalAge},
        { "Nickname", animalNickname},
        { "Physical Description", animalPhysicalDescription},
        { "Personality Description", animalPersonalityDescription}
    }];
}

// display the top-level menu options
do
{

    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    Console.WriteLine($"You selected menu option {menuSelection}.");
    Console.WriteLine("Press the Enter key to continue");
    // pause code execution
    readResult = Console.ReadLine();

    switch (menuSelection)
    {
        case "1":
            //string tableFormat = "{0,-10}| {1,-5}| {2,-5}| {3,-20}| {4,-20}| {5,-5}";
            Console.Clear();
            Console.WriteLine("ALL PETS INFORMATION\n");
            //Console.WriteLine(tableFormat, "Species", "ID", "Age", "Physical Desc", "Personality Desc", "Nickname");


            foreach (var animal in animals)
            {
                //Console.WriteLine(tableFormat, animal["Species"], animal["ID"], animal["Age"], animal["Physical"], animal["Personality"], animal["Nickname"]);
                foreach (var item in animal)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
                Console.WriteLine();
            }
            break;

        case "2":
            Console.Clear();
            string anotherPet = "y";
            int petCount = 0;

            for (int i = 0; i < maxPets; i++)
            {
                if (animals[i]["ID"] != "")
                {
                    petCount++;   
                }
            }

            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
            }

            while (anotherPet == "y" && petCount < maxPets)
            {
                bool validEntry = false;
                var newPet = animals[petCount];
                petCount++;

                do
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry.");
                    readResult = Console.ReadLine();

                    animalSpecies = string.IsNullOrEmpty(readResult) ? "" : readResult.ToLower();

                    validEntry = animalSpecies == "dog" || animalSpecies == "cat";

                } while (validEntry == false);

                newPet["Species"] = animalSpecies;
                newPet["ID"] = animalSpecies[..1].ToUpper() + petCount.ToString();

                do
                {
                    Console.WriteLine("Enter the pet's age or enter ? if unknown");
                    readResult = Console.ReadLine();

                    if (readResult != "?")
                    {
                        validEntry = int.TryParse(readResult, out int petAge);
                    }

                    animalAge = readResult ?? "";

                } while (validEntry == false);

                newPet["Age"] = animalAge;

                Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                readResult = Console.ReadLine();
                
                newPet["Physical Description"] = string.IsNullOrWhiteSpace(readResult) ? "tbd" : readResult.ToLower().Trim();

                Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                readResult = Console.ReadLine();

                newPet["Personality Description"] = string.IsNullOrWhiteSpace(readResult) ? "tbd" : readResult.ToLower().Trim();

                Console.WriteLine("Enter a nickname for the pet");
                readResult = Console.ReadLine();

                newPet["Nickname"] = string.IsNullOrWhiteSpace(readResult) ? "tbd" : readResult.ToLower().Trim();



                if (petCount < maxPets)
                {
                    Console.WriteLine("Do you want to enter info for another pet (y/n)");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }
                    } while (anotherPet != "y" && anotherPet != "n");
                }
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached the limit on the number of pets we can manage");
            }

            break;

        case "3":
            Console.Clear();

            foreach (var animal in animals)
            {
                if (!string.IsNullOrWhiteSpace(animal["ID"]))
                {
                    if (animal["Age"] == "?")
                    {
                        bool validAge = false;
                        do
                        {
                            Console.WriteLine($"Enter an age for ID #: {animal["ID"]}");
                            readResult = Console.ReadLine();
                            validAge = int.TryParse(readResult, out int age);
                        } while (validAge == false);

                        animal["Age"] = readResult ?? "?";
                    }

                    if (animal["Physical Description"] == "" || animal["Physical Description"] == "tbd")
                    {
                        bool validPhysicalDescription = false;
                        do
                        {
                            Console.WriteLine($"Enter a physical description for ID #: {animal["ID"]} (size, color, breed, gender, weight, housebroken)");
                            readResult = Console.ReadLine();
                            validPhysicalDescription = !string.IsNullOrWhiteSpace(readResult);
                        } while (validPhysicalDescription == false);

                        animal["Physical Description"] = readResult ?? "tbd";
                    }
                }
            }
            Console.WriteLine("Age and physical description fields are complete for all of our friends. ");
            break;

        case "4":
            Console.Clear();
            
            foreach (var animal in animals)
            {
                if (!string.IsNullOrWhiteSpace(animal["ID"]))
                {
                    if (animal["Nickname"] == "" || animal["Nickname"] == "tbd")
                    {
                        bool validNickname = false;
                        do
                        {
                            Console.WriteLine($"Enter a nickname for ID #: {animal["ID"]}");
                            readResult = Console.ReadLine();
                            validNickname = !string.IsNullOrWhiteSpace(readResult);

                        } while (validNickname == false);

                        animal["Nickname"] = readResult ?? "tbd";
                    }

                    if (animal["Personality Description"] == "" || animal["Personality Description"] == "tbd")
                    {
                        bool validPersonalityDescription = false;
                        do
                        {
                            Console.WriteLine($"Enter a personality description for ID #: {animal["ID"]} (likes or dislikes, tricks, energy level)");
                            readResult = Console.ReadLine();
                            validPersonalityDescription = !string.IsNullOrWhiteSpace(readResult);

                        } while (validPersonalityDescription == false);

                        animal["Personality Description"] = readResult ?? "tbd";
                    }
                }
            }

            Console.WriteLine("Nickname and personality description fields are complete for all of our friends.");
            break;

        default:
            continue;
    }

    Console.WriteLine("Press the Enter key to continue");
    readResult = Console.ReadLine();
    

} while (menuSelection != "exit");
