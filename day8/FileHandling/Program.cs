namespace FileHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateFile();
            ReadFile();
            CreateFileUnformatted();
        }
        static void CreateFile()
        {
            //-------------Formatted------------- 
            //Creating a stream which connects to specified path
            StreamWriter sw = File.CreateText("C:\\Users\\dac.STUDENTSDC\\Documents\\KshitijDAC2023\\Dot Net\\day8\\Work\\a1.txt");
            //Writing into stream, line by line
            sw.WriteLine("Hello World");
            sw.WriteLine("Kshitij");
            sw.WriteLine("Harshal");
            //To close the streamWriter
            sw.Close();
        }
        static void ReadFile()
        {
            string s;
            //Creating a stream which connects to specified path
            StreamReader sr = File.OpenText("C:\\Users\\dac.STUDENTSDC\\Documents\\KshitijDAC2023\\Dot Net\\day8\\Work\\a1.txt");
            //Reading the stream Line by Line & Storing in the local var 's' until we get null(i.e., No More Lines in the file)
            while ((s = sr.ReadLine()) != null)
            {
                Console.WriteLine(s);
            }
        }
        private static void CreateFileUnformatted()
        {
            string s1 = "Hello World";
            string s2 = "Kshitij";
            string s3 = "Harshal";
        }
    }
}