using System;
/*
 * 1. а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.
Продемонстрировать работу структуры;
б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить
работу класса;
2. а) Из файла вводятся числа, пока не будет введен 0 (каждое число в новой строке). Требуется
подсчитать сумму всех нечетных положительных чисел. Сами числа и сумму вывести на экран;
б) Добавить обработку исключительной исключений на то, что в файле могут быть не
корректные данные. При возникновении ошибки вывести сообщение.
3. *Описать класс дробей ­ рациональных чисел, являющихся отношением двух целых чисел.
Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать
программу, демонстрирующую все разработанные элементы класса. Достаточно решить 2
задачи. Все программы сделайть в одном решении.
*/
namespace Homework3
{
    struct Complex
    {
        public double im;
        public double re;
        public Complex Plus(Complex x)
        {
            Complex y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }
        public Complex Mult(Complex x)
        {
            Complex y;
            y.re = re * x.re + im * x.im;
            y.im = re * x.im + im * x.re;
            return y;
        }
        public Complex Minus(Complex x)
        {
            Complex y;
            y.re = re - x.re;
            y.im = im - x.im;
            return y;
        }
        public string ToString()
        {
            if (im < 0) return re + "" + im + "i";
            else return re + "+" + im + "i";
        }
    }

    class task1_a
    {
        static Complex Init(double re, double im)
        {
            Complex var;
            var.im = im;
            var.re = re;
            return var;
        }
        static void Input(out Complex var)
        {
            Console.Write("input Re:");
            double re = Convert.ToDouble(Console.ReadLine());
            Console.Write("input Im:");
            double im = Convert.ToDouble(Console.ReadLine());
            var = Init(re, im);
        }
        static void Main(string[] args)
        {

            Console.WriteLine("The third homewor in geekbrains. Task 1(a)");

            int number = 1;

            Complex var1 = Init(0, 0);
            Complex var2 = Init(0, 0);
            int key = 1;
            while (number > 0 || number < 5)
            {
                try
                {
                Label:
                    if (key == 1)
                    {
                        Console.WriteLine("Input of first number: ");
                        Input(out var1);
                        Console.WriteLine("Input of second number: ");
                        Input(out var2);
                    }
                    else
                    {
                        Console.WriteLine($"To continue with result {var1.ToString()} ? (yes/no)");
                        if (Console.ReadLine() == "yes")
                        {
                            Console.WriteLine("Input of second number: ");
                            Input(out var2);
                        }
                        else
                        {
                            key = 1;
                            goto Label;
                        }
                    }
                    key = 0;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{var1.ToString()} ? {var2.ToString()} = RESULT");
                    Console.WriteLine("\n1) Fold\n2) Subtract\n3) Multiply\n4) Exit\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    number = Convert.ToInt32(Console.ReadLine());

                    switch (number)
                    {
                        case 1:
                            Console.Write($"{var1.ToString()}+{var2.ToString()}=");
                            Console.WriteLine(var1.Plus(var2).ToString());
                            var1 = var1.Plus(var2);
                            break;
                        case 2:
                            Console.Write($"{var1.ToString()}-{var2.ToString()}=");
                            Console.WriteLine(var1.Minus(var2).ToString());
                            var1 = var1.Minus(var2);
                            break;
                        case 3:
                            Console.Write($"({var1.ToString()})*({var2.ToString()})=");
                            Console.WriteLine(var1.Mult(var2).ToString());
                            var1 = var1.Mult(var2);
                            break;
                        default:
                            Console.WriteLine("Have a nice day!");//TASK_6
                            Environment.Exit(0);
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Input some number in {1...6}");//TASK_6
                }
            }
        }
    }
}