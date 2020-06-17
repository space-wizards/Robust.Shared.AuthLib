using NUnit.Framework;

namespace Robust.Shared.AuthLib.Tests
{
    [TestOf(typeof(UsernameHelpers))]
    [Parallelizable]
    public class UsernameHelpersTest
    {
        [Test]
        public void TestEmpty()
        {
            Assert.False(UsernameHelpers.IsNameValid("", out var reason));
            Assert.AreEqual(reason, UsernameHelpers.UsernameInvalidReason.Empty);
        }

        [Test]
        public void TestTooLong()
        {
            // ReSharper disable once StringLiteralTypo
            Assert.False(UsernameHelpers.IsNameValid("abcdefghijklmnopqrstuvwxyz123456789", out var reason));
            Assert.AreEqual(reason, UsernameHelpers.UsernameInvalidReason.TooLong);
        }

        [Test]
        public void TestInvalidChar()
        {
            Assert.False(UsernameHelpers.IsNameValid("+", out var reason));
            Assert.AreEqual(reason, UsernameHelpers.UsernameInvalidReason.InvalidCharacter);
        }

        [Test]
        public void TestRight()
        {
            Assert.True(UsernameHelpers.IsNameValid("Clown123_", out var reason));
            Assert.AreEqual(reason, UsernameHelpers.UsernameInvalidReason.Valid);
        }
    }
}