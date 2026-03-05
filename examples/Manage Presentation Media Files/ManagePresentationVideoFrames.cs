using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a video from a file stream
        using (FileStream videoStream = new FileStream("sample.mp4", FileMode.Open, FileAccess.Read))
        {
            Aspose.Slides.IVideo video = presentation.Videos.AddVideo(videoStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);

            // Add a video frame to the slide and set playback options
            Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50f, 150f, 300f, 350f, video);
            videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
            videoFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;
        }

        // Save the presentation
        presentation.Save("VideoDemo.pptx", SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}