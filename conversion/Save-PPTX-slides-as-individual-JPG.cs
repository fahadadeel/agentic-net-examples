using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Directory to store exported JPG images
            string outputDir = "output";

            // Ensure output directory exists
            if (!System.IO.Directory.Exists(outputDir))
                System.IO.Directory.CreateDirectory(outputDir);

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Iterate through each slide and export as JPG
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                ISlide slide = pres.Slides[i];
                using (IImage image = slide.GetImage())
                {
                    string outputPath = System.IO.Path.Combine(outputDir, $"Slide_{i + 1}.jpg");
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Jpeg);
                }
            }

            // Save the presentation (no modifications made)
            pres.Save("output.pptx", SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}