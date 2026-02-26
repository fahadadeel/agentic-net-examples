using System;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source PowerPoint file
        System.String inputPath = "input.pptx";

        // Output file name pattern for PNG images (slide index will replace {0})
        System.String outputFormat = "slide_{0}.png";

        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        // Iterate through each slide in the presentation
        for (System.Int32 index = 0; index < pres.Slides.Count; index++)
        {
            // Get the current slide
            Aspose.Slides.ISlide slide = pres.Slides[index];

            // Render the slide to an image
            using (Aspose.Slides.IImage image = slide.GetImage())
            {
                // Build the output file path for the current slide
                System.String outputPath = System.String.Format(outputFormat, index);

                // Save the image as PNG
                image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
            }
        }

        // Save the (potentially modified) presentation before exiting
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        pres.Dispose();
    }
}