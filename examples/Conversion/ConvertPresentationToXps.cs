using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the source presentation file
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Save the presentation to XPS format using default options
            pres.Save("output.xps", Aspose.Slides.Export.SaveFormat.Xps);
        }
    }
}