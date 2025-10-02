using System.Diagnostics.Metrics;

namespace Project_5_6_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (string Name, string SecondName, int Age, string[] NamePet, string[] FavColor)
                 User = Questionnaire();

            OutputToTheScreen(User);


        }

        static void OutputToTheScreen((string Name, string SecondName, int Age, string[] NamePet, string[] FavColor) user)
        {
            Console.WriteLine("Ваша АНКЕТА:");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Имя: " + user.Name);
            Console.WriteLine("Фамилия: " + user.SecondName);
            Console.WriteLine("Возраст: " + user.Age);
            Console.Write("Питомцы: ");
            for (int i = 0; i < user.NamePet.Length; i++)
            {
                Console.WriteLine(user.NamePet[i] + ", ");
            }
            Console.Write("Любимые цвета: ");
            for (int i = 0; i < user.FavColor.Length; i++)
            {
                Console.Write(user.FavColor[i] + ", ");
            }
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"Спасибо, что уделили время, {user.Name} {user.SecondName}!");
        }
        static (string Name, string SecondName, int Age, string[] NamePet, string[] FavColor) Questionnaire()
        {
            (string Name, string SecondName, int Age, string[] NamePet, string[] FavColor)
                User = ("", "", 0, Array.Empty<string>(), Array.Empty<string>());

            Console.Write("Введите ваше имя: ");
            User.Name = Console.ReadLine();
            Console.Write("Введите вашу фамилию: ");
            User.SecondName = Console.ReadLine();
            Console.Write("Введите ваш возраст: ");
            string ChekedAge = Console.ReadLine();
            int CorrAge;
            // проверка на допустимый возраст
            while (CheckNum(ChekedAge, out CorrAge)) // если true, то заново просим ввести возраст
            {
                Console.WriteLine("Введен не корректный возраст");
                ChekedAge = Console.ReadLine();

            }
            User.Age = CorrAge;
            Console.WriteLine("Есть ли у вас домашний питомец? да/нет");
            while (true)
            {
                string answerPet = Console.ReadLine();
                switch (answerPet)
                {
                    case "да" or "Да":
                        Console.WriteLine("Сколько у вас домашних питомце?");
                        string countPet = Console.ReadLine();
                        int corrCountPet;
                        while (CheckNum(countPet, out corrCountPet))
                        {
                            Console.WriteLine("Введено не корректное число питомцев");
                            countPet = Console.ReadLine();
                        }

                        User.NamePet = ArrPet(corrCountPet);

                        foreach (string name in User.NamePet)
                        {
                            Console.WriteLine(name);
                        }
                        break;

                    case "нет" or "Нет":
                        break;
                    
                    default:
                        Console.WriteLine("Введено не корректное значение");
                        continue;
                }
                break;
            }

            Console.WriteLine("Сколько у вас любимых цветов?");
            string countFavColor = Console.ReadLine();
            int corrFavColor;
            while (CheckNum(countFavColor, out corrFavColor))
            {
                Console.WriteLine("Введено не корректное число");
                countFavColor = Console.ReadLine();
            }
            User.FavColor = ArrFavColor(corrFavColor);
            Console.WriteLine("Вот ваши любимые цвета: ");
            foreach (string favColor in User.FavColor)
            {
                Console.Write(favColor + " ");
            }

            return User;
        }
        static string[] ArrFavColor(int countFavColor)
        {
            string[] arrFavColor = new string[countFavColor];
            Console.WriteLine($"Введите ваши любимые {countFavColor} цвет(а)(ов): ");
            for (int i = 0; i < countFavColor; i++)
            {
                arrFavColor[i] = Console.ReadLine();
            }
            return arrFavColor;
        }
        static string[] ArrPet(int count)
        {
            string[] arrNamePet = new string[count];
            Console.WriteLine("Введите имена ваших питомцев: ");
            for (int i = 0; i < arrNamePet.Length; i++)
            {
                arrNamePet[i] = Console.ReadLine();
            }
            Console.WriteLine($"У вас целых {count} питомца/цев");

            return arrNamePet;
        }
        static bool CheckNum(string number, out int correctNum)
        {
            if (int.TryParse(number, out int result))
            {
                if (result > 0)
                {
                    correctNum = result;
                    return false;
                }
                else
                {
                    correctNum = result;
                    return true;
                }
            }
            else
            {
                correctNum = 0;
                return true;
            }
        }
    }
}
