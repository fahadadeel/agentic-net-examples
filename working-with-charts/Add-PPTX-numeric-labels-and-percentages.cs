using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace AddPptxNumericLabelsAndPercentages
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a stacked column chart (use percentages)
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.StackedColumn,
                    50f, 50f, 500f, 400f);

                // Set chart title
                chart.HasTitle = true;
                chart.ChartTitle.AddTextFrameForOverriding("Quarterly Sales");
                chart.ChartTitle.TextFrameForOverriding.TextFrameFormat.CenterText = Aspose.Slides.NullableBool.True;

                // Show numeric values and percentages for the first series
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowPercentage = true;

                // Optionally, show category names for data labels
                chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowCategoryName = true;

                // Save the presentation
                presentation.Save("NumericLabelsAndPercentages.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}