// Программа для генерации трёхмерного массива , наполненного неповторяющимися , двузначными числами и вывод данного массива построчно , с индексами.

Console.Clear();

int firstDim = GetValueFromUser("Введите первое значение размерности массива: ", "Ошибка ввода!Повторите попытку.");
int secondDim = GetValueFromUser("Введите второе значение размерности массива: ", "Ошибка ввода!Повторите попытку.");
int thirdDim = GetValueFromUser("Введите третье значение размерности массива: ", "Ошибка ввода!Повторите попытку.");

int[,,] array = GetArray(firstDim, secondDim, thirdDim);

Console.WriteLine();
PrintArray(array);

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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

int[,,] GetArray(int dim1, int dim2, int dim3)
{
    int[,,] res = new int[dim1, dim2, dim3];

    for (int i = 0; i < res.GetLength(0); i++)
    {
        for (int j = 0; j < res.GetLength(1); j++)
        {
            for (int k = 0; k < res.GetLength(2); k++)
            {
                res[i, j, k] = FillArray(10, 99, res);
            }
        }
    }
    return res;
}

int FillArray(int minValue, int maxValue, int[,,] arr)
{
    int count = 0;

    while (true)
    {
        int numb = new Random().Next(minValue, maxValue + 1);

        bool res = CheckArrayByNumb(arr, numb);

        if (count > 1000)
            return 0;

        if (res)
        {
            count++;
            continue;
        }
        else
            return numb;
    }

}

bool CheckArrayByNumb(int[,,] arr, int rndNumb)
{
    bool res = false;

    foreach (int el in arr)
    {
        if (el == rndNumb)
            res = true;
    }
    return res;
}

void PrintArray(int[,,] arr)
{
    Console.WriteLine("В результате полученных данных сгенерирован трёхмерный массив: ");

    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            for (int k = 0; k < arr.GetLength(2); k++)
            {
                if (arr[i, j, k] == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Интервал уникальных и двухзначных чисел был исчерпан!Ваш массив больше не может заполняться числами, отличными от 0!");
                    return;
                }

                Console.Write($"{arr[i, j, k]}({i},{j},{k})|");
            }
            Console.WriteLine();
        }
    }
}