using System;

namespace spiral_matrix
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("matrix n to n, write n: ");
            int n = int.Parse(Console.ReadLine());

            int[,] A = new int[n, n];

            for (int k = 0; k < n; k++)
            {
                for (int l = 0; l < n; l++)
                {
                    A[k, l] = 0;
                }
            }


            int count = 1;

            int i = 0;
            int j = 0;

            //нач напр заполнения
            string direction = "right";

            // заполн матрицы
            while(!is_last(i, j, n))
            {


                A[i, j] = count;
                count++;

                direction = next_direction(A, direction, i, j, n);


                if(direction == "right")
                {
                    j++;
                }
                if (direction == "down")
                {
                    i++;
                }
                if (direction == "left")
                {
                    j--;
                }
                if (direction == "up")
                {
                    i--;
                }

            }

            if(n % 2 == 1)
            {
                A[n / 2, n / 2] = count;
            }
            else
            {
                A[n / 2, n / 2 - 1] = count;
            }


            for(int k = 0; k < n; k++)
            {
                for(int l = 0; l < n; l++)
                {
                    Console.Write(A[k, l] + "\t");
                }
                Console.WriteLine();
            }
            
        }

        static bool is_last(int i, int j, int n)
        {
            if (n % 2 == 1)
            {
                if(i == n/2 && j == n / 2)
                {
                    return true;
                }
            }

            else
            {
                if(i == n/2 && j == n/2 - 1)
                {
                    return true;
                }
            }

            return false;
        }


        static string next_direction(int[,] A, string dir, int i, int j, int n)
        {


            if (dir == "right")
            {

                if(j == n - 1)
                {
                    return "down";
                }
                else if (A[i, j + 1] != 0)
                {
                    return "down";
                }

            }


            if (dir == "down")
            {

                if (i == n - 1)
                {
                    return "left";
                }
                else if (A[i + 1, j] != 0)
                {
                    return "left";
                }

            }


            if (dir == "left")
            {

                if (j == 0)
                {
                    return "up";
                }
                else if (A[i, j - 1] != 0)
                {
                    return "up";
                }

            }


            if (dir == "up")
            {

                if (i == 0)
                {
                    return "right";
                }
                else if (A[i - 1, j] != 0)
                {
                    return "right";
                }

            }

            return dir;
        }

    }
}
