using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        // Create output directory
        string outputDir = Path.Combine(Environment.CurrentDirectory, "Output");
        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add empty slides based on existing layout slides
        Aspose.Slides.ISlideCollection slideColl = pres.Slides;
        int i = 0;
        for (i = 0; i < pres.LayoutSlides.Count; i++)
        {
            slideColl.AddEmptySlide(pres.LayoutSlides[i]);
        }

        // Save temporary presentation to extract text overview
        string tempPath = Path.Combine(outputDir, "temp.pptx");
        pres.Save(tempPath, SaveFormat.Pptx);

        // Extract raw text from the temporary presentation
        Aspose.Slides.IPresentationText presentationText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(tempPath, TextExtractionArrangingMode.Unarranged);
        for (int slideIndex = 0; slideIndex < presentationText.SlidesText.Length; slideIndex++)
        {
            Aspose.Slides.ISlideText slideText = presentationText.SlidesText[slideIndex];
            Console.WriteLine("Slide " + (slideIndex + 1) + " Text:");
            Console.WriteLine(slideText.Text);
        }

        // Add a summary zoom frame to the first slide
        Aspose.Slides.ISlide firstSlide = pres.Slides[0];
        Aspose.Slides.ISummaryZoomFrame summaryZoom = firstSlide.Shapes.AddSummaryZoomFrame(50, 50, 400, 300);

        // Save the final presentation in PPT format
        string outPath = Path.Combine(outputDir, "PresentationOverview.ppt");
        pres.Save(outPath, SaveFormat.Ppt);
        pres.Dispose();
    }
}