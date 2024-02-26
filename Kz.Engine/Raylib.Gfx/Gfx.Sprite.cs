using Raylib_cs;

namespace Kz.Engine.Raylib
{
    public static partial class Gfx
    {
        /// <summary>
        /// Returns a list of pixels on the edge of a transparent sprite taken from a spritesheet
        /// </summary>        
        public static List<(int X, int Y)> GetSpriteEdges(Texture2D spritesheet, int frameIndex, int spriteIndex, int width, int height)
        {
            // get the part of the spritesheet we care about
            var wholeImage = Raylib_cs.Raylib.LoadImageFromTexture(spritesheet);
            var section = new Rectangle(frameIndex * width, spriteIndex * height, width, height);
            var sectionImage = Raylib_cs.Raylib.ImageFromImage(wholeImage, section);

            return GetSpriteEdges(sectionImage);
        }

        /// <summary>
        /// Returns a list of pixels on the edge of a transparent sprite
        /// </summary>        
        public static List<(int X, int Y)> GetSpriteEdges(Image image)
        {
            // load the color data
            var pixels = GetPixelData(image);

            // Define what we consider as 'transparent'
            var transparent = new Color(0, 0, 0, 0);  // Assuming fully transparent

            // find the edges
            var edgePixels = new List<(int, int)>();
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    // Get the current pixel
                    var currentPixel = pixels[y * image.Width + x];

                    // Skip transparent pixels
                    if (currentPixel.A == transparent.A) continue;

                    // Check neighboring pixels
                    var isEdge = false;
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        for (int dx = -1; dx <= 1; dx++)
                        {
                            // Skip the center pixel
                            if (dx == 0 && dy == 0) continue;

                            var nx = x + dx;
                            var ny = y + dy;

                            // Check boundaries
                            if (nx >= 0 && nx < image.Width && ny >= 0 && ny < image.Height)
                            {
                                var neighborPixel = pixels[ny * image.Width + nx];
                                if (neighborPixel.A == transparent.A)
                                {
                                    isEdge = true;
                                    break;
                                }
                            }
                        }
                        if (isEdge) break;  // No need to check other neighbors if already found an edge
                    }

                    if (isEdge)
                    {
                        edgePixels.Add((x, y));
                    }
                }
            }
            
            return edgePixels;
        }

        public static Color[] GetPixelData(Image image)
        {
            Color[] pixels = [];
            
            unsafe
            {
                var pixelsPointer = Raylib_cs.Raylib.LoadImageColors(image);
                pixels = new Color[image.Width * image.Height];

                for (int i = 0; i < image.Width * image.Height; i++)
                {
                    pixels[i] = pixelsPointer[i]; // Copy each element
                }

                Raylib_cs.Raylib.UnloadImageColors(pixelsPointer);
            }

            return pixels;
        }
    }
}
