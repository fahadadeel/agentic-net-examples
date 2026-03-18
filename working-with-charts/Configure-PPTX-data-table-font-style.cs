using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);

            // Enable the data table for the chart
            chart.HasDataTable = true;

            // Get the text format of the data table
            IChartTextFormat tableTextFormat = chart.ChartDataTable.TextFormat;

            // Set font size
            tableTextFormat.PortionFormat.FontHeight = 12f;

            // Set font typeface
            tableTextFormat.PortionFormat.LatinFont = new FontData("Arial");

            // Set font color
            tableTextFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

            // Save the presentation
            pres.Save("ChartDataTableFont.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}