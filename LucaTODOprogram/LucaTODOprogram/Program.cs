// See https://aka.ms/new-console-template for more information

class Program
{
    static List<string> taskList = new List<string>();

    static void Main()
    {
        
        Console.WriteLine("Welcome to the To-Do List Application!\n");
        bool continueProgram = true;
        while (continueProgram)
        {
            DisplayMenuItems();
            switch (GetUserInput())
            {
                case 1:
                    ViewTasks();
                    break;
                case 2:

                    AddTask();
                    break;
                case 3:

                    RemoveTask();
                    break;

                case 4:
                    continueProgram = false;
                    break;

            }

        }

        static int GetUserInput()
        {
            Console.WriteLine("Write your choice:");
            int parsedUserChoice;
            string userChoice = Console.ReadLine();
            int.TryParse(userChoice, out parsedUserChoice);
            return (parsedUserChoice);
        }

        static void DisplayMenuItems()
        {
            Console.WriteLine("1. See tasks");
            Console.WriteLine("2. Add task");
            Console.WriteLine("3. Remove task");
            Console.WriteLine("4. Exit");
        }

        static void ViewTasks()
        {
            int i = taskList.Count();
            if (i > 0)
                for (int j = 0; j < taskList.Count(); j++)
                {
                    Console.WriteLine(j+1 + ". " + taskList[j]);
                }
            else
            {
                Console.WriteLine("Task list is empty");
            }
            Console.WriteLine();
        }

        static void AddTask()
        {
            Console.WriteLine("Add task: ");
            string task = Console.ReadLine();
            taskList.Add(task);
            Console.WriteLine("Task " + task + " added!");
        }

        static void RemoveTask()
        {
            Console.WriteLine("Which task do you want to remove?");
            int parsedUserChoice;
            string userChoice = Console.ReadLine();
            int.TryParse(userChoice, out parsedUserChoice);
            

            int taskListLength = taskList.Count;
            
            if (taskListLength >= parsedUserChoice && parsedUserChoice > 0)
            {
                string taskToDeleted = taskList[parsedUserChoice - 1];
                Console.WriteLine("Task " + taskToDeleted + " was removed.");
                taskList.RemoveAt(parsedUserChoice - 1);
            }
            else
            {
                
                Console.WriteLine("Looks like there is no task number " + parsedUserChoice);
            }
            
        }
    }
}
          
