namespace HW2bank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();

            bank.AddClient("Maria", "Zavod");
            bank.AddClient("Leroy", "Barnet");
            bank.AddClient("Lubomir", "Borkow");

            var mariaAccount1 = bank.GetAccount(5000.56m, 0.2m, bank.clients.ElementAt(0));
            var mariaAccount2 = bank.GetAccount(3345.54m, 0.2m, bank.clients.ElementAt(0));
            var ivanAccount1 = bank.GetAccount(765.89m, 0.1m, bank.clients.ElementAt(1));

            mariaAccount1.Deposit(new Money(100));

            ivanAccount1.Withdraw(new Money(500));

            Console.WriteLine("====================Get All Clients=======================");
            Console.WriteLine();

            foreach (var client in bank.GetAllClients())
            {
                Console.WriteLine($"Client: {client.FirstName} {client.LastName} \t\t{client.ToString()}");
            }
            Console.WriteLine();
            Console.WriteLine("=======================Transfer===========================");
            Console.WriteLine();

            Money amountToTransfer = new Money(500);

            mariaAccount1.Transfer(ivanAccount1, amountToTransfer);
            
            Console.WriteLine("Transfer succesfully complete");
            Console.WriteLine();
            foreach (var client in bank.GetAllClients())
            {
                Console.WriteLine($"Client: {client.FirstName} {client.LastName} \t\t{client.ToString()}");
            }

            Console.WriteLine();
            Console.WriteLine("====================History transactions==================");
            Console.WriteLine();

            bank.ShowTransactionHistory();
        }
    }
}
