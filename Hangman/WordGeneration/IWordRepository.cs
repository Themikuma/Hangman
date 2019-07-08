namespace Hangman.WordGeneration
{
    public interface IWordRepository
    {
        string GetRandomWord();

        void AddWord(string word);

        void SaveWordScore();

        string GetWord(string word);
        void GetHighscores(int v);
        void ClearWords();
    }
}