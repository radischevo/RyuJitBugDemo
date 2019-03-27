using System;

namespace SharedTypes
{
    public sealed class ImageInfo
    {
        public ImageInfo(Option<ImageLink> thumbnail)
        {
            Thumbnail = thumbnail;
        }

        public Option<ImageLink> Thumbnail { get; }

        public static ImageInfo Create(string thumbnailUrl, int width, int height)
        {
            var thumbnail = string.IsNullOrEmpty(thumbnailUrl)
                ? default(Option<ImageLink>)
                : new ImageLink(new Uri(thumbnailUrl, UriKind.Absolute), 120, 60);

            return new ImageInfo(thumbnail);
        }
    }
}
