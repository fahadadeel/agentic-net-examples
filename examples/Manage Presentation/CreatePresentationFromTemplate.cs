using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the template PPTX file
        string templatePath = "Template.pptx";
        // Path where the new presentation will be saved
        string outputPath = "OutputPresentation.pptx";

        // Load the existing presentation from the template file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(templatePath))
        {
            // (Optional) Modify the presentation here

            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}