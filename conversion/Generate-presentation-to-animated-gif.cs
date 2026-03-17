using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation file
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Create GIF export options (default settings)
            Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();

            // Save the presentation as an animated GIF
            presentation.Save("output.gif", Aspose.Slides.Export.SaveFormat.Gif, gifOptions);
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}