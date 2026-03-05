using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Load an image from file
        FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read);
        Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);
        imageStream.Close();

        // Add a picture frame to the slide
        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            50f,   // X position
            50f,   // Y position
            300f,  // Width
            200f,  // Height
            image);

        // Set writable properties of the picture frame
        pictureFrame.AlternativeText = "Sample picture";
        pictureFrame.Rotation = 15f;
        pictureFrame.Width = 400f;
        pictureFrame.Height = 250f;

        // Iterate through shapes to find and modify picture frames
        for (int i = 0; i < slide.Shapes.Count; i++)
        {
            Aspose.Slides.IShape shape = slide.Shapes[i];
            if (shape is Aspose.Slides.IPictureFrame)
            {
                Aspose.Slides.IPictureFrame pf = (Aspose.Slides.IPictureFrame)shape;
                // Example modification: shift position
                pf.X = pf.X + 10f;
                pf.Y = pf.Y + 10f;
            }
        }

        // Save the presentation
        presentation.Save("ManagedPictureFrames.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}