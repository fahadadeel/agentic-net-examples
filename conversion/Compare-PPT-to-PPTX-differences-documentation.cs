using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ComparePptToPptx
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPT file and output PPTX file paths
            string inputPath = "input.ppt";
            string outputPath = "output.pptx";

            try
            {
                // Load the PPT presentation
                Presentation presentation = new Presentation(inputPath);

                // Create a SaveOptionsFactory instance and obtain PPTX save options
                SaveOptionsFactory optionsFactory = new SaveOptionsFactory();
                IPptxOptions pptxOptions = optionsFactory.CreatePptxOptions();

                // Save the presentation as PPTX using the obtained options
                presentation.Save(outputPath, SaveFormat.Pptx, pptxOptions);

                // Dispose the presentation before exiting
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during conversion
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}