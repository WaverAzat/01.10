using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
namespace Homework
{
    enum LvlAnge
    {
        добрый = 1, ворчит = 2, злой = 3, очень_злой = 4
    }
    struct Ded
    {
        public string name;
        public byte lvlanger;
        public string[] phrases;
        public byte hits;
        public Ded(string Name, byte LvlAnger, string[] Phrases, byte Hits)
        {
            this.name = Name;
            this.lvlanger = LvlAnger;
            this.phrases = Phrases;
            this.hits = Hits;
        }
    }
    class Program
    {
        static byte Zadanie6(Ded ded, params string[] array)
        {
            foreach (string i in ded.phrases)
            {
                if (array.Contains(i))
                {
                    ded.hits += 1;
                }
            }
            return ded.hits;
        }
        static void Zadanie1()
        {
            Console.WriteLine("Задание 1.Квадратное уравнение");
            Console.WriteLine("Введите коэффициент a");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите коэффициент b ");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите коэффициент c");
            int c = int.Parse(Console.ReadLine());
            double diss = b * b - 4 * a * c;
            if (diss < 0)
            {
                Console.WriteLine("Корней не существует");
            }
            else if (diss == 0)
            {
                double x3 = -b / (2 * a);
                Console.WriteLine("Корень уравнения: {0}", x3);
            }
            else if (diss > 0)
            {
                double x1 = (-b - Math.Sqrt(diss)) / (2 * a);
                double x2 = (-b + Math.Sqrt(diss)) / (2 * a);
                Console.WriteLine("Корни уравнения {0},{1}", x1, x2);
            }
        }
        static void Zadanie2()
        {
            Console.WriteLine("Задание 2.Меняем структуру массива");
            Random rnd = new Random();
            int[] a = new int[20];
            a[0] = rnd.Next(0, 101);
            for (int i = 1; i < 20;)
            {
                int num = rnd.Next(0, 101);
                int j;
                for (j = 0; j < i; j++)
                {
                    if (num == a[j])
                        break;
                }
                if (j == i)
                {
                    a[i] = num;
                    i++;
                }
            }
            Console.WriteLine(String.Join(" ", a));
            Console.WriteLine("Введите 2 числа (которые хотите поменять)");
            int ind1 = Array.IndexOf(a, int.Parse(Console.ReadLine()));
            int ind2 = Array.IndexOf(a, int.Parse(Console.ReadLine()));
            (a[ind1], a[ind2]) = (a[ind2], a[ind1]);
            Console.WriteLine(string.Join(" ", a));
        }
        static int[] Zadanie3(int[] mas)
        {
            Console.WriteLine("Задание 3.Сортировка одномерного массива пузырьком");
            int temp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }
        static int Zadanie4(ref int n1, out double n2, params int[] array)
        {
            Console.WriteLine("Задание 4.Params,out,ref");
            for (int i = 0; i < array.Length; i++)
            {
                n1 *= array[i];
            }
            Console.WriteLine("Произведение массива: {0}", n1);
            n2 = array.Sum() / array.Length;
            Console.WriteLine("Среднее арифметическое массива: {0}", n2);
            int n4 = array.Sum();
            Console.WriteLine("Сумма массива");
            return n4;
        }
        static void Zadanie5()
        {
            Console.WriteLine("Задание 5.Зарисовка числа");
            var numbers = new Dictionary<int, string>()
            {
                [0] = "###" + "\n" + "# #" + "\n" + "# #" + "\n" + "# #" + "\n" + "###",
                [1] = " # " + "\n" + "## " + "\n" + " # " + "\n" + " # " + "\n" + "###",
                [2] = " # " + "\n" + "# #" + "\n" + "  #" + "\n" + " # " + "\n" + "###",
                [3] = "## " + "\n" + "  #" + "\n" + " # " + "\n" + "  #" + "\n" + "## ",
                [4] = "# #" + "\n" + "# #" + "\n" + "###" + "\n" + "  #" + "\n" + "###",
                [5] = "###" + "\n" + "#  " + "\n" + "###" + "\n" + "  #" + "\n" + "## ",
                [6] = " ##" + "\n" + "#  " + "\n" + "###" + "\n" + "# #" + "\n" + "###",
                [7] = "###" + "\n" + "  #" + "\n" + "  #" + "\n" + " # " + "\n" + " # ",
                [8] = "###" + "\n" + "# #" + "\n" + " # " + "\n" + "# #" + "\n" + "###",
                [9] = "###" + "\n" + "# #" + "\n" + "###" + "\n" + "  #" + "\n" + "###",
            };
            Console.WriteLine("Введите число(0) либо завершите работу(1)");
            int input = int.Parse(Console.ReadLine());
            if (input == 0)
            {
                try
                {
                    Console.WriteLine("Введите число");
                    int vvod = int.Parse(Console.ReadLine());
                    if (vvod >= 0 && vvod <= 9)
                    {
                        Console.WriteLine(numbers[vvod]);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка!!!");
                        System.Threading.Thread.Sleep(3000);
                        Console.ResetColor();
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Напишите закрыть или exit...");
                string exit = Console.ReadLine();
                if (exit == "exit" || exit == "Exit" || exit == "закрыть" || exit == "Закрыть")
                {
                    Environment.Exit(0);
                }
            }
        }
        static int[] Zadanie7(int[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                Zadanie7(array, leftIndex, j);
            if (i < rightIndex)
                Zadanie7(array, i, rightIndex);
            return array;
        }

        static void Main(string[] args)
        {
            int n1 = 1;// для 4 задания
            double n2 = 1;// для 4 задания
            Console.WriteLine("Zadanie1" + "\n");
            Zadanie1();
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Zadanie2" + "\n");
            Zadanie2();
            Console.ReadKey();
            Console.Clear();
            int[] n3 = { 11, 42, 23, 2, 50, 7, 10, 9, 86, 87, 44, 22, 13 };
            Console.WriteLine("Zadanie3" + "\t" + string.Join(" ", Zadanie3(n3)));
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(Zadanie4(ref n1, out n2,n3));
            Console.ReadKey();
            Console.Clear();
            Zadanie5();
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Задание 6.Деды");
            string[] d1 = { "проституки!", "гады" };
            Ded ded1 = new Ded("Дим Димыч", 1, d1, 0);
            string[] d2 = { "проститутки!", "тимоплеер", "гандон" };
            Ded ded2 = new Ded(" Александр Долгопопов ", 2, d2, 0);
            string[] d3 = { "проституки!", "гады", "сын бляди!", "тимоплеер", "юмиплеер" };
            Ded ded3 = new Ded("Инсаф Акбиров", 3, d3, 0);
            string[] d4 = { "проституки!", "хорошая работа олег" };
            Ded ded4 = new Ded("Роман Бокчарев", 1, d4, 0);
            string[] d5 = { "проституки!", "камень я не дам._." };
            Ded ded5 = new Ded("Максим Иванов", 4, d5, 0);
            string[] slova = { "проституки!", "гады", "водка", "пиво", "самогон", "михалыч", "сын бляди!", "тимоплеер", "юмиплеер" };
            Console.WriteLine("Кол-во синяков от бабки: " + Zadanie6(ded1, slova));
            Console.WriteLine("Кол-во синяков от бабки: " + Zadanie6(ded2, slova));
            Console.WriteLine("Кол-во синяков от бабки: " + Zadanie6(ded3, slova));
            Console.WriteLine("Кол-во синяков от бабки: " + Zadanie6(ded4, slova));
            Console.WriteLine("Кол-во синяков от бабки: " + Zadanie6(ded5, slova));
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(string.Join(" ", Zadanie7(n3, 0, n3.Length - 1)));
            Console.ReadKey();
        }
    }
}
    