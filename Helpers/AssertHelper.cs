using NUnit.Framework;

namespace SeleniumTests.Helpers
{
    internal class AssertHelper
    {
        /// <summary>
        /// Assert if URL contains expected value
        /// </summary>
        /// <param name="expectedValue">Expected value in URL</param>
        /// <param name="currentValue">Current URL</param>
        public static void AssertUrlContains(string expectedValue, string currentValue)
        {
            StringAssert.Contains(expectedValue, currentValue);
        }

        /// <summary>
        /// Assert if URL NOT contains expected value
        /// </summary>
        /// <param name="expectedValue">part of the URL that sholud not be present</param>
        /// <param name="actualValue">value of whole URL</param>
        public static void AssertUrlNotContains(string expectedValue, string actualValue)
        {
            StringAssert.DoesNotContain(expectedValue, actualValue);
        }
    }
}
