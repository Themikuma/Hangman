using Hangman.WordGeneration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public static class GameInitializer
    {
        public static void Seed(IWordRepository repo)
        {
            repo.ClearWords();
            //repo.AddWord("about");
            //repo.AddWord("their");
            //repo.AddWord("would");
            repo.AddWord("dictionary");
            //repo.AddWord("campaign");
            //repo.AddWord("candidate");
            //repo.AddWord("challenge");
            //repo.AddWord("economy");
            //repo.AddWord("education");
            //repo.AddWord("government");
            //repo.AddWord("information");
            //repo.AddWord("leader");
            //repo.AddWord("magazine");
            //repo.AddWord("opportunity");
            //repo.AddWord("professional");
            //repo.AddWord("situation");
            //repo.AddWord("understand");
        }
    }
}
