using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Hangman.WordGeneration
{
    public class FileWordRepository : IWordRepository
    {
        public FileWordRepository(string wordsPath = null, string scoresPath = null)
        {
            this.WordsPath = wordsPath;
            this.ScoresPath = wordsPath;

            if (!File.Exists(WordsPath))
            {
                File.WriteAllText(WordsPath, null);
            }

            if (!File.Exists(ScoresPath))
            {
                File.Create(ScoresPath);
            }
        }

        public void AddWord(string word)
        {
            string line;
            using (StreamReader reader = new StreamReader(WordsPath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.Compare(line, word, true) == 0)
                    {
                        throw new ArgumentException("Word already exists");
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(WordsPath, true))
            {
                sw.WriteLine(word);
            }
        }

        public string GetRandomWord()
        {
            if (string.IsNullOrEmpty(File.ReadAllText(WordsPath)))
            {
                throw new ApplicationException("No words found! Either use the seed or add words.");
            }
            List<string> words = new List<string>();
            using (StreamReader reader = new StreamReader(WordsPath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    words.Add(line);
                }
            }
            Random r = new Random();
            var i = r.Next(words.Count - 1);
            return words[i];
        }

        public string GetWord(string word)
        {
            throw new NotImplementedException();
        }

        public void SaveWordScore()
        {
            throw new NotImplementedException();
        }

        public void GetHighscores(int v)
        {
            throw new NotImplementedException();
        }

        public void ClearWords()
        {
            File.WriteAllText(WordsPath, null);
        }

        private string WordsPath
        {
            get
            {
                if (wordsPath != null)
                {
                    return wordsPath;
                }
                return "..//..//words.txt";
            }
            set
            {
                wordsPath = value;
            }
        }
        private string wordsPath;

        private string ScoresPath
        {
            get
            {
                if (scoresPath != null)
                {
                    return scoresPath;
                }
                return "..//..//scores.txt";
            }
            set
            {
                scoresPath = value;
            }
        }
        private string scoresPath;
    }
}
