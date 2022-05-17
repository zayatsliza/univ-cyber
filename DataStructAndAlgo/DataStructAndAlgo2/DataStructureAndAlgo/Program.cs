using System;
using System.Threading;

namespace DataStructureAndAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter task:");

            while (true)
            {
                Console.WriteLine("\n\t1 - Check the placement of brackets");
                Console.WriteLine("\n\t2 - Find minimum negative number");
                Console.WriteLine("\n\t3 - Postfix form");
                Console.WriteLine("\n\t4 - Queue");
                Console.WriteLine("\n");
                string c = Console.ReadLine();
                switch (c)
                {
                    case "1":
                        Task1 task1 = new Task1();
                        task1.Write();
                        break;
                    case "2":
                        Task2 task2 = new Task2();
                        task2.Write();
                        break;
                    case "3":
                        Task3 task3 = new Task3();
                        task3.Write();
                        break;
                    case "4":
                        Task4 task4 = new Task4();
                        task4.Write();
                        break;
                    default:
                        return;
                }
                Console.WriteLine("\n\nEnter task:");

            }
        }

        // клас Колекція, від якого будуть унаслідуватися інші класи 
        class Collection<T>
        {
            protected T[] Array = new T[0];
            public int Count = 0;

            // в кожної колекції буде метод додавання в кінець
            public void Add(T element)
            {
                System.Array.Resize(ref Array, Count + 1);
                Array[Count] = element;
                Count++;
            }

            // в кожної колекції буде метод вивести масив
            public void Print()
            {
                foreach (T el in Array)
                {
                    Console.Write(" " + el);
                }
            }
        }

        // клас Черга
        class Queue<T> : Collection<T>
        {

            // метод видалення першого елемента черги
            public void Remove()
            {

                for (int i = 0; i < Count - 1; i++)
                {
                    Array[i] = Array[i + 1];
                }
                System.Array.Resize(ref Array, Count - 1);
                Count--;
            }
        }

        // Клас черги для цілих чисел (додаткові методи для завдання 4)

        class Queue : Queue<int>
        {

            // оновлює чергу (завдання 4)
            public void Refresh()
            {
                if (Array[0] > 1)
                {
                    Array[0]--;
                }
                else if (Count > 0)
                {
                    Remove();
                }
            }

            // рахує кількість одиниць товару в черзі (завдання 4)
            public int Sum()
            {
                int sum = 0;
                foreach (int num in Array)
                {
                    sum += num;
                }
                return sum;
            }

        }

        // клас Стек
        class Stack<T> : Collection<T>
        {
            public void Remove()
            {
                System.Array.Resize(ref Array, Count - 1);
                Count--;
            }

            // показує останній елемент стеку
            public T Last()
            {
                return Array[Count - 1];
            }

        }

        // клас Список
        class List<T> : Collection<T>
        {

            // метод додавання за індексом
            public void Add(int index, T item)
            {
                System.Array.Resize(ref Array, ++Count);
                for (int i = Count - 1; i > index; i++)
                {
                    Array[i] = Array[i - 1];
                }
                Array[index] = item;
            }

            // метод видалення за індексом
            public void RemoveAt(int index)
            {
                Count--;
                for (int i = index; i < Count - 1; i++)
                {
                    Array[i] = Array[i + 1];
                }
                System.Array.Resize(ref Array, Count);
            }

            // метод видалення за елементом
            public void Remove(T item)
            {
                int index = IndexOF(item);
                if (index != -1)
                {
                    RemoveAt(index);
                }
            }

            public T First()
            {
                return Array[0];
            }

            // показує елемент за індексом
            public T At(int index)
            {
                return Array[index];
            }

            // показує індекс елемента
            public int IndexOF(T element)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (Array[i].Equals(element))
                    {
                        return i;
                    }
                }

                return -1;
            }
        }

        // клас Ліст для цілих чисел (для завдання 2)
        class List : List<int>
        {

            // сортує список за зростанням
            public void Sort()
            {
                for (int i = 0; i < Count; i++)
                {
                    for (int j = 0; j < Count - 1; j++)
                    {
                        if (Array[j] > Array[j + 1])
                        {
                            int tmp = Array[j];
                            Array[j] = Array[j + 1];
                            Array[j + 1] = tmp;
                        }
                    }
                }
            }
        }

        class Task1
        {
            string given;

            public Task1() { }

            public Task1(string given)
            {
                this.given = given;
            }

            public void Write()
            {
                Console.WriteLine("__________________________ Task 1 __________________________\n");
                Console.WriteLine(" Write down brackets you want to check:");
                given = Console.ReadLine();// вводимо рядок з дужками
                if (Check())// результат перевірки
                {
                    Console.WriteLine("\n Brackets are places correctly");
                }
                else
                {
                    Console.WriteLine("\n Brackets are placed incorrectly");
                }
            }

            public bool Check()
            {
                Stack<char> stack = new Stack<char>(); // використовуємо стек

                try
                {
                    foreach (char c in given)
                    {
                        switch (c)
                        {
                            case '{':
                                stack.Add(c);
                                break;
                            case '(':
                                stack.Add(c);
                                break;
                            case '[':
                                stack.Add(c);
                                break;
                            case '}':
                                if (stack.Last() == '{')
                                {
                                    stack.Remove();
                                    break;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            case ')':
                                if (stack.Last() == '(')
                                {
                                    stack.Remove();
                                    break;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            case ']':
                                if (stack.Last() == '[')
                                {
                                    stack.Remove();
                                    break;
                                }
                                else
                                {
                                    throw new Exception();
                                }
                            default:
                                break;
                        }
                    }
                }
                catch
                {
                    return false;
                }

                if (stack.Count == 0)
                {
                    return true;
                }

                return false;
            }
        }

        class Task2
        {
            List list;
            int min;

            public void Write()
            {
                Console.WriteLine("__________________________ Task 2 __________________________\n");
                list = new List();
                Get();
                if (Check())
                {
                    Console.WriteLine("\n Minimum negative number is: " + min);
                }
                else
                {
                    Console.WriteLine("\n There are no negative numbers");
                }
            }

            void Get() // вводимо числа
            {
                Console.WriteLine(" Enter numbers (0 is the end of list):");
                while (true)
                {
                    string c = Console.ReadLine();
                    try
                    {
                        int i = Int32.Parse(c);
                        if (i == 0)
                        {
                            return;
                        }
                        else
                        {
                            list.Add(i);
                        }
                    }
                    catch { }
                }
            }

            bool Check()
            {
                min = 0;
                list.Sort();
                try
                {
                    min = list.First();
                    if (min >= 0)
                    {
                        return false;
                    }
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        class Task3
        {
            string s;
            int length;
            List<string> postfix;

            public Task3()
            {
                postfix = new List<string>();
            }

            public void Write()
            {
                Console.WriteLine("__________________________ Task 3 __________________________\n");
                Console.WriteLine(" Enter the expression:");
                s = Console.ReadLine();
                length = s.Length;

                if (Check())
                {
                    Postfix();
                    Console.WriteLine("\n Postfix form:");
                    postfix.Print();
                    Calculate();
                }
                else
                {
                    Console.WriteLine(" Operators or brackets are placed incorrectly");
                }
            }

            bool Check()// перевіряє правильність розташування дужок та симолів
            {
                try
                {
                    Task1 task = new Task1(s);
                    if (s[0] == '+' || s[0] == '-' || s[0] == '/' || s[0] == '*'
                        || s[length - 1] == '+' || s[length - 1] == '-'
                        || s[length - 1] == '/' || s[length - 1] == '*' || !task.Check())
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    return false;
                }

                return true;
            }

            void Postfix() // використовуємо стек для перетворення в постфіксну форму
            {
                Stack<string> stack = new Stack<string>();
                string tmp = "";
                foreach (char c in s)
                {
                    switch (c)
                    {
                        case '+':
                        case '-':
                        case '*':
                        case '/':
                            if (tmp != "")
                            {
                                postfix.Add(tmp);
                            }
                            tmp = "";
                            if (stack.Count > 0)
                            {
                                if (stack.Last() == "*" || stack.Last() == "/")
                                {
                                    postfix.Add(stack.Last());
                                    stack.Remove();
                                }
                            }
                            stack.Add(c.ToString());
                            break;
                        case '(':
                            stack.Add(c.ToString());
                            break;
                        case ')':
                            if (tmp != "")
                            {
                                postfix.Add(tmp);
                            }
                            tmp = "";
                            while (true)
                            {
                                string last = stack.Last();
                                if (last == "(")
                                {
                                    stack.Remove();
                                    break;
                                }
                                stack.Remove();
                                postfix.Add(last);
                            }
                            break;
                        case ' ':
                            break;
                        default:
                            tmp += c;
                            break;
                    }
                }

                if (tmp != "")
                {
                    postfix.Add(tmp);
                }

                while (stack.Count > 0)
                {
                    string last = stack.Last();
                    stack.Remove();
                    postfix.Add(last);
                }
            }

            void Calculate() // використовуємо стек для обчислення 
            {
                try
                {
                    Stack<int> stack = new Stack<int>();

                    for (int i = 0; i < postfix.Count; i++)
                    {
                        string c = postfix.At(i);
                        if (c == "+" || c == "-" || c == "*" || c == "/")
                        {
                            int b = stack.Last();
                            stack.Remove();
                            int a = stack.Last();
                            stack.Remove();
                            switch (c)
                            {
                                case "+":
                                    stack.Add(a + b);
                                    break;
                                case "-":
                                    stack.Add(a - b);
                                    break;
                                case "*":
                                    stack.Add(a * b);
                                    break;
                                case "/":
                                    stack.Add(a / b);
                                    break;
                            }
                        }
                        else
                        {
                            int num = Int32.Parse(c);
                            stack.Add(num);
                        }
                    }

                    Console.WriteLine("\n Calculated value: " + stack.Last());
                }
                catch
                {
                    Console.WriteLine("\n Cannot ne calculated: There is non-numeric value");
                }
            }
        }

        class Task4 // використовуємо чергу
        {
            int n = 1;
            Queue[] list;

            public void Write()
            {
                Console.WriteLine("__________________________ Task 4 __________________________\n");
                ListOfQueues();
                Timer();
            }

            void ListOfQueues()
            {
                while (true)
                {
                    Console.Write(" Enter number of queue (1 - 5): ");
                    try
                    {
                        n = Int32.Parse(Console.ReadLine());
                        if (n > 0 && n < 6)
                        {
                            break;
                        }
                    }
                    catch { }
                }

                list = new Queue[n];

                for (int i = 0; i < n; i++)
                {
                    list[i] = new Queue();
                }
            }

            public void Timer() // кожні 2 секунди оновлюється черга
            {
                Console.WriteLine("\n Press ENTER to add customer. Enter any another key to exit");
                Add();
                Tick();

                while (true)
                {
                    ConsoleKey key;
                    do
                    {
                        while (!Console.KeyAvailable)
                        {
                            Thread.Sleep(2000);
                            Tick();
                        }

                        key = Console.ReadKey(true).Key;

                    } while (key != ConsoleKey.Enter && key != ConsoleKey.Escape);

                    Add();
                    TickAdd();

                    if (key == ConsoleKey.Escape)
                    {
                        TickAdd();
                        break;
                    }
                }


                Console.WriteLine("Stopped");

            }

            void Add()
            {
                Random random = new Random();
                int cus = random.Next(1, 10);

                int[] sum = new int[n];
                for (int i = 0; i < n; i++)
                {
                    sum[i] = list[i].Sum();
                }

                int index = indexOfMin(sum);

                list[index].Add(cus);

                Console.WriteLine("\n\n Customer with {0} items was added to queue {1}", cus, index + 1);
            }

            void Tick()
            {
                for (int i = 0; i < n; i++)
                {
                    try
                    {
                        list[i].Refresh();
                    }
                    catch { }
                }
                TickAdd();
            }

            void TickAdd()
            {
                Console.WriteLine();
                for (int i = 0; i < n; i++)
                {
                    Console.Write("\n5 Queue {0} :", i + 1);
                    list[i].Print();
                }
            }

            int indexOfMin(int[] indexes)
            {
                int min = indexes[0];
                int index = 0;
                for (int i = 0; i < indexes.Length; i++)
                {
                    if (indexes[i] < min)
                    {
                        min = indexes[i];
                        index = i;
                    }
                }

                return index;
            }
        }

    }

}

