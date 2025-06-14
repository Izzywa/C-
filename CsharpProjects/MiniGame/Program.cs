/*
- The code declares the following variables:
    - Variables to determine the size of the Terminal window.
    - Variables to track the locations of the player and food.
    - Arrays `states` and `foods` to provide available player and food appearances
    - Variables to track the current player and food appearance

- The code provides the following methods:
    - A method to determine if the Terminal window was resized.
    - A method to display a random food appearance at a random location.
    - A method that changes the player appearance to match the food consumed.
    - A method that temporarily freezes the player movement.
    - A method that moves the player according to directional input.
    - A method that sets up the initial game state.

- The code doesn't call the methods correctly to make the game playable. The following features are missing:
    - Code to determine if the player has consumed the food displayed.
    - Code to determine if the food consumed should freeze player movement.
    - Code to determine if the food consumed should increase player movement.
    - Code to increase movement speed.
    - Code to redisplay the food after it's consumed by the player.
    - Code to terminate execution if an unsupported key is entered.
    - Code to terminate execution if the terminal was resized.
*/
using System;

Random random = new();
Console.CursorVisible = false;
int height = Console.WindowHeight - 1;
int width = Console.WindowWidth - 5;
bool shouldExit = false;

// Console position of the player
int playerX = 0;
int playerY = 0;

// Console position of the food
int foodX = 0;
int foodY = 0;

// Available player and food strings
string[] states = {"('-')", "(^-^)", "(X_X)"};
string[] foods = {"@@@@@", "$$$$$", "#####"};

// Current player string displayed in the Console
string player = states[0];

// Index of the current food
int food = 0;

InitializeGame();
while (!shouldExit)
{
    if (PlayerIsParalyzed())
    {
        FreezePlayer();
    }

    if (PlayerIsEnergized())
    {
        Move(true);
    }
    else
    {
        Move();
    }

    if (TerminalResized())
        {
            Console.Clear();
            Console.WriteLine("Console was resized. Program exiting....");
            Thread.Sleep(1500);
            Console.Clear();
            shouldExit = true;
            continue;
        }

    if (PlayerConsumedFood())
    {
        ProgressionOptions();
    }
}

void ProgressionOptions(bool changePlayer = true, bool redisplayFood = true)
{
    if (changePlayer) ChangePlayer();
    if (redisplayFood) ShowFood();     
}


// Returns true if the Terminal was resized 
bool TerminalResized()
{
    return height != Console.WindowHeight - 1 || width != Console.WindowWidth - 5;
}

bool PlayerIsEnergized()
{
    return player == states[1];
}

bool PlayerConsumedFood()
{
    List<int> foodXs = [.. Enumerable.Range(foodX, foods[food].Length)];
    List<int> playerXs = [.. Enumerable.Range(playerX, player.Length)];

    var intersection = foodXs.Intersect(playerXs).ToList();
    //return false;
    return intersection.Count == foods[food].Length && playerY == foodY;
}

// Displays random food at a random location
void ShowFood() 
{
    // Update food to a random index
    food = random.Next(0, foods.Length);

    // Update food position to a random location
    foodX = random.Next(0, width - player.Length);
    foodY = random.Next(0, height - 1);

    // Display the food at the location
    Console.SetCursorPosition(foodX, foodY);
    Console.Write(foods[food]);
}

// Changes the player to match the food consumed
void ChangePlayer()
{
    player = states[food];
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

bool PlayerIsParalyzed()
{
    return player == states[2];
}

// Temporarily stops the player from moving
void FreezePlayer() 
{
    System.Threading.Thread.Sleep(1000);
    player = states[0];
}

// Reads directional input from the Console and moves the player
void Move(bool isEnergized = false ,bool continueWithOtherKeys = false) 
{
    int lastX = playerX;
    int lastY = playerY;

    int speed = isEnergized ? 3 : 1;

    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.UpArrow:
            playerY -= speed;
            break;
        case ConsoleKey.DownArrow:
            playerY += speed;
            break;
        case ConsoleKey.LeftArrow:
            playerX -= speed;
            break;
        case ConsoleKey.RightArrow:
            playerX += speed;
            break;
        case ConsoleKey.Escape:
            shouldExit = true;
            break;
        default:
            if (!continueWithOtherKeys)
            {
                shouldExit = true;
            }
            break;
    }

    // Clear the characters at the previous position
    Console.SetCursorPosition(lastX, lastY);
    for (int i = 0; i < player.Length; i++) 
    {
        Console.Write(" ");
    }

    // Keep player position within the bounds of the Terminal window
    playerX = (playerX < 0) ? 0 : (playerX >= width ? width : playerX);
    playerY = (playerY < 0) ? 0 : (playerY >= height ? height : playerY);

    // Draw the player at the new location
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

// Clears the console, displays the food and player
void InitializeGame() 
{
    Console.Clear();
    ShowFood();
    Console.SetCursorPosition(0, 0);
    Console.Write(player);
}