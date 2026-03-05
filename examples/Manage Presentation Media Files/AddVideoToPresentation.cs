using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Path to the local video file
        string videoPath = "sample.mp4";

        // Add a video frame to the slide, embedding the video
        Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 350, videoPath);

        // Set playback mode (optional)
        videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;

        // Save the presentation
        presentation.Save("VideoPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}