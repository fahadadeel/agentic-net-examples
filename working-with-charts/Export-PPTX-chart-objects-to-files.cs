using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ChartExportApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.pptx";
                string outputDirectory = "ChartImages";
                Directory.CreateDirectory(outputDirectory);

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    int chartCounter = 0;
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                            Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;
                            if (chart != null)
                            {
                                Aspose.Slides.IImage chartImage = chart.GetImage();
                                string chartImagePath = Path.Combine(outputDirectory, $"chart_{chartCounter}.png");
                                using (FileStream fileStream = new FileStream(chartImagePath, FileMode.Create, FileAccess.Write))
                                {
                                    chartImage.Save(fileStream, Aspose.Slides.ImageFormat.Png);
                                }
                                chartCounter++;
                            }
                        }
                    }

                    // Save the presentation before exiting
                    presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}