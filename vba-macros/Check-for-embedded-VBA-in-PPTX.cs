using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string filePath = "input.pptx";
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))
            {
                bool hasVbaProject = presentation.VbaProject != null;
                Console.WriteLine("Presentation contains VBA project: " + hasVbaProject);
                // Save the presentation before exiting
                presentation.Save(filePath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}