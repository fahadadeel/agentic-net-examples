using System;
using Aspose.Slides.Export;

namespace ConvertToXps
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "sample.pptx";
                string outputPath = "sample.xps";

                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
                Aspose.Slides.Export.XpsOptions options = new Aspose.Slides.Export.XpsOptions();
                // Example of setting an option:
                // options.SaveMetafilesAsPng = true;

                presentation.Save(outputPath, SaveFormat.Xps, options);
                presentation.Dispose();

                Console.WriteLine("Conversion completed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}