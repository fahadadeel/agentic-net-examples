using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation that contains an OLE object
        Presentation presentation = new Presentation("input.pptx");

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Cast the first shape on the slide to OleObjectFrame
        OleObjectFrame oleObject = slide.Shapes[0] as OleObjectFrame;

        if (oleObject != null)
        {
            // Display the OLE object as an icon
            oleObject.IsObjectIcon = true;

            // Set the title for the OLE object icon
            oleObject.SubstitutePictureTitle = "Embedded Excel Sheet";
        }

        // Save the modified presentation
        presentation.Save("output.pptx", SaveFormat.Pptx);
    }
}