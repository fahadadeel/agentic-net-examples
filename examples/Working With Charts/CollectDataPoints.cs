using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a Sunburst chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Sunburst, 0, 0, 500, 400);

        // Access the data points collection of the first series
        Aspose.Slides.Charts.IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

        // Set some label properties (example from add-color-to-data-points rule)
        dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;

        Aspose.Slides.Charts.IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
        branch1Label.DataLabelFormat.ShowCategoryName = true;
        branch1Label.DataLabelFormat.ShowSeriesName = true;
        branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Yellow;

        Aspose.Slides.Charts.IFormat steam4Format = dataPoints[9].Format;
        steam4Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        steam4Format.Fill.SolidFillColor.Color = System.Drawing.Color.FromArgb(255, 0, 0, 255); // Example ARGB color

        // Iterate over data points and output their indexes
        foreach (Aspose.Slides.Charts.IChartDataPoint dataPoint in chart.ChartData.Series[0].DataPoints)
        {
            System.Console.WriteLine("Data point index: " + dataPoint.Index);
        }

        // Save the presentation
        presentation.Save("DataPointsDemo.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}