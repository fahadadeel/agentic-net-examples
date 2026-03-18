using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation in memory
            using (var tempPres = new Aspose.Slides.Presentation())
            {
                // Save the temporary presentation to a memory stream
                using (var memStream = new MemoryStream())
                {
                    tempPres.Save(memStream, Aspose.Slides.Export.SaveFormat.Pptx);
                    memStream.Position = 0;

                    // Load the presentation from the memory stream
                    using (var presentation = new Aspose.Slides.Presentation(memStream))
                    {
                        // Save the loaded presentation to a file
                        presentation.Save("LoadedFromMemory.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}