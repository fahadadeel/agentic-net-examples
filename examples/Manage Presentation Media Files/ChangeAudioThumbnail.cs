using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManageAudioThumbnail
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load an existing presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Access the first slide (adjust index as needed)
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Find the first audio frame on the slide
            Aspose.Slides.IAudioFrame audioFrame = null;
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                audioFrame = shape as Aspose.Slides.IAudioFrame;
                if (audioFrame != null)
                {
                    break;
                }
            }

            if (audioFrame != null)
            {
                // Load the new thumbnail image from file
                FileStream imageStream = new FileStream("newThumbnail.jpg", FileMode.Open, FileAccess.Read);
                Aspose.Slides.IPPImage newImage = presentation.Images.AddImage(imageStream);
                imageStream.Dispose();

                // Assign the new image as the audio frame's picture (thumbnail)
                audioFrame.PictureFormat.Picture.Image = newImage;
            }

            // Save the modified presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}