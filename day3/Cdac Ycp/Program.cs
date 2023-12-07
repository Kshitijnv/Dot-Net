using System.Transactions;

namespace Cdac_Ycp
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter the number of batches: ");
            int batches = Convert.ToInt32(Console.ReadLine());
            int[][] students = new int[batches][];
            // Accepting the number of students for each batch           
            for (int i = 0; i < batches; i++)
            {
                Console.WriteLine($"Enter the number of Students for batch{i+1}: ");
                int noOfStudents = Convert.ToInt32(Console.ReadLine());
                students[i] = new int[noOfStudents];    //if batches=3 --> students[0][0] students[0][1] students[0][2]
            }

          
            for (int i = 0;i < batches; i++)
            {
                for (int j = 0; j < students[i].Length; j++)
                {
                    Console.WriteLine($"Enter the marks for {j+1} student of batch{i+1}");
                    students[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            for(int i = 0;i<batches ; i++)
            {
                for(int j = 0;j < students[i].Length; j++)
                {
                    Console.WriteLine($"Marks of student{j + 1} of batch{i+1} is: {students[i][j]}");
                }
            }  


        }
    }
}