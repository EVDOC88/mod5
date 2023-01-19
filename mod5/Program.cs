using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
       var userinfo= UserInfo();
        PrintConsole(userinfo.Name, userinfo.LastName, userinfo.Age, ref userinfo.Petname, ref userinfo.favcolor);


        Console.ReadKey();
    }

    static void Echo(string saidworld, int deep)
    {
        var modif = saidworld;
        if (modif.Length > 2)
        {
            modif = modif.Remove(0, 2);
        }

        Console.BackgroundColor = (ConsoleColor)deep;
        Console.WriteLine("..." + modif);

        if (deep > 1) {
            Echo(modif, deep - 1);

        }
    }



    static (string Name, string LastName, int Age, string[] Petname, string[] favcolor) UserInfo()
    {
        (string Name, string LastName, int Age, string[] Petname, string[] favcolor) UserInfo;

        string corrname;
        do
        {
            Console.WriteLine("Введите свое имя");
            corrname = Console.ReadLine();

        }
        while (IsAllLetters(corrname) == false);
        UserInfo.Name = corrname;


        string corrlastname;
        do
        {
            Console.WriteLine("Введите свою фамилию");
            corrlastname = Console.ReadLine();

        }
        while (IsAllLetters(corrlastname) == false);
        UserInfo.LastName = corrlastname;

        string agecheck;
        int intagecheck;
        do
        {
            Console.WriteLine("Введите свой возраст цифрами");
            agecheck = Console.ReadLine();
        }
        while (CheckNum(agecheck, out intagecheck));

        UserInfo.Age = intagecheck;


        int kolpet = 0;
        string corrkolpet;
        string ispethave;
        var corrpetname = new string[kolpet];
        Console.WriteLine("У вас есть питомцы? Да или Нет");
        ispethave = Console.ReadLine();
        if (ispethave == "Да")
        {
            do
            {
                Console.WriteLine("Cколько у Вас их?");
                corrkolpet = Console.ReadLine();
            }
            while (CheckNum(corrkolpet, out kolpet));
            kolpet = int.Parse(corrkolpet);

            corrpetname = LovePet(kolpet);
        }
        UserInfo.Petname = corrpetname;

        UserInfo.favcolor = FavColor();

        return (UserInfo.Name, UserInfo.LastName, UserInfo.Age, UserInfo.Petname, UserInfo.favcolor);


    }

    static string[] LovePet(int kol)
    {
        string[] petnames = new string[kol];

        for (int i = 0; i < petnames.Length; i++)
        {
            string namepet;
            do
            {
                Console.WriteLine("Введите кличку питомца номер {0}", i + 1);
                namepet = Console.ReadLine();
            } while (IsAllLetters(namepet) == false);
            petnames[i] = namepet;

        }
        return petnames;
    }
    static bool CheckNum(string number, out int cornumber)
    { if (int.TryParse(number, out int intnum))
        { if (intnum > 0)
            {
                cornumber = intnum;
                return false;
            }
        }
        {
            cornumber = 0;
            Console.WriteLine("ОШИБКА: Количество не может содержать знаки, буквы и быть отрицательным!");
            return true;
        }

    }
    public static bool IsAllLetters(string s)
    {
        foreach (char c in s)
        {
            if (!Char.IsLetter(c))
            {
                Console.WriteLine("ОШИБКА: Имя не может содержать знаки, цифры!");
                return false;
            }
        }
        return true;
    }
    

    static string[] FavColor()
    {
        int kolpprint = 0;
        string corrkolpprint;

         do
            {
            Console.WriteLine("Сколько у вас любимых цветов");
            corrkolpprint = Console.ReadLine();
        } while (CheckNum(corrkolpprint, out kolpprint));

        kolpprint = int.Parse(corrkolpprint);
        var favcolor = new string[kolpprint];

        for (int i = 0; i < favcolor.Length; i++)
        { string corrfavcolor;
            do
            {
                Console.WriteLine("Введите любимый цвет номер {0}", i + 1);
                corrfavcolor = Console.ReadLine();

            } while (IsAllLetters(corrfavcolor)==false);
            favcolor[i] = corrfavcolor;
        }
        return favcolor;

    }

    static void PrintConsole(string Name, string LastName, int Age, ref string[] Petname, ref string[] favcolor)
    {
        
        Console.WriteLine(" Ваше имя : {0} \n Ваша фамилия : {1} \n Ваш возраст : {2}", Name, LastName, Age);
        Console.WriteLine(" У ваших животных клички: ");
        foreach (string p in Petname) Console.Write(p + " ");
        Console.WriteLine("\n Ваши любимые цвета: ");
        foreach (string c in favcolor) Console.Write(c + " ");

    }

}
