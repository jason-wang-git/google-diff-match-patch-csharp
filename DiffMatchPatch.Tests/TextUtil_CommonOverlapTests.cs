using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiffMatchPatch.Tests
{
    [TestClass]
    public class TextUtilTests
    {
        [TestMethod]
        public void CommonOverlapEmptyStringNoOverlap()
        {
            // Detect any suffix/prefix overlap.
            // Null case.
            Assert.AreEqual(0, TextUtil.CommonOverlap("", "abcd"));
        }
        [TestMethod]
        public void CommonOverlapFirstIsPrefixOfSecondFullOverlap()
        {

            // Whole case.
            Assert.AreEqual(3, TextUtil.CommonOverlap("abc", "abcd"));
        }
        [TestMethod]
        public void CommonOverlapDisjunctStringsNoOverlap()
        {

            // No overlap.
            Assert.AreEqual(0, TextUtil.CommonOverlap("123456", "abcd"));
        }
        [TestMethod]
        public void CommonOverlapFirstEndsWithStartOfSecondOverlap()
        {

            // Overlap.
            Assert.AreEqual(3, TextUtil.CommonOverlap("123456xxx", "xxxabcd"));
        }
        [TestMethod]
        public void CommonOverlapUnicodeLigaturesAndComponentLettersNoOverlap()
        {
            // Unicode.
            // Some overly clever languages (C#) may treat ligatures as equal to their
            // component letters.  E.g. U+FB01 == 'fi'
            Assert.AreEqual(0, TextUtil.CommonOverlap("fi", "\ufb01i"));
        }

        [TestMethod]
        public void CommonPrefixDisjunctStringsNoCommonPrefix()
        {
            // Detect any common suffix.
            // Null case.
            Assert.AreEqual(0, TextUtil.CommonPrefix("abc", "xyz"));
        }

        [TestMethod]
        public void CommonPrefixBothStringsStartWithSameCommonPrefixIsDetected()
        {
            // Non-null case.
            Assert.AreEqual(4, TextUtil.CommonPrefix("1234abcdef", "1234xyz"));
        }
        [TestMethod]
        public void CommonPrefixBothStringsStartWithSameCommonPrefixIsDetected2()
        {
            // Non-null case.
            Assert.AreEqual(4, TextUtil.CommonPrefix("abc1234abcdef", "efgh1234xyz", 3, 4));
        }

        [TestMethod]
        public void CommonPrefixFirstStringIsSubstringOfSecondCommonPrefixIsDetected()
        {

            // Whole case.
            Assert.AreEqual(4, TextUtil.CommonPrefix("1234", "1234xyz"));
        }

        [TestMethod]
        public void CommonSuffixDisjunctStringsNoCommonSuffix()
        {
            // Detect any common suffix.
            // Null case.
            Assert.AreEqual(0, TextUtil.CommonSuffix("abc", "xyz"));
        }

        [TestMethod]
        public void CommonSuffixBothStringsEndWithSameCommonSuffixIsDetected()
        {
            // Non-null case.
            Assert.AreEqual(4, TextUtil.CommonSuffix("abcdef1234", "xyz1234"));
        }
        [TestMethod]
        public void CommonSuffixBothStringsEndWithSameCommonSuffixIsDetected2()
        {
            // Non-null case.
            Assert.AreEqual(4, TextUtil.CommonSuffix("abcdef1234abcd", "xyz1234efgh", 10, 7));
        }

        [TestMethod]
        public void CommonSuffixFirstStringIsSubstringOfSecondCommonSuffixIsDetected()
        {
            // Whole case.
            Assert.AreEqual(4, TextUtil.CommonSuffix("1234", "xyz1234"));
        }
    }
}