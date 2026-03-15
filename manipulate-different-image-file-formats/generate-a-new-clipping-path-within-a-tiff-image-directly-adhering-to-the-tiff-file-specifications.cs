using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.FileFormats.Tiff.PathResources;

class Program
{
    static void Main()
    {
        // Define TIFF creation options (default format)
        var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);

        // Create a new frame with desired dimensions
        var frame = new TiffFrame(tiffOptions, 800, 600);

        // Initialize a TiffImage with the created frame
        using (var tiffImage = new TiffImage(frame))
        {
            // Build a clipping path (example: a simple rectangle)
            var clippingPath = new PathResource
            {
                BlockId = 2000,                     // Photoshop block identifier for paths
                Name = "My Clipping Path",          // Path name
                Records = CreateRecords(          // Path records generated from coordinates
                    0.2f, 0.2f,   // top‑left
                    0.8f, 0.2f,   // top‑right
                    0.8f, 0.8f,   // bottom‑right
                    0.2f, 0.8f)   // bottom‑left
            };

            // Assign the path to the active frame
            tiffImage.ActiveFrame.PathResources = new List<PathResource> { clippingPath };

            // Save the TIFF with the clipping path embedded
            tiffImage.Save("ImageWithClippingPath.tiff");
        }
    }

    // Creates a full list of VectorPathRecord objects, inserting the required LengthRecord at the start
    private static List<VectorPathRecord> CreateRecords(params float[] coordinates)
    {
        // Generate Bezier knot records from the supplied coordinates
        var records = CreateBezierRecords(coordinates);

        // Insert the LengthRecord (required by Photoshop specification) as the first record
        records.Insert(0, new LengthRecord
        {
            IsOpen = false,                     // Closed path
            RecordCount = (ushort)records.Count // Total number of records in the path
        });

        return records;
    }

    // Converts coordinate pairs into BezierKnotRecord objects
    private static List<VectorPathRecord> CreateBezierRecords(float[] coordinates)
    {
        var points = CoordinatesToPoints(coordinates);
        var bezierRecords = new List<VectorPathRecord>();
        foreach (var pt in points)
        {
            bezierRecords.Add(CreateBezierRecord(pt));
        }
        return bezierRecords;
    }

    // Enumerates PointF structures from a flat float array (x, y, x, y, …)
    private static IEnumerable<PointF> CoordinatesToPoints(float[] coordinates)
    {
        for (int i = 0; i < coordinates.Length; i += 2)
        {
            yield return new PointF(coordinates[i], coordinates[i + 1]);
        }
    }

    // Creates a single BezierKnotRecord where all three control points are the same (straight line segment)
    private static VectorPathRecord CreateBezierRecord(PointF point)
    {
        return new BezierKnotRecord { PathPoints = new[] { point, point, point } };
    }
}