using System;
namespace OCPDemo
{
    #region  Example 1
    //Create an interface for the discount strategy
        public interface IDiscountStrategy
        {
            double CalculateDiscount(double price);
        }
    
        //Implement this interface for each discount type
        public class RegularDiscount : IDiscountStrategy
        {
            public double CalculateDiscount(double price)
            {
                return price * 0.1;
            }
        }
    
        public class PremiumDiscount : IDiscountStrategy
        {
            public double CalculateDiscount(double price)
            {
                return price * 0.3;
            }
        }
    
        public class NewbieDiscount : IDiscountStrategy
        {
            public double CalculateDiscount(double price)
            {
                return price * 0.05;
            }
        }
    
        //Modify the DiscountCalculator class to accept an IDiscountStrategy
        public class DiscountCalculator
        {
            private readonly IDiscountStrategy _discountStrategy;
    
            public DiscountCalculator(IDiscountStrategy discountStrategy)
            {
                _discountStrategy = discountStrategy;
            }
    
            public double CalculateDiscount(double price)
            {
                return _discountStrategy.CalculateDiscount(price);
            }
        }    
    #endregion
    
    #region  Example 2
    //Define an interface for report generation
    public interface IReportGenerator
    {
        void GenerateReport(string data);
    }
    //Implement this interface for each report type
    public class PDFReportGenerator : IReportGenerator
    {
        public void GenerateReport(string data)
        {
            Console.WriteLine($"Generating PDF report with data: {data}");
        }
    }
    public class CSVReportGenerator : IReportGenerator
    {
        public void GenerateReport(string data)
        {
            Console.WriteLine($"Generating CSV report with data: {data}");
        }
    }
    public class XMLReportGenerator : IReportGenerator
    {
        public void GenerateReport(string data)
        {
            Console.WriteLine($"Generating XML report with data: {data}");
        }
    }
    //Modify the main ReportGenerationService to work with any report generator
    public class ReportGenerationService
    {
        private readonly IReportGenerator _reportGenerator;
        public ReportGenerationService(IReportGenerator reportGenerator)
        {
            _reportGenerator = reportGenerator;
        }
        public void GenerateReport(string data)
        {
            _reportGenerator.GenerateReport(data);
        }
    }
    #endregion
    
    //Testing the Open-Closed Principle
    public class Program
    {
        public static void Main()
        {
            //Example 1:
            var regularDiscount = new RegularDiscount();
            var calculator = new DiscountCalculator(regularDiscount);
            double discountedPrice = calculator.CalculateDiscount(100); // 10% discount applied

            var premiumDiscount = new PremiumDiscount();
            calculator = new DiscountCalculator(premiumDiscount);
            discountedPrice = calculator.CalculateDiscount(100); // 30% discount applied
            
            //Example 2:
            var pdfGenerator = new PDFReportGenerator();
            var service = new ReportGenerationService(pdfGenerator);
            service.GenerateReport("PDF Report Data");
            var csvGenerator = new CSVReportGenerator();
            service = new ReportGenerationService(csvGenerator);
            service.GenerateReport("CSV Report Data");
            
            Console.ReadKey();
            
            Console.ReadKey();
        }
    }
}