using System;
using System.Threading;
//Bajutova Daria
/* /////////////////////Условия:
 Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку:
а) используя  склеивание;
	б) используя форматированный вывод;
	в) используя вывод со знаком $.
Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах.


а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);
б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.
Написать программу обмена значениями двух переменных:
а) с использованием третьей переменной;
	б) *без использования третьей переменной.
а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
б) *Сделать задание, только вывод организовать в центре экрана.
в) **Сделать задание б с использованием собственных методов (например, Print(string ms, int x,int y).
*Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause).
*/
namespace Homework1
{
    class Program
    {
        static void Anketa_vvod(out double height, out double weight, out string f_name, out string l_name)
        {
            Console.WriteLine("Привет! Ваше имя: ");
            f_name = Console.ReadLine();
            Console.WriteLine("Фамилия:");
            l_name = Console.ReadLine();
            Console.WriteLine("Возраст: ");
            int age = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Рост: ");
            height = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Вес: ");
            weight = Convert.ToDouble(Console.ReadLine());
            // with format blocks
            Console.WriteLine("Ваше имя:{0}, Фамилия: {1}, Возраст: {2}, Рост: {3}, Вес: {4}", f_name, l_name, age, height, weight);
            //gluing
            //Console.WriteLine("Ваше имя:" + f_name + ", Фамилия: " + l_name + ", Возраст: " + age + ", Рост: " + height + ", Вес: " + weight + "");
            //$
            //Console.WriteLine($"Ваше имя:{f_name}, Фамилия: {l_name}, Возраст: {age}, Рост: {height}, Вес: {weight}");
        }
        static double IMT(double height, double weight)
        {
            while (height <= 0 || weight <= 0)
            {
                Console.WriteLine("Рост: ");
                height = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Вес: ");
                weight = Convert.ToDouble(Console.ReadLine());
            }
            height /= 100f;
            return weight / Math.Pow(height, 2);
        }
        static double dist()
        {
            Console.WriteLine("First point\nX: ");
            double x1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Y: ");
            double y1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Second point\nX: ");
            double x2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Y: ");
            double y2 = Convert.ToDouble(Console.ReadLine());
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

        }
        static void changing()
        {
            int one = 0, two = 0;
            Console.WriteLine("Input of numbers\nX: ");
            one = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Y: ");
            two = Convert.ToInt32(Console.ReadLine());
            int three = one;
            one = two;
            two = three;
            Console.WriteLine("New numbers\nX: {0}, Y:{1}", one, two);
        }
        static void changing_no_temp()
        {
            int one = 0, two = 0;
            Console.WriteLine("Input of numbers\nX: ");
            one = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Y: ");
            two = Convert.ToInt32(Console.ReadLine());
            one += two;
            two = one - two;
            one -= two;
            Console.WriteLine("New numbers\nX: {0}, Y:{1}", one, two);
        }
        static void Anketa2(string f_name, string l_name)
        {
            if (String.IsNullOrEmpty(f_name)==true || String.IsNullOrEmpty(l_name) == true)
            {
                Console.WriteLine("Привет! Ваше имя: ");
                f_name = Console.ReadLine();
                Console.WriteLine("Фамилия:");
                l_name = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Я правильно помню, что вас зовут {0} {1}? (Да/Нет)", l_name, f_name);
                if(Console.ReadLine()=="Нет")
                {
                    Console.WriteLine("Ваше имя: ");
                    f_name = Console.ReadLine();
                    Console.WriteLine("Фамилия:");
                    l_name = Console.ReadLine();
                }
            }
            Console.WriteLine("Город: ");
            string sity = Console.ReadLine();
            string answer = $"Имя:{f_name} Фамилия: {l_name} Город: {sity}";
            Console.WriteLine("Вывести в центре?(Да/Нет)");

            if (Console.ReadLine() == "Да")
                Print(answer);
            else
                Console.WriteLine(answer);

        }
        static void Pause()
        {
            Console.ReadKey();
        }
        static void Print(string msg)
        {
            Console.Clear();
            int X = Console.WindowWidth/2 - msg.Length/2;
            int Y = Console.WindowHeight/2 - 1;
            Console.SetCursorPosition(X, Y);
            Console.Write(msg);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("The first homewort in geekbrains");
            double height = 0, weight = 0;
            string f_name="", l_name="";
            int number = 1;
            while (number > 0 || number < 5)
            {
                Console.ForegroundColor=ConsoleColor.Red;
                Console.WriteLine("\n1-anketa, 2-IMT, 3-distance, 4-change, 5-change_no_temp, 6-anketa №2");
                Console.ForegroundColor = ConsoleColor.White;
                number = Convert.ToInt32(Console.ReadLine());

                switch (number)
                {
                    case 1:
                        Anketa_vvod(out height, out weight, out f_name, out l_name); //TASK_1
                        break;
                    case 2:
                        Console.WriteLine("IMT+ " + IMT(height, weight) + ""); //TASK_2
                        break;
                    case 3:
                        Console.WriteLine("The distance:{0}", dist());//TASK_3
                        break;
                    case 4:
                        changing();//TASK_4
                        break;
                    case 5:
                        changing_no_temp();//TASK_4*
                        break;
                    case 6:
                        Anketa2(f_name, l_name);//TASK_5
                        break;
                    default:
                        Console.WriteLine("Have a nice day!");//TASK_6
                        Pause();
                        Environment.Exit(0);
                        break;



                }
            }

        }
    }
}
