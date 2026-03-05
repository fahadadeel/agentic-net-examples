using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the template PPTX file
        string templatePath = "Template.pptx";

        // Load the presentation from the template file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(templatePath))
        {
            // Save the presentation to a new file
            presentation.Save("Output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}