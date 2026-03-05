using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ZoomFramesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add two empty slides based on the layout of the first slide
            Aspose.Slides.ISlide slide2 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            Aspose.Slides.ISlide slide3 = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

            // Set background for slide2
            slide2.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide2.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

            // Set background for slide3
            slide3.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            slide3.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

            // Add first zoom frame (without custom image)
            float x1 = 50f;
            float y1 = 50f;
            float width1 = 100f;
            float height1 = 100f;
            Aspose.Slides.IZoomFrame zoomFrame1 = presentation.Slides[0].Shapes.AddZoomFrame(x1, y1, width1, height1, slide2);
            zoomFrame1.ShowBackground = true; // Show background of the target slide

            // Load custom image for the second zoom frame
            string logoFileName = "logo.png";
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), logoFileName);
            Aspose.Slides.IPPImage customImage = presentation.Images.AddImage(Aspose.Slides.Images.FromFile(imagePath));

            // Add second zoom frame with custom image
            float x2 = 200f;
            float y2 = 50f;
            float width2 = 100f;
            float height2 = 100f;
            Aspose.Slides.IZoomFrame zoomFrame2 = presentation.Slides[0].Shapes.AddZoomFrame(x2, y2, width2, height2, slide3, customImage);
            zoomFrame2.LineFormat.Width = 5f;
            zoomFrame2.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
            zoomFrame2.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.DashDot;

            // Save the presentation
            string outputFile = "ZoomFramesExample.pptx";
            presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}