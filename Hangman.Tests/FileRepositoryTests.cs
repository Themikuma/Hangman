using Hangman.WordGeneration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Hangman.Tests
{
    [TestClass]
    public class FileRepositoryTests
    {

        private string testWords = "words.txt";
        private string testScores = "scores.txt";

        [TestCleanup]
        public void Setup()
        {
            if (File.Exists(testWords))
            {
                File.Delete(testWords);
            }
            if (File.Exists(testScores))
            {
                File.Delete(testScores);
            }
        }

        [TestMethod]
        public void TestAddWordWithEmptyWords()
        {
            //Arrange

            string word = "hello";
            IWordRepository repo = new FileWordRepository(testWords);

            //Act
            repo.AddWord(word);

            //Assert
            using (StreamReader sr = new StreamReader(testWords))
            {
                var actual = sr.ReadLine();
                Assert.AreEqual(actual, word);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAddTheSameWord()
        {
            //Arrange

            string word = "hello";
            IWordRepository repo = new FileWordRepository(testWords);

            //Act
            repo.AddWord(word);
            repo.AddWord(word);

            //No point in asserting
        }
    }
}
