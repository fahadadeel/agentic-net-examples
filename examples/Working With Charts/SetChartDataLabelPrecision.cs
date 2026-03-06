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
        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        // Add a line chart
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Line, 50f, 50f, 450f, 300f);
        // Enable data table (optional)
        chart.HasDataTable = true;
        // Set number format for series values (precision)
        chart.ChartData.Series[0].NumberFormatOfValues = "#,##0.00";
        // Show data labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
        // Set number format for data labels
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.NumberFormat = "#,##0.00";
        // Save the presentation
        presentation.Save("SetDataPrecision.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        // Dispose resources
        presentation.Dispose();
    }
}