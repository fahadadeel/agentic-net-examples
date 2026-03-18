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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.ClusteredColumn,
                50f, 50f, 400f, 300f);

            Aspose.Slides.Animation.ISequence mainSequence = presentation.Slides[0].Timeline.MainSequence;

            Aspose.Slides.Animation.IEffect effect = mainSequence.AddEffect(
                chart,
                Aspose.Slides.Animation.EffectChartMajorGroupingType.BySeries,
                0,
                Aspose.Slides.Animation.EffectType.Fly,
                Aspose.Slides.Animation.EffectSubtype.Left,
                Aspose.Slides.Animation.EffectTriggerType.OnClick);

            presentation.Save("ChartAnimation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}