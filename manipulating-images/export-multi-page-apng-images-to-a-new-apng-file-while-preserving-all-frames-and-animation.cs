using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Usage: <source_apng> <destination_apng>");
            return;
        }

        string sourcePath = args[0];
        string destinationPath = args[1];

        using (Image image = Image.Load(sourcePath))
        {
            image.Save(destinationPath, new ApngOptions());
        }
    }
}