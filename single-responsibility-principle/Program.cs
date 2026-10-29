using System;
using System.Collections.Generic;

namespace SRPDemo
{
    #region BankAccount Implement
    public class BankAccount
    {
        public int AccountNumber { get; private set; }
        public double Balance { get; private set; }
        public List<string> Transactions = new List<string>();

        public BankAccount(int accountNumber)
        {
            AccountNumber = accountNumber;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            Transactions.Add($"Deposited ${amount}. New Balance: ${Balance}");
        }

        public void Withdraw(double amount)
        {
            Balance -= amount;
            Transactions.Add($"Withdrew ${amount}. New Balance: ${Balance}");
        }
    }

    public class StatementPrinter
    {
        public void Print(BankAccount account)
        {
            Console.WriteLine($"Statement for Account: {account.AccountNumber}");
            foreach (var transaction in account.Transactions)
            {
                Console.WriteLine(transaction);
            }
        }
    }
    #endregion
    #region Student Implement
    public class Student
    {
        public string Name { get; set; }
        public Dictionary<string, double> CoursesAndGrades = new Dictionary<string, double>();

        public Student(string name)
        {
            Name = name;
        }

        public void EnrollCourse(string courseName)
        {
            CoursesAndGrades[courseName] = 0; // default grade
        }
        public void AssignGrade(string courseName, double grade)
        {
            if (CoursesAndGrades.ContainsKey(courseName))
            {
                CoursesAndGrades[courseName] = grade;
            }
        }
    }
    public class GPACalculator
    {
        public double CalculateGPA(Student student)
        {
            // Basic GPA calculation logic
            return student.CoursesAndGrades.Values.Average();
        }
    }
    public class TranscriptGenerator
    {
        private GPACalculator _gpaCalculator;
        public TranscriptGenerator(GPACalculator gpaCalculator)
        {
            _gpaCalculator = gpaCalculator;
        }
        public void PrintTranscript(Student student)
        {
            Console.WriteLine($"Transcript for {student.Name}");
            foreach (var course in student.CoursesAndGrades)
            {
                Console.WriteLine($"{course.Key}: {course.Value}");
            }
            Console.WriteLine($"GPA: {_gpaCalculator.CalculateGPA(student)}");
        }
    }
    
    #endregion

    #region Order

    public class OrderItem
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
    }

    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
    
    public class Order
    {
        public List<OrderItem> Items { get; private set; } = new List<OrderItem>();
        public Customer Customer { get; set; }

        public double CalculateOrderAmount()
        {
            return Items.Sum(item => item.Price);
        }
    }

    public class ReceiptGenerator
    {
        public string GenerateReceipt(Order  order)
        {
            return $"Receipt for {order.Customer.Name}: Total - {order.CalculateOrderAmount()}";
        }
    }

    public class CustomerNotifier
    {
        public void NotifyCustomer(Order order)
        {
            Console.WriteLine($"Email : {order.Customer.Email} has been received");
        }
    }
    

    #endregion
    //Testing the Single Responsibility Principle
    public class Program
    {
        public static void Main()
        {
            BankAccount johnsAccount = new BankAccount(123456);
            johnsAccount.Deposit(500);
            johnsAccount.Withdraw(100);

            StatementPrinter printer = new StatementPrinter();
            printer.Print(johnsAccount);
            
            
            Console.WriteLine("===========================================");
            Student alice = new Student("Alice");
            alice.EnrollCourse("Mathematics");
            alice.AssignGrade("Mathematics", 90);
            GPACalculator gpaCalc = new GPACalculator();
            TranscriptGenerator transcriptGen = new TranscriptGenerator(gpaCalc);
            transcriptGen.PrintTranscript(alice); 
            
            Console.WriteLine("===========================================");
            Order newOrder = new Order();
            // Add item:
            List<OrderItem> Items = new List<OrderItem>()
            {
                new OrderItem() { ProductName = "Alice", Price = 50 },
                new OrderItem() { ProductName = "Mathematics", Price = 50 },
                new OrderItem() { ProductName = "Water Melon", Price = 20 }
            };
            
            newOrder.Items.AddRange(Items);
            
            Customer customer = new Customer()
            {
                Name = "Pranaya",
                Email = "Pranaya@dotnettutorials.net"
            };
            newOrder.Customer = customer;

            ReceiptGenerator receiptGen = new ReceiptGenerator();
            string receipt = receiptGen.GenerateReceipt(newOrder);
            Console.WriteLine(receipt);
            CustomerNotifier notifier = new CustomerNotifier();
            notifier.NotifyCustomer(newOrder);
            
            
            Console.ReadKey();
        }
    }
}