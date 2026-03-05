using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Define position and size for the OLE object frame (in points)
        float x = 0f;
        float y = 0f;
        float width = presentation.SlideSize.Size.Width;
        float height = presentation.SlideSize.Size.Height;

        // Class name of the OLE object (e.g., Excel)
        string className = "Excel.Sheet";

        // Path to the external file to link
        string linkedFilePath = "C:\\Data\\Sample.xlsx";

        // Add a linked OLE object frame to the slide
        Aspose.Slides.IOleObjectFrame oleObjectFrame = slide.Shapes.AddOleObjectFrame(x, y, width, height, className, linkedFilePath);

        // Save the presentation
        presentation.Save("LinkedOleObject_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}