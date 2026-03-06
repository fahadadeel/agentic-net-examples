using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // List all supported chart types
            Array chartTypes = Enum.GetValues(typeof(Aspose.Slides.Charts.ChartType));
            foreach (Aspose.Slides.Charts.ChartType chartType in chartTypes)
            {
                Console.WriteLine(chartType);
            }

            // Save the presentation before exiting
            presentation.Save("SupportedChartTypes.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}