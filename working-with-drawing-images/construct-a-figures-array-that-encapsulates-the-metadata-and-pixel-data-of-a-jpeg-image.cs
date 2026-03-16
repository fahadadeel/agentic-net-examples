using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Exif;
using Aspose.Imaging.FileFormats.Jpeg;

// Define a container that holds both metadata and raw image bytes.
public class Figure
{
    // EXIF metadata container.
    public JpegExifData Exif { get; set; }

    // JFIF segment data.
    public JFIFData Jfif { get; set; }

    // Raw JPEG byte array (includes pixel data and embedded metadata).
    public byte[] ImageBytes { get; set; }
}

public class Program
{
    public static void Main()
    {
        // Path to the source JPEG file.
        string jpegPath = @"C:\temp\sample.jpg";

        // Collection that will store the resulting Figure objects.
        List<Figure> figures = new List<Figure>();

        // Load the JPEG image using the constructor that accepts a file path.
        using (JpegImage jpegImage = new JpegImage(jpegPath))
        {
            // Retrieve EXIF metadata.
            JpegExifData exifData = jpegImage.ExifData;

            // Retrieve JFIF segment data.
            JFIFData jfifData = jpegImage.Jfif;

            // Save the image into a memory stream to obtain the raw byte representation.
            byte[] imageBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                // The Save method follows the lifecycle rule; it writes the image to the stream.
                jpegImage.Save(ms);
                imageBytes = ms.ToArray();
            }

            // Populate a Figure instance with the gathered information.
            Figure figure = new Figure
            {
                Exif = exifData,
                Jfif = jfifData,
                ImageBytes = imageBytes
            };

            // Add the Figure to the collection.
            figures.Add(figure);
        }

        // Convert the list to an array as required.
        Figure[] figuresArray = figures.ToArray();

        // Example usage: output the size of the first figure's byte array.
        if (figuresArray.Length > 0)
        {
            Console.WriteLine($"First figure byte size: {figuresArray[0].ImageBytes.Length}");
        }
    }
}