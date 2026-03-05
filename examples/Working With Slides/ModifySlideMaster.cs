using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Modify the first master slide's background to Forest Green
        presentation.Masters[0].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
        presentation.Masters[0].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        presentation.Masters[0].Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.ForestGreen;

        // Enable and set footer, date/time, and slide number placeholders on the master and its child layouts
        Aspose.Slides.IMasterSlideHeaderFooterManager headerFooterManager = presentation.Masters[0].HeaderFooterManager;
        headerFooterManager.SetFooterAndChildFootersVisibility(true);
        headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
        headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
        headerFooterManager.SetFooterAndChildFootersText("Sample Footer");
        headerFooterManager.SetDateTimeAndChildDateTimesText("01/01/2024");

        // Save the modified presentation
        presentation.Save("ModifiedMaster.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}