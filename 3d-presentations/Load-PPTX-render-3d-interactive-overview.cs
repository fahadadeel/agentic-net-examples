using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the PPTX presentation from file
            using (Presentation presentation = new Presentation("input.pptx"))
            {
                // Enable interactive 3D overview by setting the slide show type to kiosk mode
                presentation.SlideShowSettings.SlideShowType = new BrowsedAtKiosk();

                // Save the modified presentation before exiting
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}