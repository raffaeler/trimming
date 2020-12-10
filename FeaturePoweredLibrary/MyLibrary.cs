using System;

namespace FeaturePoweredLibrary
{
    public class MyLibrary
    {
        public void PrintHello()
        {
            if (MySwitches.IsMyFeatureEnabled)
            {
                Console.WriteLine("My.Feature is enabled");
            }
            else
            {
                Console.WriteLine("My.Feature is disabled");
            }            
        }
    }

    public static class MySwitches
    {
        private static bool _myFeatureEnabled;
        public static bool IsMyFeatureEnabled
        {
            get
            {
                if (!AppContext.TryGetSwitch("My.Feature", out _myFeatureEnabled))
                {
                    // when not found, enable the feature!
                    _myFeatureEnabled = true;
                }

                return _myFeatureEnabled;
            }
        }
    }


}
