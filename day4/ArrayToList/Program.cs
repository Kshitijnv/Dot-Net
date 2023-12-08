using System.Collections;

namespace ArrayToList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Reading the size of array from User
            Console.WriteLine("Enter the size of array: ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] MyArray = new int[size];
            //Reading the elements of array from user
            for (int i=0;i<MyArray.Length;i++)
            {
                Console.Write($"Enter {i+1} element : ");
                MyArray[i] = Convert.ToInt32(Console.ReadLine());
            }


            //Displaying the array
            Console.WriteLine("Original Array");
            Program.PrintList(MyArray);


            //Converting the FIXED array to ArrayList
            List<int> MyArrayList = new List<int>(MyArray);
            //Displaying the arrayList
            Console.WriteLine(" ArrayList");
            Program.PrintList(MyArrayList);


            //Again Converting the ArrayList to Fixed Array
            int[] newArray = MyArrayList.ToArray();
            //Displaying the array
            Console.WriteLine("Converted Array");
            Program.PrintList(newArray);
        }
        public static void PrintList<T>(IList<T> list)
        {
            foreach (var i in list)
            {
                Console.WriteLine($" element is {i} ");
            }
        }
    

    }
}