using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Access the first slide
        ISlide slide = presentation.Slides[0];

        // Add a clustered column chart to the slide
        IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 500f, 400f);

        // Add animation effect for chart categories (by category)
        IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(
            chart,
            EffectChartMajorGroupingType.ByCategory,
            0,
            EffectType.Appear,
            EffectSubtype.None,
            EffectTriggerType.OnClick);

        // Save the presentation
        presentation.Save("ChartCategoryAnimation.pptx", SaveFormat.Pptx);
    }
}