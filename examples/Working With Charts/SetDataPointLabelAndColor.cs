using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace SetDataPointLabelAndColor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a Sunburst chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Sunburst,
                50f, 50f, 500f, 400f);

            // Get the collection of data points from the first series
            Aspose.Slides.Charts.IChartDataPointCollection dataPoints = chart.ChartData.Series[0].DataPoints;

            // Set the label of the 4th data point (index 3) to show its value
            dataPoints[3].DataPointLevels[0].Label.DataLabelFormat.ShowValue = true;

            // Access a specific data point level label (branch level)
            Aspose.Slides.Charts.IDataLabel branch1Label = dataPoints[0].DataPointLevels[2].Label;

            // Configure the label to show category and series names
            branch1Label.DataLabelFormat.ShowCategoryName = true;
            branch1Label.DataLabelFormat.ShowSeriesName = true;

            // Set the label text fill color to solid yellow
            branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            branch1Label.DataLabelFormat.TextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Yellow;

            // Change the fill color of the 10th data point (index 9)
            Aspose.Slides.Charts.IFormat steam4Format = dataPoints[9].Format;
            steam4Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            steam4Format.Fill.SolidFillColor.Color = Color.FromArgb(255, 0, 0, 255); // Example ARGB color

            // Save the presentation
            presentation.Save("SetDataPointLabelAndColor.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}