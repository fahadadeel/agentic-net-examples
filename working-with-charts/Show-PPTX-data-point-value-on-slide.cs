using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace ShowDataPointValue
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation.
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide.
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a Pie chart to the slide.
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Pie, 0f, 0f, 500f, 400f);

                // Enable the display of the data point value for the first series, first label.
                chart.ChartData.Series[0].Labels[0].DataLabelFormat.ShowValue = true;

                // Optionally, customize the label text (override auto-generated text).
                // Here we set a custom text that includes the actual label value.
                // The GetActualLabelText method returns the rendered label text.
                string actualLabel = chart.ChartData.Series[0].Labels[0].GetActualLabelText();
                chart.ChartData.Series[0].Labels[0].AddTextFrameForOverriding(actualLabel);

                // Save the presentation.
                presentation.Save("DataPointValue.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}