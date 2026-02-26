using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DesignPresentationDefaultFont
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Set default regular font using PptxOptions (concrete SaveOptions)
            Aspose.Slides.Export.PptxOptions pptxOptions = new Aspose.Slides.Export.PptxOptions();
            pptxOptions.DefaultRegularFont = "Arial";

            // Save the presentation with the specified default font
            presentation.Save("DefaultFontPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx, pptxOptions);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}