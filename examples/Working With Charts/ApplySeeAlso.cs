using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace ApplySeeAlso
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide (created by default)
            Aspose.Slides.ISlide firstSlide = presentation.Slides[0];

            // Add a second empty slide
            Aspose.Slides.ISlide secondSlide = presentation.Slides.AddEmptySlide(presentation.LayoutSlides[0]);

            // Add a rectangle shape with text on the first slide
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)firstSlide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 50);
            autoShape.AddTextFrame("See also");

            // Access the first portion of the text
            Aspose.Slides.IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];

            // Set an internal hyperlink that points to the second slide
            Aspose.Slides.IHyperlinkManager hyperlinkManager = portion.PortionFormat.HyperlinkManager;
            hyperlinkManager.SetInternalHyperlinkClick(secondSlide);

            // Save the presentation
            presentation.Save("SeeAlso.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}