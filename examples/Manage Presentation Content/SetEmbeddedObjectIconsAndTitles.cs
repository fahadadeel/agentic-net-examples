using System;
using Aspose.Slides;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load an existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Find the first OLE object frame on the slide
            Aspose.Slides.OleObjectFrame oleObjectFrame = null;
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                oleObjectFrame = shape as Aspose.Slides.OleObjectFrame;
                if (oleObjectFrame != null)
                {
                    break;
                }
            }

            if (oleObjectFrame != null)
            {
                // Show the OLE object as an icon
                oleObjectFrame.IsObjectIcon = true;

                // Set a custom title for the OLE icon
                oleObjectFrame.SubstitutePictureTitle = "Custom OLE Icon Title";
            }

            // Set the presentation title property
            Aspose.Slides.IDocumentProperties docProps = presentation.DocumentProperties;
            docProps.Title = "Managed OLE Object Presentation";

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}