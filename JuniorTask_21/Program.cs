// 21. Программа проверяет, является ли ЛЮБОЕ число палиндромом.

int[] CreateArrayFromConsole() // Метод для преобразования введенного числа в массив
{
    try
    {
        Console.WriteLine("Введите число: ");
        string? StringNumber = Console.ReadLine();
        if (StringNumber == null) StringNumber = String.Empty; //Если значение NULL, то присвоить пустую строку 
        int Number = int.Parse(StringNumber);
        if (Number < 0)
        {
            Console.WriteLine("Ваше число отрицательное!");
            Environment.Exit(1);
        }
        int NumberLength = StringNumber.Length;
        int NumberFactor = 1;
        for (int i = 1; i < NumberLength; i++)
        {
            NumberFactor *= 10;             // Получаю 10 в степени X, где X - количество знаков в числе
        }

        while (Number < NumberFactor)       // Проверяю, начинается ли число с 0
        {
            NumberFactor /= 10;             // Уменьшаю множитель в 10 раз
            NumberLength--;                 // Уменьшаю размер будущего массива на 1
        }

        // Инициализируем массив и наполняем массив цифрами из введенного числа
        int[] Array = new int[NumberLength];
        for (int i = 0, j = NumberFactor; i < NumberLength; i++, j /= 10)
        {
            if (j == 0) break;
            Array[i] = Number / j;
            Number = Number % j;
        }
        return Array;
    }
    catch
    {
        Console.WriteLine("Input error.");
        Environment.Exit(1);
        int[] Array = { 0 };
        return Array;
    }

}

//Проверяем массив на палиндром
int[] Array = CreateArrayFromConsole();

if (Array.Length == 0)                          // Если длина массива равна 0 (значение 0)
{
    Console.WriteLine("Ваше число 0!");
    Environment.Exit(1);
}

if (Array.Length == 1)                          // Если длина массива равна 1 (введена 1 цифра)
{
    Console.WriteLine("Ваше число состоит из одной цифры. В принципе, можно его считать палиндромом ;)");
    Environment.Exit(1);
}

int j = Array.Length - 1;                       //Индекс последнего элемента в массиве
for (int i = 0; i < Array.Length / 2; i++, j--) //Проверяем первую половину массива на совпадение 
                                                //со второй половиной (с конца)
{
    if (Array[i] != Array[j]) //При первом несовпадении зеркальных элементов выдает сообщение и завершает цикл
    {
        Console.WriteLine("Ваше число - НЕ палиндром.");
        break;
    }
    else
    {
        if (i >= j - 2)     //Выводит сообщение об успешной проверке только после того, 
                            //как разница между проверяемыми элементами будет меньше 2 
                            //(то есть соседние числа или через одно)
        {
            Console.WriteLine("Ваше число является палиндромом!");
        }
    }
}
