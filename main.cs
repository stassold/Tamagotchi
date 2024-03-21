using System;

class Tamagotchi
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Hunger { get; set; }
    public int Fatigue { get; set; }
    public int Happiness { get; set; }

    public Tamagotchi(string name)
    {
        Name = name;
        Health = 10;
        Hunger = 0;
        Fatigue = 0;
        Happiness = 5;
    }

    public void Feed()
    {
        if (Hunger > 0)
        {
            Hunger--;
        }
        else
        {
            Health--;
        }

        if (Happiness < 10)
        {
            Happiness++;
        }
    }

    public void Play()
    {
        if (Fatigue < 10)
        {
            Fatigue++;
        }
        else
        {
            Health--;
            Hunger++;
        }

        if (Happiness < 10)
        {
            Happiness++;
        }
    }

    public void Sleep()
    {
        Fatigue = 0;
        Health++;
        Hunger++;

        if (Happiness < 10)
        {
            Happiness++;
        }
    }

    public void Heal()
    {
        if (Health < 10)
        {
            Health++;
        }
        else
        {
            Console.WriteLine("Питомец уже полностью здоров.");
        }

        if (Happiness < 10)
        {
            Happiness++;
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите имя питомца:");
        string name = Console.ReadLine();

        Tamagotchi pet = new Tamagotchi(name);

        bool gameOver = false;

        while (!gameOver)
        {
            Console.Clear();
            Console.WriteLine($"#################### {pet.Name} #############################");
            Console.WriteLine($"Здоровье: {pet.Health}");
            Console.WriteLine($"Голод: {pet.Hunger}");
            Console.WriteLine($"Усталость: {pet.Fatigue}");
            Console.WriteLine($"Уровень счастья: {pet.Happiness}");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Покормить");
            Console.WriteLine("2. Поиграть");
            Console.WriteLine("3. Укачать (сон)");
            Console.WriteLine("4. Лечить");

            int choice;
            bool validInput = false;

            do
            {
                // Проверяем, что введенное значение является корректным целым числом
                Console.Write("Выберите номер действия: ");
                validInput = int.TryParse(Console.ReadLine(), out choice);

                if (validInput)
                {
                    switch (choice)
                    {
                        case 1:
                            pet.Feed();
                            break;
                        case 2:
                            pet.Play();
                            break;
                        case 3:
                            pet.Sleep();
                            break;
                        case 4:
                            pet.Heal();
                            break;
                        default:
                            Console.WriteLine("Некорректный выбор действия");
                            validInput = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный выбор действия. Введите число от 1 до 4.");
                }
            } while (!validInput);

            if (pet.Health <= 0)
            {
                Console.WriteLine("Питомец заболел, игра окончена");
                gameOver = true;
            }

            Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey();
        }
    }
}
