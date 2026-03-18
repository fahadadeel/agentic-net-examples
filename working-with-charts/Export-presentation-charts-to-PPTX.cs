using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Paths for source and output presentations
            string sourcePath = "source.pptx";
            string outputPath = "charts_export.pptx";

            // Load the source presentation
            using (Aspose.Slides.Presentation sourcePres = new Aspose.Slides.Presentation(sourcePath))
            {
                // Create a new presentation to hold exported charts
                using (Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation())
                {
                    // Remove the default empty slide
                    destPres.Slides.RemoveAt(0);

                    // Iterate through each slide in the source presentation
                    for (int slideIndex = 0; slideIndex < sourcePres.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide sourceSlide = sourcePres.Slides[slideIndex];

                        // Iterate through each shape on the slide
                        for (int shapeIndex = 0; shapeIndex < sourceSlide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.Charts.IChart chart = sourceSlide.Shapes[shapeIndex] as Aspose.Slides.Charts.IChart;
                            if (chart != null)
                            {
                                // Render the chart to an image
                                Aspose.Slides.IImage chartImage = chart.GetImage();

                                // Add a new empty slide to the destination presentation
                                Aspose.Slides.ISlide destSlide = destPres.Slides.AddEmptySlide(destPres.LayoutSlides[0]);

                                // Add the chart image as a picture frame on the new slide
                                destSlide.Shapes.AddPictureFrame(
                                    Aspose.Slides.ShapeType.Rectangle,
                                    0,
                                    0,
                                    chartImage.Width,
                                    chartImage.Height,
                                    destPres.Images.AddImage(chartImage));
                            }
                        }
                    }

                    // Save the destination presentation containing all exported charts
                    destPres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}