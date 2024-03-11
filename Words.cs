namespace ConsoleTypingTest
{
    public class Words
    {
        public List<string>? WordsList { get; set; }
        public void PrintWords()
        {
            foreach(var word in WordsList)
                Console.WriteLine(word);
        }
    }
}