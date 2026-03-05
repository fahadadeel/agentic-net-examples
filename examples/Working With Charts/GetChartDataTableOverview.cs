using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a line chart with sample data
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Line, 50, 50, 450, 300);

        // Enable the data table for the chart
        chart.HasDataTable = true;

        // Set number format for the first series values
        chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";

        // Retrieve the data table object
        Aspose.Slides.Charts.IDataTable dataTable = chart.ChartDataTable;

        // Customize the appearance of the data table
        dataTable.HasBorderHorizontal = true;
        dataTable.HasBorderVertical = true;
        dataTable.HasBorderOutline = true;
        dataTable.ShowLegendKey = false;

        // Save the presentation
        presentation.Save("ChartDataTableOverview.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}