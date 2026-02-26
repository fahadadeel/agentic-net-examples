using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PPT file
        string inputPath = "sample.ppt";
        // Path for the converted PPTX file
        string outputPath = "sample_converted.pptx";

        // Load the PPT presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            // Create PPTX save options
            Aspose.Slides.Export.ISaveOptionsFactory optionsFactory = new Aspose.Slides.Export.SaveOptionsFactory();
            Aspose.Slides.Export.IPptxOptions pptxOptions = optionsFactory.CreatePptxOptions();

            // Save the presentation as PPTX
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx, pptxOptions);
        }
    }
}