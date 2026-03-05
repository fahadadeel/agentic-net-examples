using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Set the content type to PPTX format for embedded objects
        presentation.DocumentProperties.ContentType = "application/vnd.openxmlformats-officedocument.presentationml.presentation";

        // Save the presentation
        presentation.Save("EmbeddedObjectFileType.pptx", SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}