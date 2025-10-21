using System;
using System.Threading.Channels;

namespace OOP_Lab2
{

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine($"""
                Виберіть завдання яке виконувати:
                1 - Завдання з матрицями.
                2 - Завдання з структур.
                0 - Вийти з програми.
                """);

            int choice;
            do
            {
                Console.Write("Приклад введення числа 1 або 2 та 0 для виходу з програми: \n");
                choice = int.Parse(Console.ReadLine());
            } while (choice != 1 && choice != 2 && choice != 0);
            Console.Clear();

            switch (choice)
            {
                case 1:
                    OneExe();
                    break;
                case 2:
                    TwoExe();
                    break;
                case 0:
                    return;
            }


        }
        static void OneExe()
        {
            Console.WriteLine($"""
                Виберіть як хочете виконувати:
                1 - Подивитися тести програми,всіх методів.
                2 - Заповнювати самостійно.
                0 - Вийти в меню.
                """);
            int choice;
            do
            {
                Console.Write("Приклад введення числа 1 або 2 та 0 для виходу в меню: ");
                choice = int.Parse(Console.ReadLine());
            } while (choice != 1 && choice != 2 && choice != 0);
            Console.Clear();

            switch (choice)
            {
                case 1:
                    Test();
                    break;
                case 2:
                    ManualInput();
                    break;
                case 0:
                    Program.Main();
                    break;
            }

            void Test()
            {

                Console.WriteLine("=== Тести конструкторів MyMatrix ===\n");


                double[,] arr = { { 1, 2 }, { 3, 4 } };
                MyMatrix m1 = new MyMatrix(arr);
                Console.WriteLine("Конструктор двовимірного масиву:");
                Console.WriteLine(m1);
                Console.WriteLine();

                double[][] jag = new double[][]
                {
                   new double[] { 5, 6 },
                   new double[] { 7, 8 }
                };
                MyMatrix m2 = new MyMatrix(jag);
                Console.WriteLine("Конструктор зубчастого масиву:");
                Console.WriteLine(m2);
                Console.WriteLine();

                string[] lines = { "9 10", "11 12" };
                MyMatrix m3 = new MyMatrix(lines);
                Console.WriteLine("Конструктор string:");
                Console.WriteLine(m3);
                Console.WriteLine();


                MyMatrix m4 = new MyMatrix(m3);
                Console.WriteLine("Копіюючий конструктор:");
                Console.WriteLine(m4);
                Console.WriteLine();

                string singleLineString = @"13 14
15 16"; // МОЖНА БУЛО \n
                MyMatrix m5 = new MyMatrix(singleLineString);
                Console.WriteLine("Конструктор string з переносами рядків:");
                Console.WriteLine(m5);
                Console.WriteLine();


                Console.WriteLine("Індексатор:");
                Console.WriteLine($"m1[0,1] = {m1[0, 1]}");
                m1[0, 1] = 99;
                Console.WriteLine("Після зміни m1[0,1] = 99:");
                Console.WriteLine(m1);
                Console.WriteLine();

                Console.WriteLine("Додавання m1 + m2:");
                MyMatrix sum = m1 + m2;
                Console.WriteLine(sum);
                Console.WriteLine();


                Console.WriteLine("Множення m1 * m2:");
                MyMatrix prod = m1 * m2;
                Console.WriteLine(prod);
                Console.WriteLine();

                Console.WriteLine("Транспонування m1 (копія):");
                MyMatrix transposed = m1.GetTransponedCopy();
                Console.WriteLine(transposed);
                Console.WriteLine();

                Console.WriteLine("Транспонування m1 на місці:");
                m1.TransponeMe();
                Console.WriteLine(m1);
                Console.WriteLine();

                Console.WriteLine($"m1 Height = {m1.Height}, Width = {m1.Width}");
                Console.WriteLine($"m2 getHeight() = {m2.getHeight()}, getWidth() = {m2.getWidth()}");

                Console.WriteLine("Повернутися в меню?: 1 - Так,якщо ні - введіть любий символ.");
                
                string ab = Console.ReadLine();
                if (ab == "1")
                {
                    Console.Clear();
                    Program.Main();
                }
                else
                    return;



            }

            void ManualInput()
            {
                Console.WriteLine("Введіть матрицю рядок за рядком (числа через пробіл).");
                Console.WriteLine("Щоб завершити, натисніть Enter на порожньому рядку.");

                List<string> lines = new List<string>();
                while (true)
                {
                    string line = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) break;
                    lines.Add(line);
                }

                if (lines.Count == 0)
                {
                    Console.WriteLine("Матриця порожня!");
                    return;
                }

                MyMatrix matrix;
                try
                {
                    matrix = new MyMatrix(lines.ToArray());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Помилка при створенні матриці: " + ex.Message);
                    return;
                }

                Console.WriteLine("\nВаша матриця:");
                Console.WriteLine(matrix);

                while (true)
                {
                    Console.WriteLine($"""
                        Оберіть операцію:
                        
                     1 - Додати ще одну матрицю;
                     2 - Помножити на ще одну матрицю;
                     3 - Транспонувати (копія);
                     4 - Транспонувати на місці;
                     5 - Вивести розміри (Height, Width);
                     0 - Вийти в меню.
                     """);

                    int choice;
                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Введіть число!");
                        continue;
                    }

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Введіть другу матрицю для додавання:");
                            List<string> addLines = new List<string>();
                            while (true)
                            {
                                string line = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(line)) break;
                                addLines.Add(line);
                            }
                            try
                            {
                                MyMatrix m2 = new MyMatrix(addLines.ToArray());
                                MyMatrix sum = matrix + m2;
                                Console.WriteLine("Результат додавання:");
                                Console.WriteLine(sum);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Помилка: " + ex.Message);
                            }
                            break;

                        case 2:
                            Console.WriteLine("Введіть другу матрицю для множення:");
                            List<string> mulLines = new List<string>();
                            while (true)
                            {
                                string line = Console.ReadLine();
                                if (string.IsNullOrWhiteSpace(line)) break;
                                mulLines.Add(line);
                            }
                            try
                            {
                                MyMatrix m3 = new MyMatrix(mulLines.ToArray());
                                MyMatrix prod = matrix * m3;
                                Console.WriteLine("Результат множення:");
                                Console.WriteLine(prod);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Помилка: " + ex.Message);
                            }
                            break;

                        case 3:
                            MyMatrix trans = matrix.GetTransponedCopy();
                            Console.WriteLine("Транспонована копія:");
                            Console.WriteLine(trans);
                            break;

                        case 4:
                            matrix.TransponeMe();
                            Console.WriteLine("Матриця після транспонування на місці:");
                            Console.WriteLine(matrix);
                            break;

                        case 5:
                            Console.WriteLine($"Height = {matrix.Height}, Width = {matrix.Width}");
                            break;

                        case 0:
                            Console.Clear();
                            Program.Main();
                            break;



                        default:
                            Console.WriteLine("Невідомий варіант");
                            break;


                    }
                }





            }



        }

        static void TwoExe()
        {

            Console.WriteLine("Введіть перший дріб у форматі a/b:");
            string[] arr = Console.ReadLine().Split('/');
            MyFrac f1 = new MyFrac(long.Parse(arr[0]), long.Parse(arr[1]));

            
            Console.WriteLine("Введіть другий дріб у форматі a/b:");
            string[] arr2 = Console.ReadLine().Split('/');
            MyFrac f2 = new MyFrac(long.Parse(arr2[0]), long.Parse(arr2[1]));

            
            Console.WriteLine("Введіть число n:");
            int n = int.Parse(Console.ReadLine());

            
            MyFrac.PrintOperations(f1, f2, n);
        }
    }
}
