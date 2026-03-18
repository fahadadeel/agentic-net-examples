using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (var presentation = new Aspose.Slides.Presentation())
            {
                var slide = presentation.Slides[0];
                var chart = slide.Shapes.AddChart(Aspose.Slides.Charts.ChartType.ClusteredColumn, 50, 50, 500, 400);
                for (int i = 0; i < chart.ChartData.Series.Count; i++)
                {
                    slide.Timeline.MainSequence.AddEffect(
                        chart,
                        Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
                        i,
                        Aspose.Slides.Animation.EffectType.Fly,
                        Aspose.Slides.Animation.EffectSubtype.None,
                        Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
                }
                presentation.Save("ChartAnimation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}