using System;

public delegate int CalculatorOperation(int num1, int num2);

class Program1
{
    static void Main()
    {
        CalculatorOperation add = (num1, num2) => num1 + num2;
        CalculatorOperation subtract = (num1, num2) => num1 - num2;
        CalculatorOperation multiply = (num1, num2) => num1 * num2;

        Console.WriteLine("Calculator Program: ");
        Console.WriteLine("1. Addition");
        Console.WriteLine("2. Subtraction");
        Console.WriteLine("3. Multiplication");
        Console.WriteLine("Enter your choice (1/2/3):");

        if (int.TryParse(Console.ReadLine(), out int choice) && (choice >= 1 && choice <= 3))

        {
            Console.Write("Enter first number: ");
            if (int.TryParse(Console.ReadLine(), out int num1))

            {
                Console.Write("Enter second number: ");
                if (int.TryParse(Console.ReadLine(), out int num2))

                {

                    int result = 0;
                    string operation = "";

                    switch (choice)
                    {
                        case 1:

                            result = add(num1, num2);
                            operation = "Addition";
                            break;

                        case 2:

                            result = subtract(num1, num2);
                            operation = "Subtraction";
                            break;

                        case 3:

                            result = multiply(num1, num2);
                            operation = "Multiplication";
                            break;

                    }

                    Console.WriteLine($"{operation} result: {result}");
                }

                else

                {
                    Console.WriteLine("Invalid input for the second number.");
                }

            }

            else

            {
                Console.WriteLine("Invalid input for the first number.");
            }

        }

        else

        {
            Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
        }
        Console.ReadLine();
    }
}

