using System;

namespace DZ4_1
{
    class Program
    {
        

        static void Main(string[] args)
        {
            ConsoleKeyInfo step;
            do
            {
                Console.WriteLine("Enter your action (1/2/3/4/5):");
                Console.WriteLine("1. Two Matrix's Sum ;");
                Console.WriteLine("2. Matrix Multiply a number ;");
                Console.WriteLine("3. Matrix Multiply Matrix ;");
                Console.WriteLine("4. Pow Matrix ;");
                Console.WriteLine("5. Transpon Matrix ;");

                string choise = Console.ReadLine();

                int N = 0, M = 0, K = 0, number = 0;
                int[,] matrixA, matrixB;
                Console.Clear();

                switch (choise)
                {
                    case "1" :
                        Console.WriteLine("Enter matrix NxM Size ;");
                        N = MatrixRangeEnter("N");
                        M = MatrixRangeEnter("M");
                        matrixA = MatrixEnter(N, M, "MatrixA");
                        matrixB = MatrixEnter(N, M, "MatrixB");
                        Console.WriteLine("Matrix A : ");
                        MatrixShow(matrixA);
                        Console.WriteLine("Matrix B : ");
                        MatrixShow(matrixB);
                        Console.WriteLine("Matrix C = Matrix A + Matrix B : ");
                        MatrixShow(MatrixSum(matrixA , matrixB));
                        break;
                    case "2" :
                        Console.WriteLine("Enter matrix NxM Size ;");
                        N = MatrixRangeEnter("N");
                        M = MatrixRangeEnter("M");
                        matrixA = MatrixEnter(N, M, "Matrix A");
                        number = NumberEnter("Number");
                        Console.WriteLine("Matrix A : ");
                        MatrixShow(matrixA);
                        Console.WriteLine("Number : " + number+"\n");
                        Console.WriteLine("Matrix C = Number * Matrix A : ");
                        MatrixShow(MatrixMult(matrixA, number));
                        break;
                    case "3":
                        Console.WriteLine("Enter matrix Matrix A NxM Size ; (Marix B size = MxK)");
                        N = MatrixRangeEnter("N");
                        M = MatrixRangeEnter("M");
                        matrixA = MatrixEnter(N, M, "MatrixA");
                        Console.WriteLine("Enter matrix MatrixA MxK Size (M = "+M+");");
                        K = MatrixRangeEnter("К");
                        matrixB = MatrixEnter(M, K, "MatrixB");
                        Console.WriteLine("Matrix A : ");
                        MatrixShow(matrixA);
                        Console.WriteLine("Matrix B : ");
                        MatrixShow(matrixB);
                        Console.WriteLine("Matrix C =  Matrix A * Matrix B : ");
                        MatrixShow(MatrixMult(matrixA, matrixB));
                        break;
                    case "4":
                        Console.WriteLine("Enter matrix NxN Size ;");
                        N = MatrixRangeEnter("N");
                        matrixA = MatrixEnter(N, N, "Matrix A");
                        number = PowNumberEnter("Number");
                        Console.WriteLine("Matrix A : ");
                        MatrixShow(matrixA);
                        Console.WriteLine("Matrix C =  Matrix A ^ Number : ");
                        MatrixShow(MatrixPow(matrixA, number));
                        break;
                    case "5":
                        Console.WriteLine("Enter matrix NxM Size ;");
                        N = MatrixRangeEnter("N");
                        M = MatrixRangeEnter("M");
                        matrixA = MatrixEnter(N, M, "Matrix A");
                        Console.WriteLine("Matrix A : ");
                        MatrixShow(matrixA);
                        Console.WriteLine("Matrix C =  Matrix A ^ T : ");
                        MatrixShow(MatrixTransp(matrixA));
                        break;

                    default:
                        Console.WriteLine("\nWrong choise enter");
                        break;
                }

                Console.WriteLine("Tap to continue / Esc - to exit;");
                step = Console.ReadKey();
                Console.Clear();
            } while (step.Key != ConsoleKey.Escape);
        }
        

        static int MatrixRangeEnter(string val)
        {
            bool checkR = false;
            int r = 0;
            do
            {
                Console.Write("Enter "+val+" : ");
                checkR = Int32.TryParse(Console.ReadLine(), out r);
                if (!checkR || r <= 0)
                {
                    checkR = false;
                    Console.WriteLine("Wrong "+val+" entered ; ");
                }
            } while (!checkR);
            return r;
        }
        static int NumberEnter(string val)
        {
            bool checkR = false;
            int r = 0;
            do
            {
                Console.Write("Enter " + val + " : ");
                checkR = Int32.TryParse(Console.ReadLine(), out r);
                if (!checkR )
                {
                    checkR = false;
                    Console.WriteLine("Wrong "+val+" entered ; ");
                }
            } while (!checkR);
            return r;
        }
        static int PowNumberEnter(string val)
        {
            bool checkR = false;
            int r = 0;
            do
            {
                Console.Write("Enter " + val + " : ");
                checkR = Int32.TryParse(Console.ReadLine(), out r);
                if (!checkR || r < 0)
                {
                    checkR = false;
                    Console.WriteLine("Wrong " + val + " entered ; ");
                }
            } while (!checkR);
            return r;
        }
        static int[,] MatrixEnter(int n, int m, string name)
        {
            Console.Clear();
            Console.WriteLine("Matrix " + name + " [" + n + "," + m + "] : \n");
            int[,] matrix = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    bool checkelem = false;
                    do
                    {
                        Console.Write("Enter " + name + " [" + i + "," + j + "] : ");
                        checkelem = Int32.TryParse(Console.ReadLine(), out matrix[i, j]);
                        if (!checkelem)
                        {
                            Console.WriteLine("Wrong N entered ; ");
                        }
                    } while (!checkelem);
                }
            }
            Console.Clear();
            return matrix;
        }
        static void MatrixShow(int[,] matrix)
        {
            string tab = "-";
            for (int i = 0; i < matrix.GetLength(1)*8; i++) 
            {
                tab += "-";
            }

            Console.WriteLine(tab); 
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("|" + matrix[i,j]+"\t");
                }
                Console.WriteLine("|\n"+tab);
            }
        }
        static int[,] MatrixSum(int[,] matrixA, int[,] matrixB) 
        {
            int[,] matrixC = new int[matrixA.GetLength(0), matrixA.GetLength(1)];
            for (int i = 0; i < matrixC.GetLength(0); i++)
            {
                for (int j = 0; j < matrixC.GetLength(1); j++)
                {
                    matrixC[i, j] = matrixA[i, j] + matrixB[i, j];
                }
            }
            return matrixC;
        }
        // Mult Matrix X Number
        static int[,] MatrixMult(int[,] matrixA, int number)
        {
            int[,] matrixC = new int[matrixA.GetLength(0), matrixA.GetLength(1)];
            for (int i = 0; i < matrixC.GetLength(0); i++)
            {
                for (int j = 0; j < matrixC.GetLength(1); j++)
                {
                    matrixC[i, j] = matrixA[i, j] * number;
                }
            }
            return matrixC;
        }
        // Mult Matrix X Matrix
        static int[,] MatrixMult(int[,] matrixA, int[,] matrixB)
        {
            int[,] matrixC = new int[matrixA.GetLength(0), matrixB.GetLength(1)];
            
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixB.GetLength(1); j++)
                {
                    for (int k = 0; k < matrixA.GetLength(1); k++)
                    {
                        matrixC[i,j] += matrixA[i,k]*matrixB[k,j]; 
                    }
                }
            }
            return matrixC;
        }
        static int[,] MatrixTransp(int[,] matrixA) 
        {
            int[,] matrixC = new int[matrixA.GetLength(1), matrixA.GetLength(0)];
            for (int i = 0; i < matrixA.GetLength(0); i++)
            {
                for (int j = 0; j < matrixA.GetLength(1); j++)
                {
                    matrixC[j, i] = matrixA[i, j] ;
                }
            }
            return matrixC;
        }
        // Matrix Pow N >= 0 
        static int[,] MatrixPow(int[,] matrixA, int number)
        {
            int[,] matrixC = new int[matrixA.GetLength(0), matrixA.GetLength(1)];
            int[,] matrixB = new int[matrixA.GetLength(0), matrixA.GetLength(1)];

            if (number == 0) // не доданий випадок < 0;
            {
                for (int i = 0; i < matrixC.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixC.GetLength(1); j++)
                    {
                        if (i == j)
                        {
                            matrixC[i, j] = 1;
                        }
                        else
                        {
                            matrixC[i, j] = 0;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < matrixC.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixC.GetLength(1); j++)
                    {
                        matrixC[i, j] = matrixA[i, j];
                    }
                }

                for (; number > 1; number--)
                {
                    for (int i = 0; i < matrixC.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrixC.GetLength(1); j++)
                        {
                            matrixB[i, j] = matrixC[i, j];
                            matrixC[i, j] = 0;
                        }
                    }

                    for (int i = 0; i < matrixC.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrixC.GetLength(1); j++)
                        {
                            for (int k = 0; k < matrixC.GetLength(0); k++)
                            {
                                matrixC[i, j] += matrixB[i, k] * matrixA[k, j];
                            }
                        }
                    }
                }
            }
            return matrixC;
        }
    }
}
