using System;


namespace R5T.Bath.Examples.Lib
{
    public class TestDisposable : ITestDisposable, IDisposable
    {
        public void A()
        {
            System.Console.WriteLine("A");
        }

        public void Dispose()
        {
            System.Console.WriteLine("Disposing here!~");
        }
    }
}
