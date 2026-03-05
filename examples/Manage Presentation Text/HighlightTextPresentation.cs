using System;
using Aspose.Slides;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Load the existing presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");
        // Highlight all occurrences of the word "example" with yellow color
        presentation.HighlightText("example", System.Drawing.Color.Yellow);
        // Save the modified presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        // Release resources
        presentation.Dispose();
    }
}