using System;
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

        // Path to the video file (replace with an actual file path)
        string videoPath = "sample.mp4";

        // Add a video frame to the slide
        Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 150, videoPath);

        // Set the video play mode and volume
        videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
        videoFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;

        // Save the presentation in PPTX format
        pres.Save("VideoFrame_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        pres.Dispose();
    }
}