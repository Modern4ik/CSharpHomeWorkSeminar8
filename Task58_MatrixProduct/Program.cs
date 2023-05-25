// Программа по поиску произведения двух матриц.

Console.Clear();

int firstMatrixRows = GetValueFromUser("Введите кол-во строк для первой матрицы, большее единицы: ", "Ошибка ввода!Повторите попытку.");
int firstMatrixCols = GetValueFromUser("Введите кол-во столбцов для первой матрицы, большее единицы: ", "Ошибка ввода!Повторите попытку.");

int secondMatrixRows = GetValueFromUserWithExcept(firstMatrixCols, "Введите кол-во строк для второй матрицы, равное кол-ву столбцов первой матрицы: ", "Ошибка ввода!Повторите попытку.");
int secondMatrixCols = GetValueFromUser("Введите кол-во столбцов для второй матрицы, большее единицы: ", "Ошибка ввода!Повторите попытку.");

int[,] firstMatrix = GetMatrix(firstMatrixRows, firstMatrixCols, 1, 10);
PrintMatrix("Первая матрица:", firstMatrix);
Console.WriteLine();

int[,] secondMatrix = GetMatrix(secondMatrixRows, secondMatrixCols, 1, 10);
PrintMatrix("Вторая матрица:", secondMatrix);
Console.WriteLine();

int[,] result = GetMatrixProduct(firstMatrix, secondMatrix);

Console.WriteLine();
PrintReport(result);

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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

int GetValueFromUserWithExcept(int firstCols, string message, string errorMessage)
{
    while (true)
    {
        Console.Write(message);
        if (int.TryParse(Console.ReadLine(), out int userValue) && userValue > 1 && userValue == firstCols)
            return userValue;
        Console.WriteLine(errorMessage);
    }
}

int[,] GetMatrix(int rows, int cols, int minValue, int maxValue)
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

void PrintMatrix(string message, int[,] arr)
{
    Console.WriteLine(message);

    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            Console.Write($"{arr[i, j]}\t");
        }
        Console.WriteLine();
    }
}

int[,] GetMatrixProduct(int[,] matrix1, int[,] matrix2)
{
    int[,] result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];

    for (int i = 0; i < result.GetLength(0); i++)
    {
        int[] row = GetRowsByMatrix(i, matrix1);

        for (int j = 0; j < result.GetLength(1); j++)
        {
            int[] col = GetColsByMatrix(j, matrix2);
            int prodRes = GetRowAndColProduct(row, col);

            result[i, j] = prodRes;
        }
    }
    return result;
}

int[] GetRowsByMatrix(int row, int[,] matrix1)
{
    int[] res = new int[matrix1.GetLength(1)];

    for (int i = 0; i < res.Length; i++)
    {
        res[i] = matrix1[row, i];
    }
    return res;
}

int[] GetColsByMatrix(int col, int[,] matrix2)
{
    int[] res = new int[matrix2.GetLength(0)];

    for (int i = 0; i < res.Length; i++)
    {
        res[i] = matrix2[i, col];
    }
    return res;
}

int GetRowAndColProduct(int[] rowMatrix, int[] colMatrix)
{
    int res = 0;

    for (int i = 0; i < colMatrix.Length; i++)
    {
        res = res + rowMatrix[i] * colMatrix[i];
    }
    return res;
}

void PrintReport(int[,] res)
{
    Console.WriteLine("Результатом произведения двух данных матриц стала результирующая матрица: ");

    for (int i = 0; i < res.GetLength(0); i++)
    {
        for (int j = 0; j < res.GetLength(1); j++)
        {
            Console.Write($"{res[i, j]}\t");
        }
        Console.WriteLine();
    }
}