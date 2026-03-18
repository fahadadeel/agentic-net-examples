using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the source presentation
            string inputPath = "input.pptx";

            // Directory to store exported chart images
            string outputDir = "Charts";
            Directory.CreateDirectory(outputDir);

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                int chartIndex = 0;

                // Iterate through all slides
                for (int slideIdx = 0; slideIdx < presentation.Slides.Count; slideIdx++)
                {
                    ISlide slide = presentation.Slides[slideIdx];

                    // Iterate through all shapes on the slide
                    for (int shapeIdx = 0; shapeIdx < slide.Shapes.Count; shapeIdx++)
                    {
                        IShape shape = slide.Shapes[shapeIdx];

                        // Check if the shape is a chart
                        if (shape is IChart)
                        {
                            IChart chart = (IChart)shape;

                            // Export the chart as an image
                            Aspose.Slides.IImage chartImage = chart.GetImage();
                            string chartPath = Path.Combine(outputDir, $"chart_{chartIndex}.png");
                            chartImage.Save(chartPath, Aspose.Slides.ImageFormat.Png);
                            chartIndex++;
                        }
                    }
                }

                // Save the presentation before exiting
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}