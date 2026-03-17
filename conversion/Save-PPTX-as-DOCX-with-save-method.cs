using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Load an existing PPTX presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

                // Save the presentation in a supported format (DOCX is not directly supported)
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose the presentation to release resources
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Output any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}