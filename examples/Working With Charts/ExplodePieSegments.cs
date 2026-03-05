using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a pie chart with sample data
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 400);

        // Access the first series (default series)
        Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series[0];

        // Explode individual slices
        series.DataPoints[0].Explosion = 20; // explode first slice by 20%
        series.DataPoints[1].Explosion = 30; // explode second slice by 30%
        series.DataPoints[2].Explosion = 10; // explode third slice by 10%

        // Save the presentation
        presentation.Save("ExplodedPieChart.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}