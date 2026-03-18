using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string presentationPath = "input.pptx";
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(presentationPath))
            {
                Aspose.Slides.ISlide slide = pres.Slides[0];
                Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;
                if (chart != null)
                {
                    Aspose.Slides.Charts.IChartData chartData = chart.ChartData;
                    string externalPath = chartData.ExternalWorkbookPath;
                    Console.WriteLine("External workbook path: " + (externalPath ?? "None"));
                }
                else
                {
                    Console.WriteLine("No chart found on the first slide.");
                }

                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}