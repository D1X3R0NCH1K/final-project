using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItogProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userInfo = GatherUserInfo();
            DisplayUserInfo(userInfo);
        }

        static (string name, string surname, int age, bool hasPet, int petCount, string[] petNames, int favoriteColorsCount, string[] favoriteColors) GatherUserInfo()
        {
            Console.Write("Введите имя: ");
            string name = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            string surname = Console.ReadLine();

            int age = GetPositiveInt("Введите возраст: ");

            bool hasPet = GetYesOrNo("Есть ли у вас питомец? (да/нет): ");
            int petCount = 0;
            string[] petNames = null;

            if (hasPet)
            {
                petCount = GetPositiveInt("Введите количество питомцев: ");
                petNames = GetPetNames(petCount);
            }

            int favoriteColorsCount = GetPositiveInt("Введите количество любимых цветов: ");
            string[] favoriteColors = GetFavoriteColors(favoriteColorsCount);

            return (name, surname, age, hasPet, petCount, petNames, favoriteColorsCount, favoriteColors);
        }

        static int GetPositiveInt(string prompt)
        {
            int number;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out number) && number > 0)
                {
                    return number;
                }
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите число больше 0.");
            }
        }

        static bool GetYesOrNo(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string response = Console.ReadLine().ToLower();
                if (response == "да") return true;
                if (response == "нет") return false;
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите 'да' или 'нет'.");
            }
        }

        static string[] GetPetNames(int count)
        {
            string[] petNames = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Введите имя питомца {i + 1}: ");
                petNames[i] = Console.ReadLine();
            }
            return petNames;
        }

        static string[] GetFavoriteColors(int count)
        {
            string[] favoriteColors = new string[count];
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Введите любимый цвет {i + 1}: ");
                favoriteColors[i] = Console.ReadLine();
            }
            return favoriteColors;
        }

        static void DisplayUserInfo((string name, string surname, int age, bool hasPet, int petCount, string[] petNames, int favoriteColorsCount, string[] favoriteColors) userInfo)
        {
            Console.WriteLine("\n--- Информация о пользователе ---");
            Console.WriteLine($"Имя: {userInfo.name}");
            Console.WriteLine($"Фамилия: {userInfo.surname}");
            Console.WriteLine($"Возраст: {userInfo.age}");
            Console.WriteLine($"Есть питомец: {(userInfo.hasPet ? "Да" : "Нет")}");

            if (userInfo.hasPet)
            {
                Console.WriteLine($"Количество питомцев: {userInfo.petCount}");
                Console.WriteLine("Имена питомцев: " + string.Join(", ", userInfo.petNames));
            }

            Console.WriteLine($"Количество любимых цветов: {userInfo.favoriteColorsCount}");
            Console.WriteLine("Любимые цвета: " + string.Join(", ", userInfo.favoriteColors));
        }
    }
}
