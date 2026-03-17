using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertToXps
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string[] inputFiles = new string[] { "sample.ppt", "sample.pptx" };
                foreach (string inputPath in inputFiles)
                {
                    try
                    {
                        using (Presentation pres = new Presentation(inputPath))
                        {
                            string outputPath = System.IO.Path.ChangeExtension(inputPath, ".xps");
                            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Xps);
                            Console.WriteLine($"Converted '{inputPath}' to '{outputPath}'.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error converting '{inputPath}': {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fatal error: {ex.Message}");
            }
        }
    }
}