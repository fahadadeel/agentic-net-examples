using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load the PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");
        // Save the presentation as HTML
        presentation.Save("output.html", Aspose.Slides.Export.SaveFormat.Html);
        // Release resources
        presentation.Dispose();
    }
}