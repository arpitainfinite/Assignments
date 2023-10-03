using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "C:\\Users\\arpitas\\Desktop\\sample.txt"; 
        Console.WriteLine("Enter text to append to the file:");
        string textToAppend = Console.ReadLine();

        try
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                // Write the text to the file
                writer.WriteLine(textToAppend);
            }
            Console.WriteLine("Text appended to the file successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
        Console.ReadLine();
    }
}
