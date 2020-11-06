namespace WordFrequency
{
    public class Input
    {
        private string value;
        private int count;

        public Input(string value, int i)
        {
            this.value = value;
            this.count = i;
        }

        public string Value
        {
            get { return this.value; }
        }

        public int WordCount
        {
            get { return this.count; }
        }
    }
}
