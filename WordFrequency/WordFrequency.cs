namespace WordFrequency
{
    public class WordFrequency
    {
        private string word;
        private int wordCount;

        public WordFrequency(string word, int count)
        {
            this.word = word;
            this.wordCount = count;
        }

        public string Word
        {
            get { return this.word; }
        }

        public int WordCount
        {
            get { return this.wordCount; }
        }
    }
}
