using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation and ensure it is disposed properly
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to the slide
            slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

            // Set the slide background to a solid light blue color
            slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide.Background.FillFormat.SolidFillColor.Color = Color.LightBlue;

            // Define a custom slide size (960x540) without scaling content
            presentation.SlideSize.SetSize(960, 540, Aspose.Slides.SlideSizeScaleType.DoNotScale);

            // Configure the slide show to be presented by a speaker
            presentation.SlideShowSettings.SlideShowType = new Aspose.Slides.PresentedBySpeaker();

            // Save the presentation to a PPTX file
            presentation.Save("ProprietaryGraphics.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}