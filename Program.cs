namespace HW2bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=DESKTOP-V69R4LI;Database=BankDB;Integrated Security=True;Encrypt=false;";


            Bank bank = new Bank(connectionString);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1: Добавить клиента");
                Console.WriteLine("2: Показать всех клиентов");
                Console.WriteLine("3: Создать аккаунт");
                Console.WriteLine("4: Перевод между аккаунтами");
                Console.WriteLine("5: Показать историю транзакций");
                Console.WriteLine("6: Выход");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddClient(bank);
                        break;
                    case "2":
                        //ShowAllClients(bank);
                        break;
                    case "3":
                        CreateAccount(bank);
                        break;
                    case "4":
                        PerformTransfer(bank);
                        break;
                    case "5":
                        //ShowTransactionHistory(bank);
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
        }

        private static void AddClient(Bank bank)
        {
            Console.WriteLine("Введите имя клиента:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию клиента:");
            string lastName = Console.ReadLine();
            bank.AddClient(firstName, lastName);
            Console.WriteLine("Клиент добавлен.");
        }

        //private static void ShowAllClients(Bank bank)
        //{
        //    var clients = bank.GetAllClients();
        //    foreach (var client in clients)
        //    {
        //        Console.WriteLine($"Клиент: {client.FirstName} {client.LastName}, ID: {client.ClientId}");
        //    }
        //}

        private static void CreateAccount(Bank bank)
        {
            Console.WriteLine("Введите ID клиента для нового аккаунта:");
            int clientId = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите начальный баланс:");
            decimal balance = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Введите процентную ставку:");
            decimal interestRate = decimal.Parse(Console.ReadLine());
            var account = bank.GetAccount(balance, interestRate, clientId);
            Console.WriteLine($"Аккаунт создан. ID: {account.Id}");
        }

        private static void PerformTransfer(Bank bank)
        {
            Console.WriteLine("Введите ID исходного аккаунта:");
            Guid sourceAccountId = Guid.Parse(Console.ReadLine());
            Console.WriteLine("Введите ID целевого аккаунта:");
            Guid destinationAccountId = Guid.Parse(Console.ReadLine());
            Console.WriteLine("Введите сумму перевода:");
            decimal amount = decimal.Parse(Console.ReadLine());
            bank.DoTransfer(sourceAccountId, destinationAccountId, new Money(amount));
            Console.WriteLine("Перевод выполнен.");
        }

        //private static void ShowTransactionHistory(Bank bank)
        //{
        //    bank.ShowTransactionHistory();
        //}
    }
}
