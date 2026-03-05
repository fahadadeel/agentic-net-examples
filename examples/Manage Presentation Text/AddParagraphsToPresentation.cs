using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MultipleParagraphsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle shape that will contain the text
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 150);

                // Add a text frame to the shape
                Aspose.Slides.ITextFrame textFrame = shape.AddTextFrame(string.Empty);
                // Clear any default paragraph
                textFrame.Paragraphs.Clear();

                // ----- First Paragraph -----
                Aspose.Slides.Paragraph paragraph1 = new Aspose.Slides.Paragraph();

                // First portion of the first paragraph
                Aspose.Slides.IPortion portion1a = new Aspose.Slides.Portion();
                portion1a.Text = "Hello ";
                paragraph1.Portions.Add(portion1a);

                // Second portion of the first paragraph
                Aspose.Slides.IPortion portion1b = new Aspose.Slides.Portion();
                portion1b.Text = "World!";
                paragraph1.Portions.Add(portion1b);

                // Add the first paragraph to the text frame
                textFrame.Paragraphs.Add(paragraph1);

                // ----- Second Paragraph -----
                Aspose.Slides.Paragraph paragraph2 = new Aspose.Slides.Paragraph();

                // First portion of the second paragraph
                Aspose.Slides.IPortion portion2a = new Aspose.Slides.Portion();
                portion2a.Text = "This is ";
                paragraph2.Portions.Add(portion2a);

                // Second portion of the second paragraph
                Aspose.Slides.IPortion portion2b = new Aspose.Slides.Portion();
                portion2b.Text = "a second paragraph.";
                paragraph2.Portions.Add(portion2b);

                // Add the second paragraph to the text frame
                textFrame.Paragraphs.Add(paragraph2);

                // Save the presentation
                presentation.Save("MultipleParagraphs.pptx", SaveFormat.Pptx);
            }
        }
    }
}