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
        Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 300);

        // Enable value display and callout for the first series
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowValue = true;
        chart.ChartData.Series[0].Labels.DefaultDataLabelFormat.ShowLabelAsDataCallout = true;

        // Save the presentation to a PPTX file
        string outPath = "AddCallouts_out.pptx";
        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Open the saved presentation
        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outPath) { UseShellExecute = true });
    }
}