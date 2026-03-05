using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the source presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");
        // Create XPS export options
        Aspose.Slides.Export.XpsOptions options = new Aspose.Slides.Export.XpsOptions();
        // Convert metafiles to PNG during export
        options.SaveMetafilesAsPng = true;
        // Save the presentation as XPS with the custom options
        pres.Save("output.xps", Aspose.Slides.Export.SaveFormat.Xps, options);
        // Release resources
        pres.Dispose();
    }
}