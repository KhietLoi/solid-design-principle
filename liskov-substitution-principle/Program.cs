namespace LSPDemo
{

    #region Example 1
    public class Apple
    {
        public virtual string GetColor()
        {
            return "Red";
        }
    }

    public class Orange : Apple
    {
        public override string GetColor()
        {
            return "Orange";
        }
    }
    

    #endregion
   
    #region Example 2 : BankAccount
    //Imagine you have a base class BankAccount
    public class BankAccount
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public BankAccount(string accountNumber, decimal balance)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public virtual void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposit: {amount}, Total Amount: {Balance}");
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }
    }

    //We have two derived classes: SavingsAccount and CurrentAccount
    public class SavingsAccount : BankAccount
    {
        public decimal InterestRate { get; set; }

        public SavingsAccount(string accountNumber, decimal balance, decimal interestRate)
            : base(accountNumber, balance)
        {
            InterestRate = interestRate;
        }

        public override void Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"AccountNumber: {AccountNumber}, Withdraw: {amount}, Balance: {Balance}");
            }
            else
            {
                Console.WriteLine($"AccountNumber: {AccountNumber}, Withdraw: {amount}, Insufficient Funds, Available Funds: {Balance}");
            }
        }
    }

    public class CurrentAccount : BankAccount
    {
        public decimal OverdraftLimit { get; set; }

        public CurrentAccount(string accountNumber, decimal balance, decimal overdraftLimit)
            : base(accountNumber, balance)
        {
            OverdraftLimit = overdraftLimit;
        }

        public override void Withdraw(decimal amount)
        {
            if (amount <= Balance + OverdraftLimit)
            {
                Balance -= amount;
                Console.WriteLine($"AccountNumber: {AccountNumber}, Withdraw: {amount}, Balance: {Balance}");
            }
            else
            {
                Console.WriteLine($"AccountNumber: {AccountNumber}, Exceeded Overdraft Limit.");
            }
        }
    }
    #endregion
    
    #region Example 3 : Rectangle

        #region LSP Violation - Square violates Rectangle's expected behavior.
        public class Rectangle
        {
            public virtual double Width { get; set; }
            public virtual double Height { get; set; }
            public double GetArea()
            {
                return Width * Height;
            }
            public void ChangeDimensions(Rectangle rect, double width, double height)
            {
                rect.Width = width;
                rect.Height = height;
                Console.WriteLine($"Area: {rect.GetArea()}");
            }
        }

        public class Square : Rectangle
        {
            public override double Width
            {
                get { return base.Width; }
                set { base.Width = base.Height = value; }
            }
            public override double Height
            {
                get { return base.Height; }
                set { base.Width = base.Height = value; }
            }
        }
        #endregion
        #region Violating the Liskov Substitution Principle (LSP)

        public abstract class Shape
        {
            public abstract double GetArea();
        }
        
        public class Rectangle_LSP : Shape
        {
            public double Width { get; set; }
            public double Height { get; set; }
            public override double GetArea()
            {
                return Width * Height;
            }
            public void ChangeDimensions(Rectangle rect, double width, double height)
            {
                rect.Width = width;
                rect.Height = height;
                Console.WriteLine($"Area: {rect.GetArea()}");
            }
        }
        public class Square_LSP : Shape
        {
            public double Side { get; set; }
            public override double GetArea()
            {
                return Side * Side;
            }
        }
        #endregion
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            //Example 2: Bank Account
            BankAccount savingsAccount = new SavingsAccount("SA123", 1000m, 0.03m);
            BankAccount currentAccount = new CurrentAccount("CA456", 1500m, 500m);
            Console.WriteLine("Before Transactions:");
            PrintAccountDetails(savingsAccount);
            PrintAccountDetails(currentAccount);
            savingsAccount.Withdraw(500m);
            currentAccount.Withdraw(2000m);
            Console.WriteLine("\nAfter Transactions:");
            PrintAccountDetails(savingsAccount);
            PrintAccountDetails(currentAccount);
            
            //Example 3: LSP Violation - Square violates Rectangle's expected behavior.
            Console.WriteLine("------------------------------------");
            var rect =  new Rectangle{Width = 2, Height = 3};
            rect.ChangeDimensions(rect, 4,5);

            var square = new Square { Width = 2 };
            rect.ChangeDimensions(square, 4, 5);
//square.GetArea();
            
            //Example 3: Violating the Liskov Substitution Principle (LSP)
            Console.WriteLine("------------------------------------");
            var rectLsp = new Rectangle_LSP { Width = 2, Height = 3 };
            rectLsp.GetArea();  // This works fine
            rectLsp.ChangeDimensions(rect, 4, 5);  // This works fine
            var squareLsp = new Square_LSP { Side = 2 };
            squareLsp.GetArea();  // This also works 
            Console.WriteLine($"Area: {squareLsp.GetArea()}");
            Console.ReadKey();
        }

        private static void PrintAccountDetails(BankAccount account)
        {
            Console.WriteLine($"Account Number: {account.AccountNumber}, Balance: {account.Balance}");
        }
       
    }
}