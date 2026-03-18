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
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a clustered column chart to the slide
            IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 400);

            // Enable the data table for the chart
            chart.HasDataTable = true;

            // Get the chart's data table
            IDataTable dataTable = chart.ChartDataTable;

            // Configure font attributes for the data table text
            dataTable.TextFormat.PortionFormat.FontHeight = 12f;
            dataTable.TextFormat.PortionFormat.FontBold = NullableBool.True;
            dataTable.TextFormat.PortionFormat.FontItalic = NullableBool.False;

            // Save the presentation
            pres.Save("ChartDataTableFont_out.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}