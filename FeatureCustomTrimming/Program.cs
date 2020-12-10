using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace FeatureCustomTrimming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"DebuggerSupport:{Switches.IsDebuggerSupported}");
            Console.WriteLine($"EnableUnsafeUTF7Encoding:{Switches.EnableUnsafeUTF7Encoding}");
            Console.WriteLine($"EnableUnsafeBinaryFormatterSerialization:{Switches.EnableUnsafeBinaryFormatterSerialization}");
            Console.WriteLine($"EventSourceSupport:{Switches.IsEventTraceSupported}");
            Console.WriteLine($"InvariantGlobalization:{Switches.InvariantGlobalization}");
            Console.WriteLine($"UseSystemResourceKeys:{Switches.UseSystemResourceKeys} (true is disabled)");
            Console.WriteLine($"HttpActivityPropagationSupport:{Switches.IsHttpActivityPropagationEnabled}");
            Console.WriteLine($"StartupHookSupport:{Switches.IsStartupHookProviderSupported}");

            Console.WriteLine();

            Exception();

            Console.WriteLine();
            Console.WriteLine();
            var mylib = new FeaturePoweredLibrary.MyLibrary();
            mylib.PrintHello();

            Console.ReadKey();
        }



        public static void Exception()
        {
            try
            {
                object o = "some text";
                int x = (int)o;

            }
            catch (Exception err)
            {
                Console.WriteLine($"Exception message: {err.Message}");
            }

            try
            {
                string a = null;
                var x = a.Length;
            }
            catch (Exception err)
            {
                Console.WriteLine($"Exception message: {err.Message}");
            }
        }


    }


    public class Switches
    {
        private static bool _isDebuggerSupported;
        public static bool IsDebuggerSupported
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ReadValue("System.Diagnostics.Debugger.IsSupported", out _isDebuggerSupported);
        }

        private static bool _enableUnsafeUTF7Encoding;
        public static bool EnableUnsafeUTF7Encoding
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ReadValue("System.Text.Encoding.EnableUnsafeUTF7Encoding", out _enableUnsafeUTF7Encoding);
        }

        private static bool _enableUnsafeBinaryFormatterSerialization;
        public static bool EnableUnsafeBinaryFormatterSerialization
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ReadValue("System.Runtime.Serialization.EnableUnsafeBinaryFormatterSerialization", out _enableUnsafeBinaryFormatterSerialization);
        }

        private static bool _isEventTraceSupported;
        public static bool IsEventTraceSupported
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ReadValue("System.Diagnostics.Tracing.EventSource.IsSupported", out _isEventTraceSupported);
        }

        private static bool _invariantGlobalization;
        public static bool InvariantGlobalization
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ReadValue("System.Globalization.Invariant", out _invariantGlobalization);
        }

        private static bool _useSystemResourceKeys;
        public static bool UseSystemResourceKeys
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ReadValue("System.Resources.UseSystemResourceKeys", out _useSystemResourceKeys);
        }

        private static bool _isHttpActivityPropagationEnabled;
        public static bool IsHttpActivityPropagationEnabled
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ReadValue("System.Net.Http.EnableActivityPropagation", out _isHttpActivityPropagationEnabled);
        }

        private static bool _isStartupHookProviderSupported;
        public static bool IsStartupHookProviderSupported
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ReadValue("System.StartupHookProvider.IsSupported", out _isStartupHookProviderSupported);
        }

        private static bool ReadValue(string setting, out bool value)
        {
            AppContext.TryGetSwitch(setting, out value);
            return value;
        }
    }

}
