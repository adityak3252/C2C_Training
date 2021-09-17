using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace taskpad
{
    class Task
    {
        int id, priority;
        string name, desc, status;
        DateTime creationDate, completionDate;
        public Task(int id,string name,string desc,int priority,DateTime creationDate,DateTime completionDate,string status)
        {
            this.id = id;
            this.name = name;
            this.desc = desc;
            this.priority = priority;
            this.creationDate = creationDate;
            this.completionDate = completionDate;
            this.status = status;
        }
        public int idFun
        {
            get { return id; }
            set { id = value; }
        }
        public string nameFun
        {
            get { return name; }
            set { name = value; }
        }
        public string descFun
        {
            get { return desc; }
            set { desc = value; }
        }
        public int priorityFun
        {
            get { return priority; }
            set { priority = value; }
        }
        public DateTime creationDateFun
        {
            get { return creationDate; }
            set { creationDate = value; }
        }
        public DateTime completionDateFun
        {
            get { return completionDate; }
            set { completionDate = value; }
        }
        public string statusFun
        {
            get { return status; }
            set { status = value; }
        }

    }
    class Program
    {
        static int compByID(Task a,Task b)
        {
            if (a.idFun < b.idFun)
                return -1;
            return 1;
        }
        static int compByPriority(Task a, Task b)
        {
            if (a.priorityFun < b.priorityFun)
                return 1;
            return -1;
        }
        public static void createNew(List<Task> arrList)
        {
            int _id = arrList.Count, _priority = 0;
            string _name, _desc, _status = "Completed";
            DateTime _completionDate = new DateTime(12/31/2099);
            Console.WriteLine("\nEnter name:\n");
            _name = Console.ReadLine();
            Console.WriteLine("\nEnter Description:\n");
            _desc = Console.ReadLine();
            bool validPriority = false;
            while(!validPriority)
            {
                validPriority = true;
                try
                {
                    Console.WriteLine("\nEnter priority (0-5):\n");
                    _priority = Int32.Parse(Console.ReadLine());
                    if (_priority < 0 || _priority > 5)
                        throw new WrongPriorityException("\nPriority must be in range 0-5!\n");
                }
                catch (WrongPriorityException e)
                {
                    validPriority = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                catch
                {
                    validPriority = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid Priority!\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
            bool validDate = false;
            while(!validDate)
            {
                validDate = true;
                try
                {
                    Console.WriteLine("\nEnter Completion Date:\n");
                    _completionDate = Convert.ToDateTime(Console.ReadLine());
                    if (_completionDate < DateTime.Now)
                        throw new PastDateException("\nDate already passed!\n");
                }
                catch (PastDateException e)
                {
                    validDate = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                catch
                {
                    validDate = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid Date!\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
            if (_completionDate > DateTime.Today)
                _status = "Pending";
            arrList.Add(new Task(_id, _name, _desc, _priority, DateTime.Now, _completionDate, _status));
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nTask Created!\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public static void viewById(int id,List<Task> arrList)
        {
            Console.WriteLine("\n--------------------------------------------------------------------------\n");
            Console.WriteLine("Id:                 " + arrList[id].idFun);
            Console.WriteLine("Name:               " + arrList[id].nameFun);
            Console.WriteLine("Description:        " + arrList[id].descFun);
            Console.WriteLine("Priority:           " + arrList[id].priorityFun);
            Console.WriteLine("Date of Creation:   " + arrList[id].creationDateFun);
            Console.WriteLine("Date of Completion: " + arrList[id].completionDateFun);
            Console.WriteLine("Status:             " + arrList[id].statusFun);
            Console.WriteLine("\n--------------------------------------------------------------------------\n");
        }
        public static void viewAll(List<Task> arrList)
        {
            Console.WriteLine("\nSort By:\n");
            Console.WriteLine("1. ID\n");
            Console.WriteLine("2. Priority\n");
            Console.WriteLine("Enter Option:\n");
            int opt = 3;
            bool validOption = false;
            while (!validOption)
            {
                validOption = true;
                try
                {
                    Console.WriteLine("Select Option:\n");
                    opt = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    validOption = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid Option!\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
            switch (opt)
            {
                case 1:
                    arrList.Sort(compByID);
                    break;
                case 2:
                    arrList.Sort(compByPriority);
                    break;
                default:
                    arrList.Sort(compByID);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid Option!\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
            }
            Console.WriteLine("\n--------------------------------------------------------------------------\n");
            foreach (var elem in arrList)
            {
                Console.WriteLine("Id:                 " + elem.idFun);
                Console.WriteLine("Name:               " + elem.nameFun);
                Console.WriteLine("Description:        " + elem.descFun);
                Console.WriteLine("Priority:           " + elem.priorityFun);
                Console.WriteLine("Date of Creation:   " + elem.creationDateFun);
                Console.WriteLine("Date of Completion: " + elem.completionDateFun);
                Console.WriteLine("Status:             " + elem.statusFun);
                Console.WriteLine("\n--------------------------------------------------------------------------\n");
            }
        }
        public static void editTask(int id,List<Task> arrList)
        {
            arrList.Sort(compByID);
            Console.WriteLine("\nEdit fields:\n");
            Console.WriteLine("1.Edit Name\n");
            Console.WriteLine("2.Edit Description\n");
            Console.WriteLine("3.Edit Priority\n");
            Console.WriteLine("4.Edit Completion Date\n");
            int opt = 3;
            bool validOption = false;
            while (!validOption)
            {
                validOption = true;
                try
                {
                    Console.WriteLine("Select Option:\n");
                    opt = Int32.Parse(Console.ReadLine());
                }
                catch
                {
                    validOption = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid Option!\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
            }
            switch (opt)
            {
                case 1:
                    Console.WriteLine("\nEnter name:\n");
                    arrList[id].nameFun = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("\nEnter Description:\n");
                    arrList[id].descFun = Console.ReadLine();
                    break;
                case 3:
                    bool validPriority = false;
                    while (!validPriority)
                    {
                        validPriority = true;
                        try
                        {
                            Console.WriteLine("\nEnter priority: ");
                            arrList[id].priorityFun = Int32.Parse(Console.ReadLine());
                            if (arrList[id].priorityFun < 0 || arrList[id].priorityFun > 5)
                                throw new WrongPriorityException("\nPriority must be in range 0-5!\n");
                        }
                        catch (WrongPriorityException e)
                        {
                            validPriority = false;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        catch
                        {
                            validPriority = false;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInvalid Priority!\n");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                    }
                    break;
                case 4:
                    bool validDate = false;
                    while (!validDate)
                    {
                        validDate = true;
                        try
                        {
                            Console.WriteLine("\nEnter Completion Date: ");
                            arrList[id].completionDateFun = Convert.ToDateTime(Console.ReadLine());
                            if (arrList[id].completionDateFun < DateTime.Now)
                                throw new PastDateException("\nDate already passed!\n");
                        }
                        catch (PastDateException e)
                        {
                            validDate = false;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        catch
                        {
                            validDate = false;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInvalid Date!\n");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                    }
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nInvalid Option!\n");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
            }
            if (arrList[id].completionDateFun > DateTime.Today)
                arrList[id].statusFun = "Pending";
            else
                arrList[id].statusFun = "Completed";
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nTask Modified!\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public static void deleteTask(int id,List<Task> arrList)
        {
            arrList.Sort(compByID);
            arrList.RemoveAt(id);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nTask Deleted!\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        static void Main(string[] args)
        {
            List<Task> arrList = new List<Task>();
            arrList.Add(new Task(0, "Low-Mid", "Low-Mid Priority Task", 1, DateTime.Now, new DateTime(2022, 11, 22), "Pending"));
            arrList.Add(new Task(1, "High", "High Priority Task", 5, DateTime.Now, new DateTime(2022, 08, 22), "Pending"));
            arrList.Add(new Task(2, "Mid-High", "Mid-High Priority Task", 4, DateTime.Now, new DateTime(2022, 10, 22), "Pending"));
            arrList.Add(new Task(3, "Low", "Low Priority Task", 0, DateTime.Now, new DateTime(2022, 09, 22), "Pending"));
            arrList.Add(new Task(4, "Mid", "Mid Priority Task", 3, DateTime.Now, new DateTime(2022, 12, 22), "Pending"));
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n---------------------------------------Welcome to Taskpad!---------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            while (true)
            {
                Console.WriteLine("Menu:\n");
                Console.WriteLine("1.Create new task\n");
                Console.WriteLine("2.View By Id\n");
                Console.WriteLine("3.View all tasks\n");
                Console.WriteLine("4.Edit task\n");
                Console.WriteLine("5.Delete task\n");
                Console.WriteLine("6.Exit\n");
                int opt = 3;
                bool validOption = false;
                while (!validOption)
                {
                    validOption = true;
                    try
                    {
                        Console.WriteLine("Select Option:\n");
                        opt = Int32.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        validOption = false;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid Option!");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                }
                bool flg = false;
                switch (opt)
                {
                    case 1:
                        createNew(arrList);
                        break;
                    case 2:
                        if (arrList.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\nList is Empty!\n");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        }
                        int idToView = 0;
                        bool validID = false;
                        while (!validID)
                        {
                            validID = true;
                            try
                            {
                                Console.WriteLine("\nEnter ID of task you wish to VIEW:");
                                idToView = Int32.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                validID = false;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nInvalid ID\n");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            }
                        }
                        if (idToView >= arrList.Count)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInvalid ID\n");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        }
                        viewById(idToView,arrList);
                        break;
                    case 3:
                        if (arrList.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\nList is Empty!\n");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        }
                        viewAll(arrList);
                        break;
                    case 4:
                        if (arrList.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\nList is Empty!\n");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        }
                        int idToEdit = 0;
                        validID = false;
                        while (!validID)
                        {
                            validID = true;
                            try
                            {
                                Console.WriteLine("\nEnter ID of task you wish to EDIT:\n");
                                idToEdit = Int32.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                validID = false;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nInvalid ID\n");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            }
                        }
                        if (idToEdit >= arrList.Count)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInvalid ID\n");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        }
                        editTask(idToEdit,arrList);
                        break;
                    case 5:
                        if(arrList.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\nList is Empty!\n");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        }
                        int idToDelete = 0;
                        validID = false;
                        while (!validID)
                        {
                            validID = true;
                            try
                            {
                                Console.WriteLine("\nEnter ID of task you wish to DELETE:\n");
                                idToDelete = Int32.Parse(Console.ReadLine());
                            }
                            catch
                            {
                                validID = false;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nInvalid ID\n");
                                Console.ForegroundColor = ConsoleColor.Cyan;
                            }
                        }
                        if(idToDelete >= arrList.Count)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nInvalid ID\n");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        }
                        deleteTask(idToDelete,arrList);
                        break;
                    case 6:
                        flg = true;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nInvalid Option!\n");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        break;
                }
                if(flg)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nThanks for visiting!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
            }
        }
    }

    [Serializable]
    internal class WrongPriorityException : Exception
    {
        public WrongPriorityException()
        {
        }

        public WrongPriorityException(string message) : base(message)
        {
        }

        public WrongPriorityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WrongPriorityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class PastDateException : Exception
    {
        public PastDateException()
        {
        }

        public PastDateException(string message) : base(message)
        {
        }

        public PastDateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PastDateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
