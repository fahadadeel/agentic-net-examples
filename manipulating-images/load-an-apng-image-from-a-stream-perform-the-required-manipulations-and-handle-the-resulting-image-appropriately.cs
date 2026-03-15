using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Apng;

class Program
{
    static void Main(string[] args)
    {
        // Path to the input APNG file
        string inputPath = "input.apng";
        // Path to the output APNG file after manipulation
        string outputPath = "output.apng";

        // Load the APNG image from a file stream
        using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
        using (ApngImage apngImage = (ApngImage)Image.Load(inputStream))
        {
            // Example manipulation: adjust gamma
            apngImage.AdjustGamma(1.2f);

            // Save the manipulated APNG image to a file
            apngImage.Save(outputPath);
        }
    }
}