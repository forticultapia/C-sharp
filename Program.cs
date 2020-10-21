using System;
using System.Linq;
using System.Linq.Expressions;
//Bajutova Daria
/* /////////////////////Условия:
 * Написать метод возвращающий минимальное из трех чисел;
2. Написать метод подсчета количества цифр числа;
3. С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных
положительных чисел;
4. Реализовать метод проверки логина и пароля. На вход подается логин и пароль. На выходе
истина, если прошел авторизацию, и ложь, если не прошел. Используя метод проверки логина и
пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его
дальше или не пропускает. С помощью цикла do while ограничить ввод пароля тремя попытками;
5. а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс
массы и сообщает, нужно ли человеку похудеть, набрать вес или все в норме;
б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
6. *Написать программу подсчета количества “Хороших” чисел в диапазоне от 1 до 1 000 000.
Хорошим называется число, которое делится на сумму своих цифр. Реализовать подсчет
времени выполнения программы, используя структуру DateTime.
© geekbrains.ru 20
7. a) Разработать рекурсивный метод, который выводит на экран числа от a до b;
б) *Разработать рекурсивный метод, который считает сумму чисел от a до b.
*
*/
namespace Homework2
{
    class Program
    {
        static int [] InputOfArray()
        {
            Console.WriteLine("Input of numbers");
            int i = 0;
            int[] array=new int [3];
            while (i<3)
            {
                array[i] = Int32.Parse(Console.ReadLine());
                i++;
            }
            i = 0;
            Console.Write("Your numbers: ");
            while (i < 3)
            {
                Console.Write(""+(i+1)+"). "+array[i]+"  ");
                i++;

            }
            return array;
            }
        static int Find_Min(int[] array)
        {
            int min = array[0];
            for(int i=1;i<array.Length;i++)
            {
                if (array[i] < min) min = array[i];
            }
            return min;
        }
        static int Length_Of_Number()
        {
            Console.WriteLine("Input your number");
            string num = Console.ReadLine();
            int count = 0;
            try
            {
                if (Convert.ToDouble(num) != 0)
                {
                    foreach (char i in num)
                
                        if (i!=',')
                            count++;
                }
            }
            catch
            {
                Console.WriteLine("Are you not wrong?");
            }
            return count;
        }
        static double Input_While_Not_Zero()
        {
            double sum = 0;
            Console.WriteLine("Input of numbers");
            double i = 0;
            try
            {
                while ((i = Convert.ToDouble(Console.ReadLine())) != 0)
                    if (i > 0 && i % 2 != 0)
                        sum += i;
                return sum;
            }
            catch
            {
                Console.WriteLine("I'm frustraited((");
                return -1;
            }
        }
        static int Authorisation()
        {
            Console.WriteLine("Try to input the login and \\n password. (The login is \"LOGIN\", The password is \"PASSWORD\")");
            int i = 0;
            string login;
            string password;
            int key = 0;
            try
            {
                do
                {
                    login = Console.ReadLine();
                    password= Console.ReadLine();
                    if (login == "LOGIN" && password == "PASSWORD")
                    {
                        key = 1;
                        Console.WriteLine("okey, come in");
                        return 1;
                    }
                    else
                    {
                        i++;
                        Console.WriteLine($"no, its wrong, you can try {3-i} more times");    
                    }
                    
                } while (key==0 && i < 3);

                return 0;
            }
            catch
            {
                Console.WriteLine("I'm frustraited((");
                return 0;
            }
        }
        
        static int Check_Login(string login)
        {
            try
            {
                login=Console.ReadLine();
                return 1;
            }
            catch
            {
                return -1;
            }
        }
        static double IMT(double height, double weight)
        {
            return weight / Math.Pow(height, 2);
        }
        static void Chack_IMT()
        {
            int lower_limit_of_IMB = 20;
            int upper_limit_of_IMB = 25;
            try
            {
                Console.WriteLine("Рост: ");
                double height = Convert.ToDouble(Console.ReadLine())/100f;
                Console.WriteLine("Вес: ");
                double weight = Convert.ToDouble(Console.ReadLine());
                double imb = IMT(height, weight);
                if (imb < 0)
                    Console.WriteLine("I'm frustraited((");
                else if (imb < lower_limit_of_IMB)
                {
                    Console.WriteLine("You are skinny and awersome");
                    Console.WriteLine("{0, 5:#.##}", Math.Pow(height, 2) * (-imb + lower_limit_of_IMB));

                }
                else if (imb >= lower_limit_of_IMB && imb <= upper_limit_of_IMB)
                    Console.WriteLine("You are awersome");
                else if (imb > upper_limit_of_IMB)
                {
                    Console.WriteLine("You are not skinny but awersome");
                    Console.WriteLine("{0, 5:#.##}", Math.Pow(height, 2) * (imb - upper_limit_of_IMB));
                }

                }
            catch
            {
                Console.WriteLine("I'm frustraited((");
            }
            }
        static void Good_Numbers_From_Million()
        {
            int upper_limit = 1000;
            int sum = 0;
            int j = 0;
            int key = 0;

            for (int i = 1; i < upper_limit; i++)
            {
                j = i;
                do
                {
                    sum += j % 10;
                    j /= 10;
                } while (j != 0);
                if (i % sum == 0)
                {
                    Console.Write("{0} ", i);
                    key++;
                    if (key >= 30)
                    {
                        Console.Write("\n");
                        key = 0;
                    }
                }
                sum = 0;

            }
        }
        static void Output(int bottom, int top)
        {
                Console.Write("{0} ", bottom);
                if (bottom+1 <=top)
                    Output(bottom + 1, top);
        }
        static int Sum(int bottom, int top, int sum)
        {
            if (bottom + 1 <= top)
            {
                sum += bottom;
                Sum(bottom + 1, top, sum);
            }
            return sum;
        }
        static void Recursive_output(int key)
        {
            Console.Write("The lower limit of list: ");
            int lower_limit = Convert.ToInt32(Console.ReadLine());
            Console.Write("The upper limit of list: ");
            int upper_limit = Convert.ToInt32(Console.ReadLine());
            if (key == 1)
                Output(lower_limit, upper_limit);
            else
            {
                Console.Write("The sum of ");
                Output(lower_limit, upper_limit);
                Console.Write($" is : {Sum(lower_limit, upper_limit, 0)}");
            }




        }
        static void Main(string[] args)
        {
            Console.WriteLine("The second homewor in geekbrains");
            int number = 1;
            
            while (number > 0 || number < 5)
            {
                try { 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n1) find min\n2) Length of numbers\n3) Sum of odd & positive until zero\n4) Authorisation\n5) IMB\n6) The search of good numbers\n7) Recursive output\n8) Recursive sum\n9) Exit\n");
                Console.ForegroundColor = ConsoleColor.White;
                number = Convert.ToInt32(Console.ReadLine());

                    switch (number)
                    {
                        case 1:
                            //метод возвращающий минимальное из трех чисел;
                            Console.WriteLine("\nThe minimal number is: " + Find_Min(InputOfArray()));
                            break;
                        case 2:
                            //Написать метод подсчета количества цифр числа;
                            Console.WriteLine("The Length of your number is:" + Length_Of_Number());
                            break;
                        case 3:
                            //С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел;
                            Console.WriteLine(Input_While_Not_Zero());
                            break;
                        case 4:
                            //Реализовать метод проверки логина и пароля.
                            Authorisation();
                            break;
                        case 5:
                            //индекс массы
                            Chack_IMT();
                            break;
                        case 6:
                            //программa подсчета количества “Хороших” чисел в диапазоне от 1 до 1 000 000
                            Good_Numbers_From_Million();
                            break;
                        case 7:
                            Recursive_output(1);
                            break;
                        case 8:
                            Recursive_output(2);
                            break;
                        default:

                            Console.WriteLine("Have a nice day!");//TASK_6
                                                                 //Pause();
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
