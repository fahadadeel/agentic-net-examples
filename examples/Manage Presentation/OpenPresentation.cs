using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Source presentation file
        System.String srcFile = "input.pptx";
        // Destination file after saving
        System.String destFile = "output.pptx";

        // Open the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(srcFile);

        // Save the presentation in PPTX format
        pres.Save(destFile, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        pres.Dispose();
    }
}