using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a rectangle auto shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 150, 300, 150);

        // Add a text frame to the shape
        shape.AddTextFrame(" ");

        // Access the text frame
        Aspose.Slides.ITextFrame tf = shape.TextFrame;

        // Get the default paragraph
        Aspose.Slides.IParagraph para0 = tf.Paragraphs[0];

        // Create and add two portions to the first paragraph
        Aspose.Slides.IPortion port01 = new Aspose.Slides.Portion();
        Aspose.Slides.IPortion port02 = new Aspose.Slides.Portion();
        para0.Portions.Add(port01);
        para0.Portions.Add(port02);

        // Create and add the second paragraph with three portions
        Aspose.Slides.IParagraph para1 = new Aspose.Slides.Paragraph();
        tf.Paragraphs.Add(para1);
        Aspose.Slides.IPortion port10 = new Aspose.Slides.Portion();
        Aspose.Slides.IPortion port11 = new Aspose.Slides.Portion();
        Aspose.Slides.IPortion port12 = new Aspose.Slides.Portion();
        para1.Portions.Add(port10);
        para1.Portions.Add(port11);
        para1.Portions.Add(port12);

        // Create and add the third paragraph with three portions
        Aspose.Slides.IParagraph para2 = new Aspose.Slides.Paragraph();
        tf.Paragraphs.Add(para2);
        Aspose.Slides.IPortion port20 = new Aspose.Slides.Portion();
        Aspose.Slides.IPortion port21 = new Aspose.Slides.Portion();
        Aspose.Slides.IPortion port22 = new Aspose.Slides.Portion();
        para2.Portions.Add(port20);
        para2.Portions.Add(port21);
        para2.Portions.Add(port22);

        // Populate portions with text and apply formatting
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Aspose.Slides.IPortion portion = tf.Paragraphs[i].Portions[j];
                portion.Text = "Portion" + i + "_" + j;

                if (j == 0)
                {
                    portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    portion.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Red;
                    portion.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
                    portion.PortionFormat.FontHeight = 15;
                }
                else if (j == 1)
                {
                    portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    portion.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
                    portion.PortionFormat.FontItalic = Aspose.Slides.NullableBool.True;
                    portion.PortionFormat.FontHeight = 18;
                }
                else // j == 2
                {
                    portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    portion.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Green;
                    portion.PortionFormat.FontHeight = 20;
                }
            }
        }

        // Save the presentation
        string outPath = "MultipleParagraphs.pptx";
        pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}