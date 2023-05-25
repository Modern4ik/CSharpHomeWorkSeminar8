// Программа , которая заполняет спирально массив 4 x 4 числами в диапозоне от 1 до 16.

Console.Clear();

int[,] array = new int[4, 4];

FillArray(array);

PrintResult(array);

/////////////////////////////////////////////////////////

void FillArray(int[,] arr)
{
    int currentIndexI = 0, currentIdexJ = 0;
    int rows = arr.GetLength(0), columns = arr.GetLength(1);
    int numb = 1;

    for (int count = 0; count < 6; count++)
    {
        if (numb == 5)
        {
            currentIndexI = 1;
            currentIdexJ = 3;
        }
        else if (numb == 8)
        {
            currentIndexI = 3;
            currentIdexJ = 2;
            columns = 0;
            rows = 0;
        }
        else if (numb == 11)
        {
            currentIndexI = 2;
            currentIdexJ = 0;
            rows = 1;
        }
        else if (numb == 13)
        {
            currentIndexI = 1;
            currentIdexJ = 1;
            columns = 3;
            rows = 2;
        }
        else if (numb == 15)
        {
            currentIndexI = 2;
            currentIdexJ = 2;
            columns = 1;
        }

        for (int i = currentIndexI, j = currentIdexJ; i < rows && j < columns || i >= rows && j >= columns;)
        {
            arr[i, j] = numb;
            numb++;
            if (numb <= 5 || numb >= 14 && numb <= 15)
                j++;
            else if (numb >= 6 && numb <= 8)
                i++;
            else if (numb >= 9 && numb <= 11 || numb >= 16 && numb <= 17)
                j--;
            else if (numb >= 12 && numb <= 13)
                i--;
        }
    }
}

void PrintResult(int[,] res)
{
    Console.WriteLine("В результате заполнения по спирали получился двумерный массив:");

    for (int i = 0; i < res.GetLength(0); i++)
    {
        for (int j = 0; j < res.GetLength(1); j++)
        {
            Console.Write($"{res[i, j]}\t");
        }
        Console.WriteLine();
    }
}