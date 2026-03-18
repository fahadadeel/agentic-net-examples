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
            using (Presentation presentation = new Presentation())
            {
                ISlide slide = presentation.Slides[0];
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);

                // Access the axes via the Axes property
                IAxesManager axesManager = chart.Axes;
                IAxis verticalAxis = axesManager.VerticalAxis;
                IAxis horizontalAxis = axesManager.HorizontalAxis;

                // Example modifications: enable axis titles
                verticalAxis.HasTitle = true;
                horizontalAxis.HasTitle = true;

                // Save the presentation before exiting
                presentation.Save("ChartAxesDemo.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}