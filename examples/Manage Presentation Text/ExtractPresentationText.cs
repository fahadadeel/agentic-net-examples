using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        // Define input file name and construct full path
        string inputFileName = "sample.pptx";
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);

        // Extract raw text from the presentation using Unarranged mode
        Aspose.Slides.IPresentationText presentationText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(filePath, Aspose.Slides.TextExtractionArrangingMode.Unarranged);

        // Iterate through each slide's extracted text and output to console
        for (int i = 0; i < presentationText.SlidesText.Length; i++)
        {
            Aspose.Slides.ISlideText slideText = presentationText.SlidesText[i];
            Console.WriteLine("Slide {0} text:", i + 1);
            Console.WriteLine(slideText.Text);
        }

        // Load the presentation and save it (no modifications) to satisfy save-before-exit rule
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(filePath))
        {
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}