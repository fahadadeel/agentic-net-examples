using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    0f, 0f, 500f, 400f);

                // Configure the category axis as a date axis
                Aspose.Slides.Charts.IAxis categoryAxis = chart.Axes.HorizontalAxis;
                categoryAxis.CategoryAxisType = Aspose.Slides.Charts.CategoryAxisType.Date;

                // Set the display format for the axis labels to a specific date pattern
                categoryAxis.NumberFormat = "mm/dd/yyyy";

                // Save the presentation
                presentation.Save("CategoryAxisDateFormat.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Output any errors to the console
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}