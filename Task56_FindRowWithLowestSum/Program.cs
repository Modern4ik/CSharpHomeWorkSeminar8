// Программа по поиску строки с наименьшей суммой элементов в двумерном, прямоугольном массиве.

Console.Clear();

int rowsValue = GetValueFromUser("Введите кол-во строк двумерного массива, большее единицы: ", "Ошибка ввода!Повторите попытку.");
int columnsValue = GetValueFromUser("Введите кол-во столбцов двумерного массива, большее единицы: ", "Ошибка ввода!Повторите попытку.");
Console.WriteLine();

int[,] array = GetArray(rowsValue, columnsValue, 5, 35);
PrintArray(array);
Console.WriteLine();

int[] rowSums = FindRowSumsByArray(array);
Console.WriteLine(String.Join("|", rowSums));

int result = FindLowestRowSum(rowSums);

Console.WriteLine();
PrintReport(result);

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

int GetValueFromUser(string message, string errorMessage)
{
    while (true)
    {
        Console.Write(message);
        if (int.TryParse(Console.ReadLine(), out int userValue) && userValue > 1)
            return userValue;
        Console.WriteLine(errorMessage);
    }
}

int[,] GetArray(int rows, int cols, int minValue, int maxValue)
{
    int[,] result = new int[rows, cols];

    for (int i = 0; i < result.GetLength(0); i++)
    {
        for (int j = 0; j < result.GetLength(1); j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}

void PrintArray(int[,] arr)
{
    Console.WriteLine("Сгенерирован массив:");

    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write($"{arr[i, j]}\t");
        }
        Console.WriteLine();
    }
}

int[] FindRowSumsByArray(int[,] arr)
{
    int[] res = new int[arr.GetLength(0)];

    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            res[i] = res[i] + arr[i, j];
        }
    }
    return res;
}

int FindLowestRowSum(int[] arr)
{
    int minSum = arr[0];
    int resIndex = 0;

    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] < minSum)
        {
            minSum = arr[i];
            resIndex = i;
        }
    }
    return resIndex;
}

void PrintReport(int res)
{
    Console.WriteLine($"{res + 1} строка является строкой с минимальной суммой элементов данного двумерного массива.");
}