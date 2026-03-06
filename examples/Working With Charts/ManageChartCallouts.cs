using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a pie chart to the slide (position and size are in points)
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
            Aspose.Slides.Charts.ChartType.Pie, 50f, 50f, 500f, 400f);

        // Show the value for each data label
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;

        // Display the data labels as callouts
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

        // Save the presentation to a PPTX file
        presentation.Save("ManageChartCallouts_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}