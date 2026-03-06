using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide (index 0)
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a pie chart to the slide
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);

        // Show the data values for the first series
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

        // Enable data callouts for the first series
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

        // Save the presentation to a PPTX file
        presentation.Save("ChartCallouts.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}