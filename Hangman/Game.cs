using Hangman.WordGeneration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public class Game
    {
        private IWordRepository repo;
        public string Word { get; set; }
        private int fails;
        private const int FAILS_LIMIT = 5;
        public Game()
        {
            repo = new FileWordRepository();
            fails = 0;
        }
        public void RunGame()
        {
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("P: Play game");
                Console.WriteLine("S: Seed words. This will override all previously added words");
                Console.WriteLine("A: Append word");
                Console.WriteLine("H: High scores");
                Console.WriteLine("Esc: Quit game");
                var c = Console.ReadKey(true);
                switch (c.Key)
                {
                    case ConsoleKey.P: Console.Clear(); StartGame(); break;
                    case ConsoleKey.S: Console.Clear(); GameInitializer.Seed(repo); Console.WriteLine("Seeding Done"); break;
                    case ConsoleKey.A: Console.Clear(); Console.WriteLine("Input the word followed by enter:"); repo.AddWord(Console.ReadLine().ToLower()); break;
                    case ConsoleKey.H: Console.Clear(); repo.GetHighscores(5); break;
                    case ConsoleKey.Escape: return;
                    default: break;
                }
            }
        }

        private void StartGame()
        {
            try
            {
                Word = repo.GetRandomWord();
                fails = 0;
                string hidden = new string('_', Word.Length);
                while (fails < FAILS_LIMIT)
                {
                    Console.WriteLine(hidden);
                    Console.WriteLine($"You failed {fails} times");
                    Console.WriteLine("Guess a letter");
                    string previous = hidden;
                    bool fail = true;
                    string unguessed = Word;
                    var c = Console.ReadKey(true);
                    if (Word.Contains(c.KeyChar))
                    {
                        fail = false;
                        int i = Word.IndexOf(c.KeyChar);
                        while (i != -1)
                        {
                            hidden = hidden.Remove(i, 1).Insert(i, c.KeyChar.ToString());
                            unguessed = unguessed.Remove(i, 1).Insert(i, "_");
                            i = unguessed.IndexOf(c.KeyChar);
                        }
                    }
                    if (fail)
                    {
                        fails++;
                    }
                    if (hidden.Equals(Word))
                    {
                        Console.WriteLine("Congrats you won! Press any key to continue");
                        Console.ReadKey(true);
                        return;
                    }
                }
            }
            catch (ApplicationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
