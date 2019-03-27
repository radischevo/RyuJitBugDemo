using System;

namespace SharedTypes
{
    public sealed class ImageInfo
    {
        public ImageInfo(ImageLink original, Option<ImageLink> thumbnail)
        {
            Original = original ?? throw new ArgumentNullException(nameof(original));
            Thumbnail = thumbnail;
        }

        public ImageLink Original { get; }

        public Option<ImageLink> Thumbnail { get; }
    }
}
