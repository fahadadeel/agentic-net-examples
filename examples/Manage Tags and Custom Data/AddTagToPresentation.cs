using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the tag collection
        Aspose.Slides.ITagCollection tags = presentation.CustomData.Tags;

        // Add a custom tag
        tags["MyTag"] = "My Tag Value";

        // Save the presentation to a file
        presentation.Save("TaggedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}