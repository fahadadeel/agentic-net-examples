using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            var presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            var slide = presentation.Slides[0];

            // Add a clustered column chart
            var chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50, 50, 500, 400);

            // Enable callout for data labels of the first series
            chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

            // Get the first data point of the first series
            var dataPoint = chart.ChartData.Series[0].DataPoints[0];

            // Set fill color for the callout
            dataPoint.Format.Fill.FillType = Aspose.Slides.FillType.Solid;
            dataPoint.Format.Fill.SolidFillColor.Color = System.Drawing.Color.Yellow;

            // Set line color for the callout
            dataPoint.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            dataPoint.Format.Line.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;

            // Configure the data label to show the value
            var label = dataPoint.Label;
            label.DataLabelFormat.ShowValue = true;
            label.TextFormat.PortionFormat.FontHeight = 12;
            label.TextFormat.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;

            // Save the presentation
            presentation.Save("CalloutExample_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}