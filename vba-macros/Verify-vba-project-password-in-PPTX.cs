using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string filePath = "input.pptm";
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath);
            bool isVbaProtected = false;
            if (presentation.VbaProject != null)
            {
                isVbaProtected = presentation.VbaProject.IsPasswordProtected;
            }
            if (isVbaProtected)
            {
                Console.WriteLine("The VBA project is password protected.");
            }
            else
            {
                Console.WriteLine("The VBA project is not password protected.");
            }
            // Save the presentation before exiting
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}