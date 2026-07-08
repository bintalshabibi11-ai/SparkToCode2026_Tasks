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

// Task 4 - Customer Service Queue

    static void Main(string[] args)
    {
        Queue<string> customers = new Queue<string>();

        for (int i = 1; i <= 3; i++)
        {
            Console.Write("Enter customer " + i + ": ");
            string customer = Console.ReadLine();

            customers.Enqueue(customer);
        }

        string servedCustomer = customers.Dequeue();

        Console.WriteLine("Served customer: " + servedCustomer);
    }
}
*/
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Task 5 - Array Grade Range

    static void Main(string[] args)
    {
        int[] grades = new int[5];
        int sum = 0;

        for (int i = 0; i < grades.Length; i++)
        {
            Console.Write("Enter grade " + (i + 1) + ": ");
            grades[i] = int.Parse(Console.ReadLine());

            sum += grades[i];
        }

        Array.Sort(grades);

        double average = sum / 5.0;

        Console.WriteLine("Lowest grade: " + grades[0]);
        Console.WriteLine("Highest grade: " + grades[grades.Length - 1]);
        Console.WriteLine("Average: " + average);
    }
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

