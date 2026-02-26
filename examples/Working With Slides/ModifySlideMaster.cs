using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace SlideMasterModification
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load an existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Get the first master slide
            Aspose.Slides.IMasterSlide masterSlide = presentation.Masters[0];

            // Set the background of the master slide to a solid forest green color
            masterSlide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            masterSlide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            masterSlide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.ForestGreen;

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}