using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the local video file
        string videoPath = "sample.mp4";

        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add the video to the presentation's video collection
            IVideo video;
            using (FileStream videoStream = new FileStream(videoPath, FileMode.Open, FileAccess.Read))
            {
                video = pres.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
            }

            // Add a video frame to the slide and embed the video
            IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50f, 150f, 300f, 350f, video);

            // Set playback options (optional)
            videoFrame.PlayMode = VideoPlayModePreset.Auto;
            videoFrame.Volume = AudioVolumeMode.Loud;

            // Save the presentation
            pres.Save("VideoPresentation.pptx", SaveFormat.Pptx);
        }
    }
}