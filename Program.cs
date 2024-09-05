using System;

class Program
{
    static byte score = 0;

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Welcome to our guess game, user.");
            Console.WriteLine("To play our wonderful game, you need to guess the secret word.");
            Console.WriteLine("Choose your difficulty level: easy, medium, or hard.");

            string difficulty = Console.ReadLine()?.ToLower().Trim();

            // Loop until a valid difficulty level is entered
            while (difficulty != "easy" && difficulty != "medium" && difficulty != "hard")
            {
                Console.WriteLine("Invalid input. Please choose easy, medium, or hard.");
                difficulty = Console.ReadLine()?.ToLower().Trim();
            }

            // Call the GuessWord method with the appropriate parameters based on difficulty level
            switch (difficulty)
            {
                case "easy":
                    GuessWord("banana", "It's a fruit, something you like to eat after gyming, and it's yellow in color.", 5, 10);
                    break;
                case "medium":
                    GuessWord("elephant", "It has a trunk but is not a tree and is often associated with good memory.", 3, 20);
                    break;
                case "hard":
                    GuessWord("chameleon", "I can change my appearance to blend into my surroundings. My name is also used to describe someone who adapts to different situations.", 2, 30);
                    break;
            }

            // Optionally, ask if the user wants to play again
            Console.WriteLine("Do you want to play again? (yes/no)");
            string playAgain = Console.ReadLine()?.ToLower().Trim();
            if (playAgain != "yes")
            {
                break; // Exit the loop and end the program
            }
        }
    }

    static void GuessWord(string secretWord, string clue, int maxGuesses, byte points)
    {
        string guess = "";
        int guessCount = 0;

        Console.WriteLine($"You have chosen this mode. {clue}");
        Console.WriteLine($"Try your best to guess the word. You must guess the word in {maxGuesses} tries. Good luck!");

        while (guess != secretWord && guessCount < maxGuesses)
        {
            Console.WriteLine("Enter a guess:");
            guess = Console.ReadLine()?.ToLower().Trim();  // Normalize input to lowercase and trim whitespaces
            guessCount++;

            if (string.IsNullOrWhiteSpace(guess))
            {
                Console.WriteLine("Invalid input, please enter a valid guess.");
                guessCount--;  // Don't count invalid input as an attempt
                continue;
            }

            if (guess != secretWord)
            {
                int remainingTries = maxGuesses - guessCount;
                if (remainingTries > 0)
                {
                    Console.WriteLine($"You made a wrong guess. Try again, total tries left for you is {remainingTries}");
                }
            }
            else
            {
                Console.WriteLine($"Congratulations, you guessed the word correctly in {guessCount} tries.");
                score += points;
                Console.WriteLine($"Your score is {score}");
                break;
            }
        }

        // Check if the player has lost
        if (guess != secretWord)
        {
            Console.WriteLine($"You've run out of guesses. The secret word was: {secretWord}. Better luck next time!");
        }
    }
}
