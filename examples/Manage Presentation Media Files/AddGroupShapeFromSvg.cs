using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define input SVG and output PPTX paths
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(dataDir))
            Directory.CreateDirectory(dataDir);
        string svgPath = Path.Combine(dataDir, "input.svg");
        string outPptxPath = Path.Combine(dataDir, "output.pptx");

        // Create a new presentation
        Presentation pres = new Presentation();

        // Read SVG content from file
        string svgContent = File.ReadAllText(svgPath);

        // Create an SVG image object
        ISvgImage svgImage = new SvgImage(svgContent);

        // Add the SVG image to the presentation's image collection
        IPPImage ppImage = pres.Images.AddImage(svgImage);

        // Add a picture frame that contains the SVG image
        IPictureFrame pictureFrame = pres.Slides[0].Shapes.AddPictureFrame(
            ShapeType.Rectangle,
            0,
            0,
            ppImage.Width,
            ppImage.Height,
            ppImage);

        // Retrieve the SVG image from the picture frame
        ISvgImage innerSvg = pictureFrame.PictureFormat.Picture.Image.SvgImage;

        // If the SVG image exists, convert it to a group shape
        if (innerSvg != null)
        {
            IGroupShape groupShape = pres.Slides[0].Shapes.AddGroupShape(
                innerSvg,
                pictureFrame.Frame.X,
                pictureFrame.Frame.Y,
                pictureFrame.Frame.Width,
                pictureFrame.Frame.Height);

            // Remove the original picture frame
            pres.Slides[0].Shapes.Remove(pictureFrame);
        }

        // Save the presentation
        pres.Save(outPptxPath, SaveFormat.Pptx);
    }
}