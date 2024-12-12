using Homework_7.Classes;
using System;
using System.Collections.Generic;

namespace Homework_7
{
    internal class Program
    {

        static Random random = new Random();

        static void AssignTask(Employee assigner, Employee recipient, Task task)
        {
            Console.WriteLine($"От {assigner.Name} дается задача '{task.Title}'.");

            
            Employee currentManager = recipient.Manager;
            while (currentManager != null)
            {
                if (currentManager == assigner)
                {
                    recipient.ReceiveTask(task);
                    return;
                }
                currentManager = currentManager.Manager;
            }

            Console.WriteLine($"{assigner.Name} не имеет права назначать задачу {recipient.Name}.");
        }





        static void Main(string[] args)
        {
            Console.WriteLine("Домашнее задание из файла:\n");
            Manager timur = new Manager("Тимур", null); // Генеральный директор
            Manager rashid = new Manager("Рашид", timur); // Финансовый директор
            Manager ilham = new Manager("Ильхам", timur); // Директор по автоматизации
            Manager orkadiy = new Manager("Оркадий", ilham); // Начальник ИТ отдела
            Manager volodya = new Manager("Володя", ilham); // Зам.начальника ИТ отдела


            SysAdmin ilshat = new SysAdmin("Ильшат", orkadiy);
            SysAdmin ivanych = new SysAdmin("Иваныч", ilshat);
            SysAdmin ilya = new SysAdmin("Илья", ivanych);
            SysAdmin vitya = new SysAdmin("Витя", ivanych);
            SysAdmin zhenya = new SysAdmin("Женя", ivanych);


            Developer sergey = new Developer("Сергей", orkadiy);
            Developer lyaysan = new Developer("Ляйсан", sergey);
            Developer marat = new Developer("Марат", lyaysan);
            Developer dina = new Developer("Дина", lyaysan);
            Developer ildar = new Developer("Ильдар", lyaysan);
            Developer anton = new Developer("Антон", lyaysan);


            Task task1 = new Task("Автоматизация отчетности", "бухгалтерии");
            Task task2 = new Task("Настройка серверов", "системщикам");
            Task task3 = new Task("Разработка нового приложения", "разработчикам");


            AssignTask(timur, rashid, task1);
            AssignTask(ilham, ilshat, task2);
            AssignTask(orkadiy, sergey, task3);

            Console.WriteLine("\nДомашнее задание от Тумакова\n");

            Stack<Resident> queueToZina = new Stack<Resident>();
            List<Queue<Resident>> windows = new List<Queue<Resident>>
    {
        new Queue<Resident>(),
        new Queue<Resident>(),
        new Queue<Resident>()
    };

            queueToZina.Push(new Resident("Иван", "123456", new Problem(1, "Нет отопления"), new Temperament(6, true)));
            queueToZina.Push(new Resident("Анна", "789012", new Problem(2, "Ошибка в квитанции"), new Temperament(4, false)));
            queueToZina.Push(new Resident("Петр", "345678", new Problem(3, "Не убран снег у подъезда"), new Temperament(9, true)));

            while (queueToZina.Count > 0)
            {
                Resident resident = queueToZina.Pop();
                int windowIndex = DetermineWindow(resident);

                if (!resident.Temperament.IsSmart)
                {
                    windowIndex = random.Next(0, 3);
                }

                Queue<Resident> window = windows[windowIndex];
                if (resident.Temperament.Scandalousness >= 5)
                {
                    Console.WriteLine($"{resident.Name} скандалист и обгоняет очередь.");
                    Console.Write("На сколько человек обогнать? ");
                    int skip;
                    if (!int.TryParse(Console.ReadLine(), out skip))
                    {
                        skip = 0; 
                    }

                    for (int i = 0; i < skip && window.Count > 0; i++)
                    {
                        var skippedResident = window.Dequeue();
                        window.Enqueue(skippedResident);
                    }
                    window.Enqueue(resident);  
                }
                else
                {
                    window.Enqueue(resident);  
                }
            }

            PrintQueueResults(windows);

        }

        static int DetermineWindow(Resident resident)
        {
            switch (resident.Problem.Number)
            {
                case 1: return 0; 
                case 2: return 1; 
                default: return 2;
            }
        }

        static void PrintQueueResults(List<Queue<Resident>> windows)
        {
            for (int i = 0; i < windows.Count; i++)
            {
                Console.WriteLine($"\nОкно {i + 1}:");
                foreach (var resident in windows[i])
                {
                    Console.WriteLine($"{resident.Name} с проблемой: {resident.Problem.Description}");
                }
            }
        }

    }
}
