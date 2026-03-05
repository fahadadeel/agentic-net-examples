using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Load the presentation from a file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Get the slide size object
        Aspose.Slides.ISlideSize slideSize = presentation.SlideSize;

        // Retrieve the dimensions (width and height in points)
        SizeF size = slideSize.Size;

        // Output the slide dimensions
        Console.WriteLine("Slide width: {0} points", size.Width);
        Console.WriteLine("Slide height: {0} points", size.Height);

        // Save the presentation (no modifications made)
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}