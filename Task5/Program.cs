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

// Task 6 - Filtered Shopping List

    static void Main(string[] args)
    {
        List<string> shoppingList = new List<string>();

        string item = "";

        while (item != "done")
        {
            Console.Write("Enter an item (or type 'done' to finish): ");
            item = Console.ReadLine();

            if (item != "done")
            {
                shoppingList.Add(item);
            }
        }

        Console.WriteLine("\nShopping List:");

        foreach (string product in shoppingList)
        {
            Console.WriteLine(product);
        }

        Console.Write("\nEnter an item to remove: ");
        string removeItem = Console.ReadLine();

        shoppingList.Remove(removeItem);

        Console.WriteLine("\nShopping List after removal:");

        foreach (string product in shoppingList)
        {
            Console.WriteLine(product);
        }
    }
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Task 7 - High Score Podium

    static void Main(string[] args)
    {
        List<int> scores = new List<int>();

        for (int i = 1; i <= 5; i++)
        {
            Console.Write("Enter score " + i + ": ");
            int score = int.Parse(Console.ReadLine());

            scores.Add(score);
        }

        scores.Sort();
        scores.Reverse();

        Console.WriteLine("1st place: " + scores[0]);
        Console.WriteLine("2nd place: " + scores[1]);
        Console.WriteLine("3rd place: " + scores[2]);
    }
}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Task 8 - Undo Last Action

    static void Main(string[] args)
    {
        Stack<string> actions = new Stack<string>();

        string action = "";

        while (action != "stop")
        {
            Console.Write("Enter an action (or type 'stop'): ");
            action = Console.ReadLine();

            if (action != "stop")
            {
                actions.Push(action);
            }
        }

        Console.WriteLine("Undo: " + actions.Pop());
        Console.WriteLine("Undo: " + actions.Pop());

        Console.WriteLine("Remaining actions:");

        foreach (string item in actions)
        {
            Console.WriteLine(item);
        }
    }
}
*/
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////

// Task 9 - Grade Analyzer with Functions

    static double CalculateAverage(List<int> grades)
    {
        int sum = 0;

        foreach (int grade in grades)
        {
            sum += grade;
        }

        return sum / (double)grades.Count;
    }

    static int FindFirstFailing(List<int> grades)
    {
        return grades.Find(x => x < 60);
    }

    static void Main(string[] args)
    {
        List<int> grades = new List<int>();

        Console.Write("How many grades do you want to enter? ");
        int count = int.Parse(Console.ReadLine());

        for (int i = 1; i <= count; i++)
        {
            Console.Write("Enter grade " + i + ": ");
            int grade = int.Parse(Console.ReadLine());

            grades.Add(grade);
        }

        double average = CalculateAverage(grades);
        int firstFailing = FindFirstFailing(grades);

        Console.WriteLine("Average: " + average);

        if (firstFailing == 0)
        {
            Console.WriteLine("No failing grade found.");
        }
        else
        {
            Console.WriteLine("First failing grade: " + firstFailing);
        }
    }
}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
