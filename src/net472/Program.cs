using System;

using SharedTypes;

namespace NullReferenceExceptionDemo
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var jitVersion = new JitVersionInfo().GetJitVersion();
            Console.WriteLine($"JIT Version: {jitVersion}.");

            Container container = null;
            Console.WriteLine($"{container.Item}.");
        }
    }
}
