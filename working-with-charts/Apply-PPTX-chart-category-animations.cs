using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;

namespace ChartAnimationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

                // Apply animation to each series (by series)
                // Animate series 0 with Fade effect
                slide.Timeline.MainSequence.AddEffect(chart, EffectChartMajorGroupingType.BySeries, 0, EffectType.Fade, EffectSubtype.None, EffectTriggerType.AfterPrevious);
                // Animate series 1 with Fly effect
                slide.Timeline.MainSequence.AddEffect(chart, EffectChartMajorGroupingType.BySeries, 1, EffectType.Fly, EffectSubtype.None, EffectTriggerType.AfterPrevious);

                // Apply animation to each category (by category)
                // Animate category 0 with Appear effect
                slide.Timeline.MainSequence.AddEffect(chart, EffectChartMajorGroupingType.ByCategory, 0, EffectType.Appear, EffectSubtype.None, EffectTriggerType.AfterPrevious);
                // Animate category 1 with Zoom effect
                slide.Timeline.MainSequence.AddEffect(chart, EffectChartMajorGroupingType.ByCategory, 1, EffectType.Zoom, EffectSubtype.None, EffectTriggerType.AfterPrevious);

                // Save the presentation
                presentation.Save("ChartAnimation_out.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}