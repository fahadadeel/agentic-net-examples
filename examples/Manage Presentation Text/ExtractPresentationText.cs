using System;
using System.IO;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file names
            string inputFileName = "sample.pptx";
            string outputFileName = "sample_out.pptx";

            // Build full paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), outputFileName);

            // Fast text extraction using PresentationFactory (unarranged mode)
            Aspose.Slides.IPresentationText presentationText = Aspose.Slides.PresentationFactory.Instance.GetPresentationText(
                inputPath,
                Aspose.Slides.TextExtractionArrangingMode.Unarranged);

            // Iterate through each slide and display categorized text
            for (int i = 0; i < presentationText.SlidesText.Length; i++)
            {
                Aspose.Slides.ISlideText slideText = presentationText.SlidesText[i];
                Console.WriteLine("Slide " + (i + 1) + " - Text:");
                Console.WriteLine(slideText.Text);
                Console.WriteLine("Master Text:");
                Console.WriteLine(slideText.MasterText);
                Console.WriteLine("Notes Text:");
                Console.WriteLine(slideText.NotesText);
                Console.WriteLine("Comments Text:");
                Console.WriteLine(slideText.CommentsText);
                Console.WriteLine("Layout Text:");
                Console.WriteLine(slideText.LayoutText);
                Console.WriteLine("---------------------------");
            }

            // Load the presentation (no modifications) and save it before exiting
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}