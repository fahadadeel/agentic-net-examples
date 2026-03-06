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

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie,
            50f,   // X position
            50f,   // Y position
            500f,  // Width
            400f   // Height
        );

        // Show the data values on the chart
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

        // Display the data labels as callouts
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

        // Save the presentation
        presentation.Save("AddCallouts_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}