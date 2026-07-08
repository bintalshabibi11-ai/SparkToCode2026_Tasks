namespace Task5;

class Program
{
    /*static void Main(string[] args)
    {
// Task 1 - Fixed Grades Array

        static void Main(string[] args)
        {
            int[] grades = new int[5];

            for (int i = 0; i < grades.Length; i++)
            {
                Console.Write("Enter grade " + (i + 1) + ": ");
                grades[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Grades:");

            foreach (int grade in grades)
            {
                Console.WriteLine(grade);
            }
        }    }

    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // Task 2 - Dynamic To-Do List

    static void Main(string[] args)
    {
        List<string> tasks = new List<string>();

        for (int i = 0; i < 5; i++)
        {
            Console.Write("Enter task " + (i + 1) + ": ");
            tasks.Add(Console.ReadLine());
        }

        Console.WriteLine("To-Do List:");

        foreach (string task in tasks)
        {
            Console.WriteLine("- " + task);
        }
    }
}
*/

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Task 3 - Browsing History Stack

    static void Main(string[] args)
    {
        Stack<string> history = new Stack<string>();

        for (int i = 1; i <= 3; i++)
        {
            Console.Write("Enter website " + i + ": ");
            string website = Console.ReadLine();

            history.Push(website);
        }

        history.Pop();

        Console.WriteLine("Current page: " + history.Peek());
    }
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////