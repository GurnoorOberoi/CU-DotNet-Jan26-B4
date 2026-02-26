namespace HangmanGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = { "APPLE", "SUNLIGHT", "LAPTOP", "FREEDOM", "CHEESECAKE" };
            Random rnd = new Random();
            string enter = words[rnd.Next(words.Length)];
            char[] gussesWord = new char[enter.Length];
            for (int i = 0; i < gussesWord.Length; i++)
            {
                gussesWord[i] = '_';
            }
            int lives = 6;
            string letters = "";
            Console.WriteLine("Welcome to C# Hangman!\n");
            while (lives > 0)
            {
                Console.WriteLine("\nWord: " + string.Join(" ", gussesWord));
                Console.WriteLine("Lives Left: " + lives);
                Console.WriteLine("Guessed: " + letters);//string.Join(",",letters));
                Console.Write("Guess a Letter: ");
                string input = Console.ReadLine().ToUpper();
                if (!char.IsLetter(input[0]) || input.Length != 1)
                {
                    Console.WriteLine("Please Enter a Valid Letter");
                    continue;
                }
                char used = input[0];
                if (letters.Contains(used))
                {
                    Console.WriteLine($"You already guessed {input}. Try again.");
                    continue;
                }
                letters += used + ",";
                bool found = false;
                for (int i = 0; i < enter.Length; i++)
                {
                    if (enter[i] == used)
                    {
                        gussesWord[i] = used;
                        found = true;
                    }
                }
                if (found)
                {
                    Console.WriteLine("Good catch!");
                }
                else
                {
                    Console.WriteLine("Nope! That's not in the word.");
                    lives--;
                }
                if (!gussesWord.Contains('_'))
                {
                    Console.WriteLine(" You guessed the right word: " + enter);
                    break;
                }
            }
        }
    }
}
