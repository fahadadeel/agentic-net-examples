using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create load options and set the default text language for the presentation
        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
        loadOptions.DefaultTextLanguage = "en-US";

        // Create a new presentation using the load options
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(loadOptions);

        // Add a rectangle shape with some text
        Aspose.Slides.IAutoShape shp = pres.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle,
            50,   // x-coordinate
            50,   // y-coordinate
            150,  // width
            50    // height
        );
        shp.TextFrame.Text = "Sample Text";

        // Save the presentation in PPTX format
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        pres.Dispose();
    }
}