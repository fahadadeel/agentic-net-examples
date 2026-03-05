using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the PPTX presentation from a file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");
        
        // Save the presentation before exiting
        presentation.Save("output.pptx", SaveFormat.Pptx);
        
        // Release resources
        presentation.Dispose();
    }
}