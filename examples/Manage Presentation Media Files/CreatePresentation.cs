using System;

class Program
{
    static void Main()
    {
        // Create a new presentation (empty slide is added by default)
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Save the presentation as PPTX
        presentation.Save("NewPresentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}