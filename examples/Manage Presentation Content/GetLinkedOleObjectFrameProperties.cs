using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Cast the first shape to OleObjectFrame
        Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes[0] as Aspose.Slides.OleObjectFrame;

        if (oleFrame != null)
        {
            // Read linked OLE object properties
            string linkPathRelative = oleFrame.LinkPathRelative;
            string linkFileName = oleFrame.LinkFileName;
            bool isObjectLink = oleFrame.IsObjectLink;
            string objectProgId = oleFrame.ObjectProgId;

            // Output the properties
            Console.WriteLine("LinkPathRelative: " + linkPathRelative);
            Console.WriteLine("LinkFileName: " + linkFileName);
            Console.WriteLine("IsObjectLink: " + isObjectLink);
            Console.WriteLine("ObjectProgId: " + objectProgId);
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", SaveFormat.Pptx);
    }
}