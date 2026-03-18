using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;

namespace AddPptxCategoryElementCustomAnimation
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Define data directory and output file name
                string dataDir = "Data/";
                string outputChartFile = "AnimatedChart.pptx";

                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Access the first slide
                    Slide slide = (Slide)presentation.Slides[0];

                    // Add a clustered column chart to the slide
                    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

                    // Add a fade effect to the whole chart
                    slide.Timeline.MainSequence.AddEffect(
                        chart,
                        EffectType.Fade,
                        EffectSubtype.None,
                        EffectTriggerType.AfterPrevious);

                    // Get the main sequence as a concrete Sequence object
                    Sequence seq = (Sequence)slide.Timeline.MainSequence;

                    // Determine the number of categories and series in the chart
                    int categoryCount = chart.ChartData.Categories.Count;
                    int seriesCount = chart.ChartData.Series.Count;

                    // Add appear effects for each element in each category
                    for (int cat = 0; cat < categoryCount; cat++)
                    {
                        for (int ser = 0; ser < seriesCount; ser++)
                        {
                            seq.AddEffect(
                                chart,
                                EffectChartMinorGroupingType.ByElementInCategory,
                                ser,
                                cat,
                                EffectType.Appear,
                                EffectSubtype.None,
                                EffectTriggerType.AfterPrevious);
                        }
                    }

                    // Save the presentation
                    presentation.Save(dataDir + outputChartFile, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}