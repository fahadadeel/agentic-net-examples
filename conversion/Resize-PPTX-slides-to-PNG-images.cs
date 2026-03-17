using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the PowerPoint presentation
            using (Presentation pres = new Presentation("input.pptx"))
            {
                // Define scaling factors for custom image size
                float scaleX = 2f;
                float scaleY = 2f;

                // Iterate through all slides and save each as PNG
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    ISlide slide = pres.Slides[i];
                    using (IImage image = slide.GetImage(scaleX, scaleY))
                    {
                        string outputPath = $"slide_{i}.png";
                        image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                    }
                }

                // Save the presentation before exiting
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}