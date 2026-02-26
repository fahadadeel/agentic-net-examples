using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the source PPTX file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

        // Specify which slide(s) to export (slide numbers start at 1)
        int[] slideIndices = new int[] { 1 };

        // Export the selected slide(s) to a PDF file
        presentation.Save("output.pdf", slideIndices, Aspose.Slides.Export.SaveFormat.Pdf);

        // Release resources
        presentation.Dispose();
    }
}