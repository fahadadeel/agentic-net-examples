using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add video to the presentation
            using (FileStream videoStream = new FileStream("sample.mp4", FileMode.Open, FileAccess.Read))
            {
                Aspose.Slides.IVideo video = pres.Videos.AddVideo(videoStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
                // Add video frame to the slide
                Aspose.Slides.IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(50, 150, 300, 350, video);
                // Set playback options
                videoFrame.PlayMode = Aspose.Slides.VideoPlayModePreset.Auto;
                videoFrame.Volume = Aspose.Slides.AudioVolumeMode.Loud;
            }

            // Save the presentation
            pres.Save("EmbeddedVideo.pptx", SaveFormat.Pptx);
        }
    }
}