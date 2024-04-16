using System;
using System.Diagnostics;

namespace ProcessManager
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1) Show all running processes");
                Console.WriteLine("2) Kill a process by ID");
                Console.WriteLine("3) Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ShowRunningProcesses();
                        break;
                    case "2":
                        KillProcessById();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void ShowRunningProcesses()
        {
            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                Console.WriteLine($"ID: {process.Id}, Name: {process.ProcessName}");
            }
        }

        static void KillProcessById()
        {
            Console.Write("Enter the ID of the process to kill: ");
            string idInput = Console.ReadLine();

            if (int.TryParse(idInput, out int id))
            {
                try
                {
                    Process processToKill = Process.GetProcessById(id);
                    processToKill.Kill();
                    Console.WriteLine($"Process with ID {id} has been killed.");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine($"No process with ID {id} found.");
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("The process could not be killed. It may have already exited.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID. Please enter a number.");
            }
        }
    }
}