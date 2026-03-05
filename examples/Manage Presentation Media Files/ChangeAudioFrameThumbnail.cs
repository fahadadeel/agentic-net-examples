using System;
using System.IO;
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

        // Load the audio file stream
        System.IO.FileStream audioStream = new System.IO.FileStream("sample2.mp3", System.IO.FileMode.Open, System.IO.FileAccess.Read);

        // Add an audio frame to the slide
        Aspose.Slides.IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(150f, 100f, 50f, 50f, audioStream);
        audioStream.Dispose();

        // Load the image stream for the thumbnail
        System.IO.FileStream imageStream = new System.IO.FileStream("eagle.jpeg", System.IO.FileMode.Open, System.IO.FileAccess.Read);

        // Add the image to the presentation's image collection
        Aspose.Slides.IPPImage audioImage = pres.Images.AddImage(imageStream);
        imageStream.Dispose();

        // Set the thumbnail image for the audio frame
        audioFrame.PictureFormat.Picture.Image = audioImage;

        // Save the presentation in PPTX format
        pres.Save("example_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        pres.Dispose();
    }
}