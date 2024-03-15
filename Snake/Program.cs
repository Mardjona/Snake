using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите номер столбца: ");
        int targetColumn = int.Parse(Console.ReadLine());

        int size = 5; // размер таблицы
        int targetRow = FindTargetRow(size);
        int[,] matrix = CreateMatrix(size);
        
        Console.WriteLine("Числа до столбца {0}, включая строку с числом 1:", targetColumn);
        for (int col = 0; col <= targetColumn; col++)
        {
            int pos = (col * col + 1) / 2; // число в ячейке без учета сдвига
            int shiftedPos = (pos - 1) / 9 * 10 + (pos - 1) % 9 + 1; // с учетом сдвига

            int targetNumber = shiftedPos + (targetRow * size); // находим число в указанном столбце и строке
            Console.Write(targetNumber + " ");
        }
        Console.WriteLine();
    }

    static int FindTargetRow(int size)
    {
        int targetRow = 0;
        int[,] matrix = CreateMatrix(size);

        for (int i = 0; i < size; i++)
        {
            if (matrix[i, 0] == 1)
            {
                targetRow = i;
                break;
            }
        }

        return targetRow;
    }

    static int[,] CreateMatrix(int size)
    {
        int[,] matrix = new int[size, size];
        int value = 1;
        int row = 0;
        int col = 0;
        bool moveDown = true;

        for (int i = 0; i < size * size; i++)
        {
            matrix[row, col] = value;

            if (moveDown)
            {
                if (row == size - 1)
                {
                    col++;
                    moveDown = false;
                }
                else
                {
                    row++;
                }
            }
            else
            {
                if (row == 0)
                {
                    col++;
                    moveDown = true;
                }
                else
                {
                    row--;
                }
            }

            value++;
        }

        return matrix;
    }
}