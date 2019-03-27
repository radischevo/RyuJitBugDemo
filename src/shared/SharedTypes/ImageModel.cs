namespace SharedTypes
{
    public struct ImageModel
    {
        public readonly string Url;

        public readonly int Width;

        public readonly int Height;

        public ImageModel(string url, int width, int height)
        {
            Url = url;
            Width = width;
            Height = height;
        }
    }
}
