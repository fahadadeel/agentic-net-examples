using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing presentation from file
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
            {
                // Example manipulation: get the number of slides
                int slideCount = presentation.Slides.Count;
                Console.WriteLine("Number of slides: " + slideCount);

                // Save the presentation after manipulation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}