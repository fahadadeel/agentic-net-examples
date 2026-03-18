using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string templatePath = "Template.pptx";
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(templatePath))
            {
                // Save the loaded presentation to a new file
                presentation.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}