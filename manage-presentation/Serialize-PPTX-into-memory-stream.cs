using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide (optional)
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Serialize the presentation to a memory stream in PPTX format
            MemoryStream memoryStream = new MemoryStream();
            presentation.Save(memoryStream, Aspose.Slides.Export.SaveFormat.Pptx);
            memoryStream.Position = 0; // Reset stream position for further processing

            // Example: write the memory stream to a file
            using (FileStream file = new FileStream("output.pptx", FileMode.Create, FileAccess.Write))
            {
                memoryStream.CopyTo(file);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}