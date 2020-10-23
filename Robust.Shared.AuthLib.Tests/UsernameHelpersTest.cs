using NUnit.Framework;
using static Robust.Shared.AuthLib.UsernameHelpers;

namespace Robust.Shared.AuthLib.Tests
{
    [TestOf(typeof(UsernameHelpers))]
    [Parallelizable]
    public class UsernameHelpersTest
    {
        [Test, TestOf(nameof(IsNameValid))]
        [TestCase("", UsernameInvalidReason.Empty)]
        // ReSharper disable once StringLiteralTypo
        [TestCase("abcdefghijklmnopqrstuvwxyz123456789", UsernameInvalidReason.TooLong)]
        [TestCase("a", UsernameInvalidReason.TooShort)]
        [TestCase("++++", UsernameInvalidReason.InvalidCharacter)]
        [TestCase("foobar+", UsernameInvalidReason.InvalidCharacter)]
        [TestCase("fo+obar+", UsernameInvalidReason.InvalidCharacter)]
        [TestCase("fo@@@obar", UsernameInvalidReason.InvalidCharacter)]
        [TestCase("Clown123_", UsernameInvalidReason.Valid)]
        public void TestIsNameValid(string name, UsernameInvalidReason expectedReason)
        {
            Assert.That(IsNameValid(name, out var reason), Is.EqualTo(expectedReason == UsernameInvalidReason.Valid));
            Assert.That(reason, Is.EqualTo(expectedReason));
        }
    }
}