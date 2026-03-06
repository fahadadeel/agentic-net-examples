using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

class Program
{
    static void Main()
    {
        // Path to the source presentation
        string inputPath = "input.pptx";
        // Path where the modified presentation will be saved
        string outputPath = "output.pptx";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Get the first shape on the slide and cast it to IChart
        Aspose.Slides.Charts.IChart chart = (Aspose.Slides.Charts.IChart)slide.Shapes[0];

        // Set the data range for the chart
        chart.ChartData.SetRange("Sheet1!$A$1:$C$4");

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Release resources
        presentation.Dispose();
    }
}