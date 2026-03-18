using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideToPngConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input presentation path (use argument if provided)
                string inputPath = (args.Length > 0 && !String.IsNullOrEmpty(args[0])) ? args[0] : "presentation.pptx";

                // Output file name format for each slide PNG
                string outputFormat = "slide_{0}.png";

                // Load the presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through all slides and export each as PNG
                    for (int index = 0; index < pres.Slides.Count; index++)
                    {
                        Aspose.Slides.ISlide slide = pres.Slides[index];
                        using (Aspose.Slides.IImage image = slide.GetImage())
                        {
                            string outputPath = String.Format(outputFormat, index);
                            image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                        }
                    }

                    // Save the presentation (required before exit)
                    pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}