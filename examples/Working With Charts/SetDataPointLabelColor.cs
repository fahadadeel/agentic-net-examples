using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
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

        // Set the label of the fourth data point to show its value
        dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;

        // Customize the label of the first data point (branch level)
        Aspose.Slides.Charts.IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;
        branch1Label.DataLabelFormat.ShowCategoryName = true;
        branch1Label.DataLabelFormat.ShowSeriesName = true;
        branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;

        // Change the fill color of the tenth data point
        Aspose.Slides.Charts.IFormat steam4Format = dataPoints[9].Format;
        steam4Format.Fill.FillType = Aspose.Slides.FillType.Solid;
        steam4Format.Fill.SolidFillColor.Color = Color.FromArgb(255, 0, 128, 255); // Example ARGB color

        // Save the presentation
        presentation.Save("SetDataPointLabelColor.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}