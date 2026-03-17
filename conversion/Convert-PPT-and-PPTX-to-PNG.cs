using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source presentation (PPT or PPTX)
            string inputPath = "input.pptx";

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate through all slides and export each as PNG
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    ISlide slide = presentation.Slides[index];
                    IImage image = slide.GetImage();
                    string outputPath = $"slide_{index + 1}.png";
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                }

                // Save the presentation before exiting (preserve original format)
                if (inputPath.EndsWith(".pptx", StringComparison.OrdinalIgnoreCase))
                {
                    presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
                else if (inputPath.EndsWith(".ppt", StringComparison.OrdinalIgnoreCase))
                {
                    presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Ppt);
                }
                else
                {
                    // Default fallback
                    presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
        }
        catch (Exception ex)
        {
            // Output any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}