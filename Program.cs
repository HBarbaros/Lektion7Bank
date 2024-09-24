namespace Bank;

class Program
{

    public static void Main(string[] args)
    {

        Account loggedInAccount = null;
        List<Account> listOfAccount = new List<Account>();

        listOfAccount.Add(new Account() { name = "Lucas", pin = "1" });
        listOfAccount.Add(new Account() { name = "Erik", pin = "2" });
        listOfAccount.Add(new Account() { name = "Rosa", pin = "3" });
        listOfAccount.Add(new Account() { name = "Linda", pin = "3" });
        listOfAccount.Add(new Account() { name = "Emil", pin = "5" });

        loggedInAccount = Login(listOfAccount);

        if (loggedInAccount != null)
        {
            Menu(loggedInAccount);
        }

    }

    public static Account Login(List<Account> listOfAccount)
    {

        Account loggedInAccount = null;

        do
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter PIN: ");
            string pinCode = Console.ReadLine();

            foreach (Account account in listOfAccount)
            {
                if (account.name.ToUpper() == name.ToUpper() && account.pin == pinCode)
                {
                    loggedInAccount = account;
                    break;
                }
            }

            if (loggedInAccount == null)
            {
                Console.WriteLine("Invalid PIN! Please try again!");
            }


        } while (loggedInAccount == null);

        Console.WriteLine("Login seccessful!");
        return loggedInAccount;
    }

    public static void Menu(Account account)
    {
        bool exit = false;
        do
        {

            Console.WriteLine("\n Bankomat Menu ");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit Money");
            Console.WriteLine("3. Withdraw Money");
            Console.WriteLine("4. Logout");

            Console.Write("\nSelect an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine($"Your current balance is: {account.CheckBalance()}");
                    break;
                case "2":
                    Console.Write("Enter the amount to deposit: ");
                    if (int.TryParse(Console.ReadLine(), out int depositAmount))
                    {
                        account.Deposit(depositAmount);
                        Console.WriteLine($"Deposit successful! New balance is: {account.CheckBalance()}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount. Please try again!");
                    }
                    break;
                case "3":
                    Console.Write("Enter the amount to witdraw: ");
                    if (int.TryParse(Console.ReadLine(), out int withdrawAmount))
                    {
                        bool success = account.WithDraw(withdrawAmount);
                        if (success)
                        {
                            Console.WriteLine($"Withdraw successful! New balance is: {account.CheckBalance()}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("invalid amount. Please try again!");
                    }
                    break;
                case "4":
                    Console.WriteLine("Logging out!");
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a valid option!");
                    break;
            }
        } while (!exit);


    }







}

