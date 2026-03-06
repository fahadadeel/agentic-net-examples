using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a Sunburst chart to the first slide
        Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Sunburst, 50f, 50f, 500f, 400f);

        // Get the data points collection of the first series
        Aspose.Slides.Charts.IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

        // Show value for the fourth data point (index 3) at level 0
        dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;

        // Configure label for the first data point (index 0) at level 2
        Aspose.Slides.Charts.IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
        branch1Label.DataLabelFormat.ShowCategoryName = true;
        branch1Label.DataLabelFormat.ShowSeriesName = true;
        branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;

        // Set fill color for the tenth data point (index 9)
        Aspose.Slides.Charts.IFormat steam4Format = dataPoints[9].Format;
        steam4Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        steam4Format.Fill.SolidFillColor.Color = Color.FromArgb(255, 0, 128, 0); // Example ARGB color

        // Save the presentation
        presentation.Save("SetDataPointLabelColor.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}