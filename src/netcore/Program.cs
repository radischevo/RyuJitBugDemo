using System;

namespace NullReferenceExceptionCoreDemo
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Container container = null;
            Console.WriteLine($"{container.Item}.");
        }
    }

    public struct Option
    {
        private object _foo;
        private int _bar;
    }

    public class Container
    {
        public Container(Option item)
        {
            Item = item;
        }

        public Option Item { get; }
    }
}
