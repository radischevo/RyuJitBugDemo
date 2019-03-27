using System;

namespace SharedTypes
{
    public sealed class ImageLink
    {
        public ImageLink(Uri url, int width, int height)
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));
            Width = width;
            Height = height;
        }

        public Uri Url { get; }

        public int Width { get; }

        public int Height { get; }
    }
}
