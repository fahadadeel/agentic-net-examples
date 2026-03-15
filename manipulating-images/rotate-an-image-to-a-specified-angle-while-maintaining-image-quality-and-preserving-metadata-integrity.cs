using System;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Expect: inputPath outputPath angle
        if (args.Length < 3)
        {
            Console.WriteLine("Usage: <inputPath> <outputPath> <angle>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];
        if (!float.TryParse(args[2], out float angle))
        {
            Console.WriteLine("Invalid angle.");
            return;
        }

        // Load the image, rotate, and save while preserving metadata
        using (Image image = Image.Load(inputPath))
        {
            // Rotate around center, resize canvas proportionally, white background
            image.Rotate(angle, true, Color.White);
            image.Save(outputPath);
        }
    }
}