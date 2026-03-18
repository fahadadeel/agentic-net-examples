using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load an existing presentation
                Presentation presentation = new Presentation("input.pptx");

                // Create PPTX save options using the factory
                SaveOptionsFactory optionsFactory = new SaveOptionsFactory();
                IPptxOptions pptxOptions = optionsFactory.CreatePptxOptions();

                // Example: set a property on the options (optional)
                pptxOptions.RefreshThumbnail = true;

                // Save the presentation as PPTX with the specified options
                string outputPath = "output.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx, pptxOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}