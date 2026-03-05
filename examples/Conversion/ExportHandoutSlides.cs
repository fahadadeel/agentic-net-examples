using System;

class Program
{
    static void Main()
    {
        // Input PPTX file path
        string inputPath = "input.pptx";
        // Output PPT file path
        string outputPath = "output.ppt";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Configure handout layout options (4 slides per page, horizontal)
        Aspose.Slides.Export.PdfOptions options = new Aspose.Slides.Export.PdfOptions
        {
            SlidesLayoutOptions = new Aspose.Slides.Export.HandoutLayoutingOptions
            {
                Handout = Aspose.Slides.Export.HandoutType.Handouts4Horizontal
            }
        };

        // Save the presentation as PPT using the handout layout options
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Ppt, options);

        // Release resources
        pres.Dispose();
    }
}