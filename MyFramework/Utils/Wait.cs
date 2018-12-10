using System;
using System.Threading;

namespace ShopByProject.Utils
{
    public class Wait
    {
        public bool ExecuteUntilTrue(Func<bool> expression, int timesToRepeat = 3)
        {
            for (var i = 0; i < timesToRepeat; i++)
            {
                try
                {
                    if (expression.Invoke())
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {
                    Console.Write(e);
                    Thread.Sleep(TimeSpan.FromSeconds(TestSettings.ImplicitTimeout));
                }
            }

            Console.WriteLine($"Tried to click {timesToRepeat} times" );
            return false;
        }
    }
}
