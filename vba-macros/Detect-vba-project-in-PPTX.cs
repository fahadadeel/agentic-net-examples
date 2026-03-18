using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the presentation file
            string filePath = "input.pptx";

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))
            {
                // Check if a VBA project is attached
                bool hasVba = presentation.VbaProject != null;

                // Output the detection result
                Console.WriteLine(hasVba ? "Presentation contains VBA project." : "Presentation does not contain VBA project.");

                // Save the presentation before exiting (no modifications made)
                presentation.Save(filePath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}