using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

class MainClass
{
    public static void Main(string[] args)
    {
        var tuple = (UserData());
        ShowResult(tuple.Name, tuple.Surname, tuple.Age, tuple.Pet, tuple.PetCount, tuple.PetNames, tuple.ColorCount, tuple.ColorNames);
    }

    //метод, который принимает значения и возвращает кортеж
    static (string Name, string Surname, int Age, string Pet, int PetCount, string[] PetNames, int ColorCount, string[] ColorNames) UserData()
    {
        (string Name, string Surname, int Age, string Pet, int PetCount, string[] PetNames, int ColorCount, string[] ColorNames) User;

        Console.WriteLine("Введите свое имя:");
        string Name = Console.ReadLine();
        User.Name = WordCheck(Name);


        Console.WriteLine("Введите свою фамилию:");
        string Surname = Console.ReadLine();
        User.Surname = WordCheck(Surname);

        Console.WriteLine("Введите свой возраст цифрами:");
        string Age = Console.ReadLine();
        User.Age = NumberCheck(Age);

        Console.WriteLine("Есть ли у вас питомец (напишите да или нет):");
        string Pet = Console.ReadLine();
        User.Pet = PetCheck(Pet);

        User.PetCount = 0;

        if (User.Pet == "да")
        {
            Console.WriteLine("Введите количество питомцев:");
            string PetCount = Console.ReadLine();
            User.PetCount = NumberCheck(PetCount);
            User.PetNames = PetsName(User.PetCount);
        }
        else
        {
            User.PetNames = new string[1] { "Нет питомцев" };
        }

        Console.WriteLine("Введите количество любимых цветов:");
        string ColorCount = Console.ReadLine();
        User.ColorCount = NumberCheck(ColorCount);
        User.ColorNames = LikeColor(User.ColorCount);

        return User;
    }

    //метод для записи кличек питомцев
    static string[] PetsName(int PetCount)
    {
        var PetName = new string[PetCount];

        for (int i = 0; i < PetCount; i++)
        {
            Console.WriteLine("Напишите кличку {0} питомца:", i + 1);
            string pet = Console.ReadLine();
            PetName[i] = WordCheck(pet);
        }
        return PetName;
    }

    //метод для записи любимых цветов
    static string[] LikeColor(int ColorCount)
    {
        var ColorName = new string[ColorCount];

        for (int i = 0; i < ColorCount; i++)
        {
            Console.WriteLine("Напишите {0} любимый цвет:", i + 1);
            string  color = Console.ReadLine();
            ColorName[i] = WordCheck(color);

        }
        return ColorName;
    }

    //метод для проверки вопроса есть ли питомец
    static string PetCheck(string Pet_1)
    {
        if (Pet_1 == "да" | Pet_1 == "нет" | Pet_1 == "Да" | Pet_1 == "Нет")
        {
            return Pet_1;
        }
        else
        {
            Console.WriteLine("Напишите да или нет");
            string Pet_2 = Console.ReadLine();
            Pet_1 = PetCheck(Pet_2);
        }
        return Pet_1;
    }

    //метод для вывода на экран
    static void ShowResult(string Name, string Surname, int Age, string Pet, int PetCount, string [] PetNames, int ColorCount, string[] ColorNames)
    {
        Console.WriteLine("Ваше имя:" + " " + Name);
        Console.WriteLine("Ваша фамилия:" + " " + Surname);
        Console.WriteLine("Ваш возраст:" + " " + Age);
        Console.WriteLine("Есть ли у вас питомец:" + " " + Pet);
        Console.WriteLine("Количество питомцев:" + " " + PetCount);
        Console.Write("Клички питомцев: ");
        for (int i = 0; i < PetNames.Length; i++)
        {
            if (i < PetNames.Length - 1)
            {
                Console.Write(PetNames[i] + ", ");
            }
            else
            {
                Console.Write(PetNames[i] );
            }

        }
        Console.WriteLine(" ");
        Console.WriteLine("Количество любимых цветов:" + " " + ColorCount);
        Console.Write("Любимые цвета: ");
        for (int i = 0; i < ColorNames.Length; i++)
        {
            if (i < ColorNames.Length - 1)
            {
                Console.Write(ColorNames[i] + ", ");
            }
            else
            {
                Console.Write(ColorNames[i]);
            }

        }

    }

    //метод для проверки на корректность ввода чисел
    static int NumberCheck(string number)
    {

        if (int.TryParse(number, out int number2))
        {
            do
            {
                if (number2 < 1)
                {
                    Console.WriteLine("Введите корректное число (больше 0):");
                    number2 = int.Parse(Console.ReadLine());
                }
            } while (number2 < 1);
        }
        else
        {
            Console.WriteLine("Было введено не число!");
            Console.WriteLine("Введите корректное число (больше 0):");
            string number3 = Console.ReadLine();
            number2 = NumberCheck(number3);
        }

        return number2;
    }

    //метод для проверки на корректность ввода букв в строках
    static string WordCheck(string worb)
    {

        string worb2;
        if (Regex.IsMatch(worb, @"[а-я]"))
        {
            worb2 = worb;
        }
        else
        {
            Console.WriteLine("Введите буквами (кириллицей)!");
            string worb3 = Console.ReadLine();
            worb2 = WordCheck(worb3);
        }

        return worb2;
    }

}
 

