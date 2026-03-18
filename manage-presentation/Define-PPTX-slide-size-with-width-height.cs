using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            var presentation = new Aspose.Slides.Presentation();

            // Define custom slide dimensions (in points)
            var width = 960f;
            var height = 540f;

            // Set the slide size with no scaling of existing content
            presentation.SlideSize.SetSize(width, height, Aspose.Slides.SlideSizeScaleType.DoNotScale);

            // Save the presentation to a PPTX file
            presentation.Save("CustomSizePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}