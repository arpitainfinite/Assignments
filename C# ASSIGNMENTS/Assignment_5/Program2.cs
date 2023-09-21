using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    class SaleDetails
    {
        private int SalesNo;
        private int ProductNo;
        private double Price;
        private DateTime DateOfSale;
        private int Qty;
        private double TotalAmount;

        public SaleDetails(int salesNo, int productNo, double price, int qty, DateTime dateOfSale)
        {
            this.SalesNo = salesNo;
            this.ProductNo = productNo;
            this.Price = price;
            this.DateOfSale = dateOfSale;
            this.Qty = qty;
            this.TotalAmount = 0; 
        }
        public void Sales()
        {
            TotalAmount = Qty * Price;
        }
        public void ShowData()
        {

            Console.WriteLine("==================FINAL DETAILS==========================");

            Console.WriteLine("Sales No: " + SalesNo);
            Console.WriteLine("Product No: " + ProductNo);
            Console.WriteLine("Price: " + Price);
            Console.WriteLine("Date of Sale: " + DateOfSale.ToShortDateString());
            Console.WriteLine("Qty: " + Qty);
            Console.WriteLine("Total Amount: " + TotalAmount);
        }
    }

    class Program2
    {
        static void Main()
        {
            Console.WriteLine("Enter Sales No:");
            int salesNo = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Product No:");
            int productNo = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Price:");
            double price = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Quantity (Qty):");
            int qty = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Date of Sale (yyyy-MM-dd):");
            DateTime dateOfSale = DateTime.Parse(Console.ReadLine());

            SaleDetails sale = new SaleDetails(salesNo, productNo, price, qty, dateOfSale);
            sale.Sales();

            sale.ShowData();
            Console.ReadLine();
        }
    }

}
