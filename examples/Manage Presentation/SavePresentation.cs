using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Create PPTX save options using the factory
        Aspose.Slides.Export.SaveOptionsFactory optionsFactory = new Aspose.Slides.Export.SaveOptionsFactory();
        Aspose.Slides.Export.IPptxOptions pptxOptions = optionsFactory.CreatePptxOptions();

        // Set custom options (e.g., enable ZIP64 mode)
        pptxOptions.Zip64Mode = Aspose.Slides.Export.Zip64Mode.Always;

        // Save the presentation with custom options in PPTX format
        presentation.Save("CustomPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx, pptxOptions);
    }
}