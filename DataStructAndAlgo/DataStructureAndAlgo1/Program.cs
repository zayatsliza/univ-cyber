using System;
using System.Text;

namespace DataStructureAndAlgo1
{
    class Program
    {
        static int max;
        static int min;

        static int n;
        static int a, b;

        static void Main(string[] args)
        {
            //____________________________TASK 1____________________________
            //Console.WriteLine("Enter array size (> 100):");
            //int c = int.Parse(Console.ReadLine());
            //if (c == null) return;
            //else n = c;

            //int[] array = new int[n];
            //array = GenerateArray(array);

            //calculateMinMaxValue(array);

            //Console.WriteLine();
            //Console.WriteLine("\nSorted by Ascending:\n");
            //int[] sortByAsc = ByAscending(array);
            //Write(sortByAsc);

            //Console.WriteLine();
            //Console.WriteLine("\nSorted by Descending:\n");
            //int[] sortByDesc = ByDescending(array);
            //Write(sortByDesc);

            //Console.WriteLine();
            //Console.WriteLine("\nA variant:\n");
            //int[] resultA = Task1A(array, true);
            //Write(resultA);

            //Console.WriteLine();
            //Console.WriteLine("\nB variant:\n");
            //int[] resultB = Task1B(array);
            //Write(resultB);

            //Console.WriteLine();
            //Console.WriteLine("\nC variant:\n");
            //int[] resultC = Task1C(array);
            //Write(resultC);
            //Console.WriteLine();
            //____________________________TASK 2____________________________

            //Console.WriteLine("Enter matix size (> 10):");
            //int c = int.Parse(Console.ReadLine());
            //if (c == null) return;
            //else n = c;
            //int[][] matrix = new int[n][];
            //GenerateMatrix(matrix);

            //MinMaxNumbersInMatrix(matrix);
            //Console.WriteLine();
            //WriteMatrix(matrix);

            //Console.WriteLine();
            //Console.WriteLine("\n1 Sort:\n");
            //int[][] Sort1 = SortRows(matrix);
            //WriteMatrix(Sort1);
            //Console.WriteLine();

            //Console.WriteLine();
            //Console.WriteLine("\n2 Sort:\n");
            //int[][] Sort2 = SortRowsDif(matrix);
            //WriteMatrix(Sort2);
            //Console.WriteLine();

            //Console.WriteLine();
            //Console.WriteLine("\n3 Sort:\n");
            //int[][] Sort3 = SortColumns(matrix);
            //WriteMatrix(Sort3);
            //Console.WriteLine();

            //Console.WriteLine();
            //Console.WriteLine("\n4 Sort:\n");
            //int[][] Sort4 = ToCenter(matrix);
            //Write(ToArray(matrix));
            //WriteMatrix(Sort4);
            //Console.WriteLine();

            //Console.WriteLine();
            //Console.WriteLine("\n5 Sort:\n");
            //int[][] Sort5 = FromCenter(matrix);
            //Write(ToArraySortDescending(ToArray(matrix)));
            //WriteMatrix(Sort5);
            //Console.WriteLine();

            //____________________________TASK 3____________________________

            //Console.WriteLine("Enter 3-dimensional array side size: ");
            //int c = int.Parse(Console.ReadLine());
            //if (c == null) return;
            //else n = c;

            //int[][][] array = new int[n][][];
            //Generate3DArray(array);
            //Write3DArray(array);
            //MinMaxValue3DArray(array);
            //Console.WriteLine();
            //OX(array);
            //Write3DArray(array);

            //OY(array);
            //Write3DArray(array);

            //OZ(array);
            //Write3DArray(array);

            //____________________________TASK 4____________________________

            Console.WriteLine("Enter first entity(array) size: ");
            int c = int.Parse(Console.ReadLine());
            if (c == null) return;
            else a = c;

            Console.WriteLine("Enter second entity(array) size: ");
            c = int.Parse(Console.ReadLine());
            if (c == null) return;
            else b = c;

            int[] firstArray = new int[a];
            int[] secondArray = new int[b];

            GenerateEntitiesInArrays(firstArray, secondArray);

            Console.WriteLine("First generated array: \n");
            Write(firstArray);
            Console.WriteLine();
            Console.WriteLine("Second generated array: \n");
            Write(secondArray);
            Console.WriteLine();

            Console.WriteLine("First distinct: \n");
            Write(Distinct(firstArray));
            Console.WriteLine();

            Console.WriteLine("Second distinct: \n");
            Write(Distinct(secondArray));
            Console.WriteLine();

            Console.WriteLine("Disjunction: \n");
            Write(Disjunction(firstArray, secondArray));
            Console.WriteLine();

            Console.WriteLine("Conjunction: \n");
            Write(Conjunction(firstArray, secondArray));
            Console.WriteLine();

            Console.WriteLine("Difference A/B : \n");
            Write(Difference(firstArray, secondArray));
            Console.WriteLine();

            Console.WriteLine("Symmetric difference: \n");
            Write(SymmetricDifference(firstArray, secondArray));
            Console.WriteLine();

            Console.WriteLine("Complement first array: \n");
            Write(Complement(firstArray));
            Console.WriteLine();
        }

        public static int[] GenerateArray(int[] array)
        {
            Random random = new Random();

            Console.WriteLine("\nArray:\n");

            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(-100, 100);
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            return array;
        }

        public static void calculateMinMaxValue(int[] array)
        {
            max = array[0];
            min = array[0];

            for (int i = 1; i < n; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }


                if (array[i] < min)
                {
                    min = array[i];
                }
            }
            Console.Write("Maximum element is : {0}\n", max);
            Console.Write("Minimum element is : {0}\n\n", min);
        }

        public static void Write(int[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        static int[] Swap(int i, int[] array)
        {
            int tmp = array[i];
            array[i] = array[i + 1];
            array[i + 1] = tmp;
            return array;
        }

        public static int[] ByAscending(int[] array)
        {
            for (int j = 0; j < array.Length - 1; j++)
                for (int i = 0; i < array.Length - 1; i++)
                    if (array[i] > array[i + 1])
                        array = Swap(i, array);

            return array;
        }

        public static int[] ByDescending(int[] array)
        {
            for (int j = 0; j < array.Length - 1; j++)
                for (int i = 0; i < array.Length - 1; i++)
                    if (array[i] < array[i + 1])
                        array = Swap(i, array);

            return array;
        }

        public static int[] Task1A(int[] array, bool ascending)
        {
            int n = array.Length;
            int[] res = new int[n];
            if (ascending == true)
                array = ByAscending(array);
            else
                array = ByDescending(array);
            int center = n / 2;
            res[center] = array[n - 1];

            int c = center;
            if (n % 2 == 0)
                c--;

            for (int i = 1; i <= c; i++)
            {
                res[center - i] = array[n - i * 2];
                res[center + i] = array[n - i * 2 - 1];
            }

            if (n % 2 == 0)
                res[0] = array[0];

            return res;
        }

        public static int[] Task1B(int[] array)
        {
            int n = array.Length;
            int[] res = new int[n];
            array = ByDescending(array);

            for (int i = 0; i < n / 2; i++)
            {
                res[2 * i] = array[i];
                res[2 * i + 1] = array[n - i - 1];
            }

            if (n % 2 != 0)
                res[n - 1] = array[n / 2];

            return res;
        }

        public static int[] Task1C(int[] array)
        {
            int n = array.Length;

            int[] res = new int[n];

            int[] pr = new int[n / 2];
            int[] np = new int[n / 2];

            for (int i = 0; i < n / 2; i++)
                pr[i] = array[2 * i];

            for (int i = 0; i < n / 2; i++)
                np[i] = array[2 * i + 1];

            pr = ByDescending(pr);
            np = ByAscending(np);

            for (int i = 0; i < n / 2; i++)
                res[2 * i] = pr[i];

            for (int i = 0; i < n / 2; i++)
                res[2 * i + 1] = np[i];

            return res;
        }
        //____________________________TASK 2____________________________

        public static int[][] GenerateMatrix(int[][] matrix)
        {
            //int[][] matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    Random random = new Random();
                    matrix[i][j] = random.Next(0, 100);
                }
            }
            return matrix;
        }

        public static void WriteMatrix(int[][] matrix, string delimiter = "\t")
        {
            var s = new StringBuilder();

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(0); j++)
                {
                    s.Append(matrix[i][j]).Append(delimiter);
                }

                s.AppendLine();
            }

            Console.Write(s.ToString());
        }

        public static void MinMaxNumbersInMatrix(int[][] matrix)
        {
            int min = matrix[0][0];
            int max = min;

            foreach (int[] array in matrix)
                foreach (int number in array)
                {
                    if (number < min)
                        min = number;
                    if (number > max)
                        max = number;
                }

            Console.Write("Min: " + min + " " + "Max: " + max);
            Console.WriteLine();
        }

        public static int[][] SortRows(int[][] matrix)
        {
            int n = matrix.Length;

            for (int row = 0; row < n; row++)
                for (int j = 0; j < n; j++)
                    for (int i = 0; i < n - 1; i++)
                        if (matrix[row][i] > matrix[row][i + 1])
                            matrix[row] = Swap(i, matrix[row]);

            return matrix;
        }

        public static int[][] SortRowsDif(int[][] matrix)
        {
            int n = matrix.Length;

            for (int row = 0; row < n; row++)
                for (int j = 0; j < n; j++)
                    for (int i = 0; i < n - 1; i++)
                    {
                        if (row % 2 == 0)
                        {
                            if (matrix[row][i] > matrix[row][i + 1])
                                matrix[row] = Swap(i, matrix[row]);
                        }
                        else
                        {
                            if (matrix[row][i] < matrix[row][i + 1])
                                matrix[row] = Swap(i, matrix[row]);
                        }
                    }

            return matrix;
        }

        static int[][] SwapMatrix(int i, int j, int[][] matrix)
        {
            int tmp = matrix[i][j];
            matrix[i][j] = matrix[i + 1][j];
            matrix[i + 1][j] = tmp;
            return matrix;
        }


        public static int[][] SortColumns(int[][] matrix)
        {
            int n = matrix.Length;

            for (int col = 0; col < n; col++)
                for (int j = 0; j < n; j++)
                    for (int i = 0; i < n - 1; i++)
                        if (matrix[i][col] > matrix[i + 1][col])
                            matrix = SwapMatrix(i, col, matrix);

            return matrix;
        }

        public static int[] ToArray(int[][] matrix)
        {
            int n = matrix.Length;
            int[] result = new int[n * n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    result[i * n + j] = matrix[i][j];
            return result;
        }


        public static int[] ToArraySortAscending(int[] array)
        {
            int n = array.Length;
            for (int j = 0; j < n; j++)
                for (int i = 0; i < n - 1; i++)
                    if (array[i] > array[i + 1])
                        array = Swap(i, array);
            return array;
        }

        public static int[][] ToCenter(int[][] matrix)
        {
            int N = matrix.Length;
            int[] array = ToArray(matrix);
            array = ToArraySortAscending(array);
            int j = 0;
            int[][] result = new int[N][];
            for (int i = 0; i < N; i++)
                result[i] = new int[N];
            for (int n = 0; n < N;)
            {
                for (int i = n; i < N; i++)
                    result[n][i] = array[j++];
                for (int i = n + 1; i < N; i++)
                    result[i][N - 1] = array[j++];
                for (int i = N - 2; i >= n; i--)
                    result[N - 1][i] = array[j++];
                for (int i = N - 2; i > n; i--)
                    result[i][n] = array[j++];
                n++;
                N--;
            }
            return result;
        }

        public static int[] ToArraySortDescending(int[] array)
        {
            int n = array.Length;
            for (int j = 0; j < n; j++)
                for (int i = 0; i < n - 1; i++)
                    if (array[i] < array[i + 1])
                        array = Swap(i, array);

            return array;
        }

        public static int[][] FromCenter(int[][] matrix)
        {
            int N = matrix.Length;
            int[] array = ToArray(matrix);
            array = ToArraySortDescending(array);
            int j = 0;
            int[][] result = new int[N][];

            for (int i = 0; i < N; i++)
                result[i] = new int[N];

            for (int n = 0; n < N;)
            {

                for (int i = N - 1; i >= n; i--)
                    result[n][i] = array[j++];

                for (int i = n + 1; i < N; i++)
                    result[i][n] = array[j++];

                for (int i = n + 1; i < N; i++)
                    result[N - 1][i] = array[j++];

                for (int i = N - 2; i > n; i--)
                    result[i][N - 1] = array[j++];

                n++;
                N--;
            }

            return result;
        }

        //____________________________TASK 3____________________________

        public static int[][][] Generate3DArray(int[][][] array)
        {
            //int[][][] array = new int[n][][];

            for (int z = 0; z < n; z++)
            {
                array[z] = new int[n][];

                for (int y = 0; y < n; y++)
                {
                    array[z][y] = new int[n];

                    for (int x = 0; x < n; x++)
                    {
                        Random random = new Random();
                        array[z][y][x] = random.Next(0, 100);
                    }
                }
            }
            return array;
        }

        public static void Write3DArray(int[][][] array, string delimiter = "\t")
        {
            var s = new StringBuilder();
            s.Append("< ");
            for(var z = 0; z < array.GetLength(0); z++)
            {
                for (var i = 0; i < array.GetLength(0); i++)
                {
                    s.Append(delimiter).Append("{ ");
                    for (var j = 0; j < array.GetLength(0); j++)
                    {
                        s.Append(array[z][i][j]).Append(delimiter);
                    }
                    s.Append("}");
                    s.AppendLine();
                }
                s.AppendLine();
            }
            s.Append(">");
            Console.Write(s.ToString());
            Console.WriteLine();
        }

        public static void MinMaxValue3DArray(int[][][] array)
        {
            int min = array[0][0][0];
            int max = min;

            foreach (int[][] z in array)
                foreach (int[] y in z)
                    foreach (int x in y)
                    {
                        if (x < min)
                            min = x;

                        if (x > max)
                            max = x;
                    }
            Console.Write("Min: {0}     Max: {1}", min, max);
        }

        public static int[][][] OX(int[][][] array)
        {
            int n = array.Length;

            for (int i = 0; i < n; i++)
                for (int z = 0; z < n; z++)
                    for (int y = 0; y < n; y++)
                        for (int x = 0; x < n - 1; x++)
                            if (array[z][y][x] > array[z][y][x + 1])
                                array[z][y] = Swap(x, array[z][y]);

            return array;
        }

        public static int[][][] OY(int[][][] array)
        {
            int n = array.Length;

            for (int i = 0; i < n; i++)
                for (int z = 0; z < n; z++)
                    for (int y = 0; y < n - 1; y++)
                        for (int x = 0; x < n; x++)
                            if (array[z][y][x] > array[z][y + 1][x])
                                array[z] = Swap2D(x, y, array[z]);
            return array;
        }


        public static int[][][] OZ(int[][][] array)
        {
            int n = array.Length;

            for (int i = 0; i < n; i++)
                for (int z = 0; z < n - 1; z++)
                    for (int y = 0; y < n; y++)
                        for (int x = 0; x < n; x++)
                            if (array[z][y][x] > array[z + 1][y][x])
                                array = Swap3D(x, y, z, array);
            return array;
        }


        static int[][][] Swap3D(int row, int col, int dim, int[][][] array)
        {
            int tmp = array[dim][col][row];
            array[dim][col][row] = array[dim + 1][col][row];
            array[dim + 1][col][row] = tmp;

            return array;
        }

        static int[][] Swap2D(int row, int col, int[][] array)
        {
            int tmp = array[col][row];
            array[col][row] = array[col + 1][row];
            array[col + 1][row] = tmp;

            return array;
        }

        //____________________________TASK 4____________________________

        public static void GenerateEntitiesInArrays(int[] first, int[] second)
        {

            for (int i = 0; i < first.Length; i++)
            {
                Random random = new Random();
                first[i] = random.Next(0, 10);
            }

            for (int i = 0; i < second.Length; i++)
            {
                Random random = new Random();
                second[i] = random.Next(0, 10);
            }
        }

        public static int[] Distinct(int[] array)
        {
            int[] quantity = new int[11];

            for (int i = 0; i < array.Length; i++)
                quantity[array[i]]++;

            int n = 0;
            for (int i = 0; i < 11; i++)
                if (quantity[i] > 0)
                    n++;

            int[] res = new int[n];
            int r = 0;
            for (int i = 0; i < 11; i++)
                if (quantity[i] > 0)
                    res[r++] = i;

            return res;
        }

        public static int[] Disjunction(int[] first, int[] second)
        {
            int nFirst = first.Length;
            int nSecond = second.Length;
            int[] res = new int[nFirst + nSecond];

            for (int i = 0; i < nFirst; i++)
                res[i] = first[i];

            for (int i = 0; i < nSecond; i++)
                res[nFirst + i] = second[i];

            res = Distinct(res);
            return res;
        }

        public static int[] Conjunction(int[] first, int[] second)
        {
            int[] dFirst = Distinct(first);
            int[] dSecond = Distinct(second);

            int n = 0;
            int[] res = new int[11];

            for (int i = 0; i < dFirst.Length; i++)
                for (int j = 0; j < dSecond.Length; j++)
                    if (dFirst[i] == dSecond[j])
                    {
                        res[n++] = dFirst[i];
                        break;
                    }

            int[] result = new int[n];

            for (int i = 0; i < n; i++)
                result[i] = res[i];

            return result;
        }

        public static int[] Difference(int[] first, int[] second)
        {
            first = Distinct(first);
            second = Distinct(second);
            int n = first.Length;

            for (int i = 0; i < first.Length; i++)
                for (int j = 0; j < second.Length; j++)
                    if (first[i] == second[j])
                    {
                        first[i] = -1;
                        n--;
                        break;
                    }

            int[] res = new int[n];
            int aa = 0;
            for (int i = 0; i < first.Length; i++)
                if (first[i] >= 0)
                    res[aa++] = first[i];
            return res;

        }

        public static int[] SymmetricDifference(int[] first, int[] second)
        {
            int[] disjunction = Disjunction(first, second);
            int[] conjunction = Conjunction(first, second);
            return Difference(disjunction, conjunction);
        }

        public static int[] Complement(int[] array)
        {
            return Difference(Universum(), array);
        }

        static int[] Universum()
        {
            int[] res = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            return res;
        }
    }
}
