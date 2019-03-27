using System;
using System.Collections.Generic;
using System.Linq;

using SharedTypes;

namespace NullReferenceExceptionDemo
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var jitVersion = new JitVersionInfo().GetJitVersion();
            Console.WriteLine($"JIT Version: {jitVersion}.");

            var payload = new List<ImageInfo>
            {
                CreateImage(
                    "https://example.com/images/fullsize/1337.jpg",
                    "https://example.com/images/thumbnails/1337.jpg"),
                CreateImage(
                    "https://example.com/fullsize/42.jpg",
                    "https://example.com/thumbnails/42.jpg"),
                null,
                CreateImage("https://example.com/fullsize/42.jpg"),
            };

            var thumbnails = payload
                .SelectMany(s => s.Thumbnail)
                .Select(s => new ImageModel(s.Url.AbsoluteUri, s.Width, s.Height))
                .ToList();

            Console.WriteLine($"{thumbnails.Count}.");
        }

        private static ImageInfo CreateImage(string originalUrl, string thumbnailUrl = null)
        {
            var original = new ImageLink(new Uri(originalUrl, UriKind.Absolute), 960, 540);
            var thumbnail = string.IsNullOrEmpty(thumbnailUrl)
                ? default(Option<ImageLink>)
                : new ImageLink(new Uri(thumbnailUrl, UriKind.Absolute), 120, 60);

            return new ImageInfo(original, thumbnail);
        }
    }
}
