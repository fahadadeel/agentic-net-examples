using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set a custom name for the master theme (allowed writable property)
        presentation.MasterTheme.Name = "MyCustomTheme";

        // Save the presentation as PPTX before exiting
        presentation.Save("PresentationWithTheme.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}