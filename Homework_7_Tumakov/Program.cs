

namespace Homework_7_Tumakov
{
    internal class Program
    {

        /// <summary>
        /// Метод, который реверсирует строку. (Для Упражнение 8.2)
        /// </summary>
        /// <param name="line">Строка, которая будет реверсирована.</param>
        /// <returns>Реверсированная строка.</returns>
        static public string ReverseLine(string line)
        {
            char[] charArr = line.ToCharArray();
            Array.Reverse(charArr);
            return new string(charArr); 
        }

            


        static public void Work_with_file()
        {
            Console.WriteLine("Введите имя файла: \nПример ввода: input.txt\n");
            string inputFilePath = Console.ReadLine();
            string outputFilePath = "Finalfile.txt";
            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Файл не найден!");
                return;
            }
            else if (string.IsNullOrWhiteSpace(inputFilePath))
            {
                Console.WriteLine("Имя файла не может быть пустым!");
                return;
            }
            else
            {
                try
                {
                    using (StreamReader reader = new StreamReader(inputFilePath))
                    {
                        using (StreamWriter writer = new StreamWriter(outputFilePath))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                writer.WriteLine(line.ToUpper());
                            }
                        }
                    }
                    Console.WriteLine($"Данные успешно скопированы из {inputFilePath} в {outputFilePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }

                
            }

        }

        //Реализовать метод, который проверяет реализует ли входной парамет
        //метода интерфейс System.IFormattable.Использовать оператор is и as. (Интерфейс
        //IFormattable обеспечивает функциональные возможности форматирования значения объекта
        //в строковое представление.)

        static void CheckMethodImplement(object obj)
        {
            
            if (obj is IFormattable formattable && obj is string)
            {
                Console.WriteLine("Данный входной параметр можно реализовать с помощью IFormattable и это строка.");
            }
            else if (obj is IFormattable)
            {
                Console.WriteLine("Данный входной параметр можно реализовать с помощью IFormattable.");
            }
            else
            {
                Console.WriteLine("Данный входной параметр не реализуется с помощью IFormattable.");
            }

            
            IFormattable str_check = obj as IFormattable;
            if (str_check != null && obj is string)
            {
                Console.WriteLine("Данный входной параметр можно реализовать с помощью IFormattable и это строка. ");
            }
            else if (str_check != null)
            {
                Console.WriteLine("Данный входной параметр можно реализовать с помощью IFormattable");
            }
            else
            {
                Console.WriteLine("Данный входной параметр не реализуется с помощью IFormattable. ");
            }
        }

        static public void WorkFileForDz(string FileName)
        {
            
            
            Console.WriteLine("Введите название файла, в который мы перепишем почту: ");
            string outputFilePath = Console.ReadLine();

            if(!File.Exists(FileName))
            {
                Console.WriteLine("Файл не найден.");
                return;
            }

            using (StreamWriter writer  = new StreamWriter(outputFilePath))
            {

                foreach (var line in File.ReadLines(FileName))
                {
                    string email = line;
                    SearchEmail(ref email);
                    if (!string.IsNullOrEmpty(email))
                    {
                        writer.WriteLine(email);
                        
                    }
                }


            }

        }

        static private void SearchEmail(ref string s)
        {
            var parts = s.Split("#");

            if (parts.Length > 1)
            {
                s = parts[1].Trim();
            }
            else
            {
                s = ""; 
            }
        }

        static void Main(string[] args)
        {
           
            Console.WriteLine("Упражнение 8.1");
            Bank_account account1 = new Bank_account(500m, 300m); 
            account1.Id = 1;

            Bank_account account2 = new Bank_account(200m, 100m); 
            account2.Id = 2;

            Console.WriteLine($"Счет 1 - Текущий: {account1.CurrentAccount}, Сберегательный: {account1.SavingsAccount}");
            Console.WriteLine($"Счет 2 - Текущий: {account2.CurrentAccount}, Сберегательный: {account2.SavingsAccount}");

            try
            {
                account1.TransferFunds(account1, account2, 100m);
                Console.WriteLine($"После перевода:");
                Console.WriteLine($"Счет 1 - Текущий: {account1.CurrentAccount}, Сберегательный: {account1.SavingsAccount}");
                Console.WriteLine($"Счет 2 - Текущий: {account2.CurrentAccount}, Сберегательный: {account2.SavingsAccount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            Console.WriteLine("\nУпражнение 8.2\n");
            Console.WriteLine(ReverseLine("Bye Bye"));

            Console.WriteLine("Упражнение 8.3");

            Work_with_file();

            Console.WriteLine("Упражнение 8.4\n");

            CheckMethodImplement("Привет");
            CheckMethodImplement(123);

            Console.WriteLine("Домашнее задание 8.1");

            WorkFileForDz("FileForDZ.txt");

            Console.WriteLine("Доашнее задание 8.2");

            List<Song> songs = new List<Song>();
            Song previousSong = null;

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"\nВведите данные для песни {i + 1}:");
                Song song = new Song();
                song.EnterName();
                song.EnterAuthor();

                if (previousSong != null)
                {
                    song.EnterPrev(previousSong);
                }

                previousSong = song;
                songs.Add(song);
            }

            Console.WriteLine("\nСписок песен:");
            foreach (var song in songs)
            {
                Console.WriteLine(song.Title());
            }

            if (songs.Count >= 2)
            {
                bool areEqual = songs[0].Equals(songs[1]);
                Console.WriteLine($"\nПервая и вторая песни {(areEqual ? "равны" : "различны")}.");
            }

        }


    }
    
}
