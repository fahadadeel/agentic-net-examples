using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load the existing presentation from a file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Remove the first slide (index 0) from the presentation
        presentation.Slides.RemoveAt(0);

        // Save the modified presentation to a new file
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}