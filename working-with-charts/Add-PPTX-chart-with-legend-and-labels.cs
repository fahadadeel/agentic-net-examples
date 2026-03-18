using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation pres = new Presentation())
            {
                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Add a clustered column chart at specified position and size
                IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

                // Enable and set the chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Sample Chart");

                // Save the presentation
                pres.Save("ChartPresentation.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}