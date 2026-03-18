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
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a High-Low-Close stock chart
            IChart chart = slide.Shapes.AddChart(
                ChartType.HighLowClose, // Stock chart type
                50f,   // X position
                50f,   // Y position
                500f,  // Width
                400f   // Height
            );

            // Set chart title
            chart.HasTitle = true;
            chart.ChartTitle.AddTextFrameForOverriding("High-Low-Close Stock Chart");
            chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = NullableBool.True;

            // Save the presentation
            presentation.Save("StockChartPresentation.pptx", SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}