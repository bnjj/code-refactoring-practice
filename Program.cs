using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();

            int selectedOption = 0;

            do
            {
                ShowMainMenu();
                selectedOption = UserNumericInput();
                switch (selectedOption)
                {
                    case (int)Options.NewTask:
                        ShowMenuAdd();
                        break;
                    case (int)Options.RemoveTask:
                        ShowMenuRemove();
                        break;
                    case (int)Options.PendingTasks:
                        ShowMenuDetail();
                        break;
                    default:
                        Console.Clear();
                        break;
                }


            } while (selectedOption != (int)Options.ExitProgram);
        }


        public static void ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");
        }

        public static void ShowMenuRemove()
        {

            ShowMenuDetail();


            try
            {
                if (TaskList.Count > 0)
                {
                    Console.WriteLine("Ingrese el número de la tarea a remover: ");
                    int userInput = UserNumericInput();
                    int indexToRemove = UserInputToIndex(userInput);

                    if (indexToRemove > -1)
                    {

                        string task = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine("Tarea " + task + " eliminada");

                    }
                }
            }
            catch (Exception ex)
            { 
                Console.WriteLine("Ocurrio un Error al remover la tarea");
            }
                

        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = UserTaskInput();
                
                TaskList.Add(task);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ShowMenuDetail()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            }
            else
            {
                int taskIndex = 1;
                Console.WriteLine("----------------------------------------");

                TaskList.ForEach(p => Console.WriteLine(taskIndex++ + ". " + p));
               
                Console.WriteLine("----------------------------------------");
            }
        }

        public static int UserNumericInput()
        {

            try
            {
                string userInput = Console.ReadLine();
                return Convert.ToInt32(userInput);

            }
            catch
            {
                Console.WriteLine("Ingrese una Opcion Valida");
                return (int)Options.None;
            }
        }

        public static string UserTaskInput()
        { 
             
            string task = Console.ReadLine();
            if (task == null || task == "")           
               throw new Exception("No se pudo registrar la tarea.");               
            
            return task;
        }

        public static int UserInputToIndex(int userInput)
        {
            return userInput-1;
        }



        public enum Options
        {
            None = 0,
            NewTask = 1,
            RemoveTask = 2,
            PendingTasks = 3,
            ExitProgram = 4
        }
    }
}
