using System;
using System.Collections.Generic;
using System.Linq;

using SharedTypes;

namespace NullReferenceExceptionCoreDemo
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var jitVersion = new JitVersionInfo().GetJitVersion();
            Console.WriteLine($"JIT Version: {jitVersion}.");

            var payload = new List<ImageInfo>
            {
                ImageInfo.Create("https://example.com/images/thumbnails/1337.jpg", 240, 90),
                ImageInfo.Create("https://example.com/thumbnails/42.jpg", 100, 60),
                null,
                ImageInfo.Create(null, 0, 0),
            };

            var thumbnails = payload
                .SelectMany(s => s.Thumbnail)
                .Select(s => new ImageModel(s.Url.AbsoluteUri, s.Width, s.Height))
                .ToList();

            Console.WriteLine($"{thumbnails.Count}.");
        }
    }
}
