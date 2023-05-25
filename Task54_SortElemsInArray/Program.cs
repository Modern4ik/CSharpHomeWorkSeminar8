// Программа для упорядочивания элементов по убыванию в каждой строке двумерного массива.

Console.Clear();

int rowsValue = GetValueFromUser("Введите кол-во строк двумерного массива, большее единицы: ", "Ошибка ввода!Повторите попытку.");
int columnsValue = GetValueFromUser("Введите кол-во столбцов двумерного массива, большее единицы: ", "Ошибка ввода!Повторите попытку.");
Console.WriteLine();

int[,] array = GetArray(rowsValue, columnsValue, 0, 10);
PrintArray(array);
Console.WriteLine();

int[,] result = SortElemsInArray(array);

PrintReport(result);

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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

int[,] SortElemsInArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        int[] resRow = RowDecomposition(arr, i);
        resRow = SortRow(resRow);

        for (int j = 0; j < arr.GetLength(1); j++)
        {
            arr[i, j] = resRow[j];
        }
    }
    return arr;
}

int[] RowDecomposition(int[,] arr, int rowIndex)
{
    int[] res = new int[arr.GetLength(1)];

    for (int i = 0; i < res.Length; i++)
    {
        res[i] = arr[rowIndex, i];
    }
    return res;
}

int[] SortRow(int[] resultRow)
{
    for (int i = 0; i < resultRow.Length - 1; i++)
    {
        for (int j = i + 1; j < resultRow.Length; j++)
        {
            if (resultRow[i] < resultRow[j])
            {
                int temp = resultRow[i];
                resultRow[i] = resultRow[j];
                resultRow[j] = temp;
            }
        }
    }
    return resultRow;
}


void PrintReport(int[,] res)
{
    Console.WriteLine("После сортировки получен массив:");

    for (int i = 0; i < res.GetLength(0); i++)
    {
        for (int j = 0; j < res.GetLength(1); j++)
        {
            Console.Write($"{res[i, j]}\t");
        }
        Console.WriteLine();
    }
}