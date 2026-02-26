using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace ManagePresentationText
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Retrieve raw text from the presentation using the correct enum value
            Aspose.Slides.IPresentationFactory factory = Aspose.Slides.PresentationFactory.Instance;
            Aspose.Slides.IPresentationText presentationText = factory.GetPresentationText(inputPath, Aspose.Slides.TextExtractionArrangingMode.Arranged);

            // (Optional) Use the extracted text information here
            // For example, write the extracted text of each slide to console
            if (presentationText != null && presentationText.SlidesText != null)
            {
                for (int i = 0; i < presentationText.SlidesText.Length; i++)
                {
                    Console.WriteLine($"Slide {i + 1} Text:");
                    Console.WriteLine(presentationText.SlidesText[i].Text);
                }
            }

            // Save the presentation as PPTX
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}