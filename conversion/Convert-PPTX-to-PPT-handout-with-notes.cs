using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptxToPpt
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the source PPTX presentation
                Presentation presentation = new Presentation("input.pptx");

                // Create PPT save options (handout layout not supported for PPT)
                PptOptions pptOptions = new PptOptions();

                // Save the presentation as PPT format
                presentation.Save("output.ppt", Aspose.Slides.Export.SaveFormat.Ppt, pptOptions);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during conversion
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}