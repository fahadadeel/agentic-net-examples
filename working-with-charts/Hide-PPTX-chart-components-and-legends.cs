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
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            using (var presentation = new Aspose.Slides.Presentation(inputPath))
            {
                foreach (var slide in presentation.Slides)
                {
                    foreach (var shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.Charts.IChart chart)
                        {
                            // Hide legend
                            chart.HasLegend = false;
                            // Hide title
                            chart.HasTitle = false;
                            // Hide axes
                            chart.Axes.VerticalAxis.IsVisible = false;
                            chart.Axes.HorizontalAxis.IsVisible = false;
                        }
                    }
                }

                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}