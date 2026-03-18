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
            // Path to the source PPTX file
            string sourcePath = "input.pptx";

            // Read the file into a byte array
            byte[] fileBytes = File.ReadAllBytes(sourcePath);

            // Load the presentation from a memory stream
            using (MemoryStream stream = new MemoryStream(fileBytes))
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(stream))
                {
                    // Save the presentation to a new file
                    string outputPath = "output.pptx";
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}