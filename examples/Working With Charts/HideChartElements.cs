using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];
        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 0, 0, 500, 500);
        // Hide various data label elements for the first series
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLegendKey = false;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = false;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowCategoryName = false;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowSeriesName = false;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = false;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowBubbleSize = false;
        // Save the presentation
        pres.Save("HideChartElements_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}