using System;
using System.Diagnostics;

namespace lab2rpm
{
    class Program
    {
        static void Main()
        {
            bool whileWork = true;

            Process[] processlist = Process.GetProcesses();

            foreach (Process theProcess in processlist)
            {
                Console.WriteLine("Process: {0}\n ID: {1}\n Priority: {2}\n", theProcess.ProcessName, theProcess.Id, theProcess.BasePriority);
            }

            Console.WriteLine("Введите id процесса: \n");
            var id = Console.ReadLine();
            Console.WriteLine();

            using (Process choiseId = Process.GetProcessById(int.Parse(id)))
            {
                Console.WriteLine("Информация о выбранном процессе: ");
                Console.WriteLine("\n\tВыбранный процесс: {0}({1})\n\tПриориет: {2}\n", choiseId.ProcessName, choiseId.Id, choiseId.BasePriority);
            }

            while (whileWork)
            {
                Console.WriteLine("Выберите цифру одного из элементов меню.");
                Console.WriteLine("MENU: ");
                Console.WriteLine("\t1 - Idle (Низкий)\n\t2 - Normal (Обычный)\n\t3 - High (Высокий)\n\t4 - RealTime (Реального времени)\n\t0 - Закончить работу программы");

                string choise = Console.ReadLine();

                switch (choise)
                {
                    case "1":
                        Process.GetProcessById(Int32.Parse(id)).PriorityClass = ProcessPriorityClass.Idle;
                        Console.WriteLine("Вы задали низкий приоритет процессу имеющему id - {0}", id);
                        break;
                    case "2":
                        Process.GetProcessById(Int32.Parse(id)).PriorityClass = ProcessPriorityClass.Normal;
                        Console.WriteLine("Вы задали обычный приоритет процессу имеющему id - {0}", id);
                        break;
                    case "3":
                        Process.GetProcessById(Int32.Parse(id)).PriorityClass = ProcessPriorityClass.High;
                        Console.WriteLine("Вы задали высокий приоритет процессу имеющему id - {0}", id);
                        break;
                    case "4":
                        Process.GetProcessById(Int32.Parse(id)).PriorityClass = ProcessPriorityClass.RealTime;
                        Console.WriteLine("Вы задали приоритет реального времени процессу имеющему id - {0}", id);
                        break;
                    case "0":
                        whileWork = false;
                        break;
                    default:
                        Console.WriteLine("Вы не выбрали ни одного из элементов меню! Попробуйте еще раз.");
                        break;
                }
            }
        }
    }
}