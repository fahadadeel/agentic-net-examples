using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the presentation from a PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");
        
        // Get the slide at the specified index (e.g., index 0 for the first slide)
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        
        // Perform any desired operations with the slide here
        // For example, you could read the slide's name:
        // string slideName = slide.Name;
        
        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        
        // Release resources
        presentation.Dispose();
    }
}