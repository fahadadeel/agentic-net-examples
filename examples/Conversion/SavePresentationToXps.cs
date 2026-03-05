using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the PPTX presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");
        
        // Save the presentation as XPS format
        presentation.Save("output.xps", Aspose.Slides.Export.SaveFormat.Xps);
        
        // Release resources
        presentation.Dispose();
    }
}