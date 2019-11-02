using System;

namespace IoT.WCD.BlockChain.Infrastructure.Utilities
{
    public static class StringUtil
    {
        public static string GetReverseData(this string src)
        {
            var charArray = src.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
