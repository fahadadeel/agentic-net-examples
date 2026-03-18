using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (var presentation = new Presentation())
            {
                // Update document metadata
                var docProps = presentation.DocumentProperties;
                docProps.Title = "Sample Presentation";
                docProps.Author = "John Doe";

                // Adjust layout settings
                presentation.FirstSlideNumber = 5;

                // Save the presentation
                presentation.Save("ModifiedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}