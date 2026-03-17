using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToPngConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = args.Length > 0 ? args[0] : "input.pptx";
                string outputFolder = args.Length > 1 ? args[1] : "output";

                if (!File.Exists(inputPath))
                {
                    Console.WriteLine("Input file not found: " + inputPath);
                    return;
                }

                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                using (Presentation presentation = new Presentation(inputPath))
                {
                    for (int index = 0; index < presentation.Slides.Count; index++)
                    {
                        IImage slideImage = presentation.Slides[index].GetImage();
                        string outputFile = Path.Combine(outputFolder, $"slide_{index + 1}.png");
                        slideImage.Save(outputFile, ImageFormat.Png);
                        slideImage.Dispose();
                    }

                    // Save the (unchanged) presentation before exiting
                    string savedPresentationPath = Path.Combine(outputFolder, "saved.pptx");
                    presentation.Save(savedPresentationPath, SaveFormat.Pptx);
                }

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}