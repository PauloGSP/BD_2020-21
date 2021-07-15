namespace TestesOnline
{
    class ComboBoxItem
    {
        private string text;
        private string value;

        public ComboBoxItem(string text, string value)
        {
            this.text = text;
            this.value = value;
        }

        public override string ToString()
        {
            return text;
        }

        public string getValue()
        {
            return value;
        }
    }
}
