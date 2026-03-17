using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide (default slide)
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Configure handout options to set the number of slides per printed page
            Aspose.Slides.Export.HandoutLayoutingOptions handoutOptions = new Aspose.Slides.Export.HandoutLayoutingOptions();
            handoutOptions.Handout = Aspose.Slides.Export.HandoutType.Handouts4Horizontal; // 4 slides per page

            // (Optional) Use the handout options when exporting to a format that supports them, e.g., PDF
            // Aspose.Slides.Export.PdfOptions pdfOptions = new Aspose.Slides.Export.PdfOptions();
            // pdfOptions.SlidesLayoutOptions = handoutOptions;
            // presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf, pdfOptions);

            // Save the presentation as PPTX
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}