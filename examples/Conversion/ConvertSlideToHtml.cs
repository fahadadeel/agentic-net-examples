using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load an existing presentation from a file
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx"))
        {
            // Convert and save the presentation to HTML format
            presentation.Save("output.html", Aspose.Slides.Export.SaveFormat.Html);
        }
    }
}