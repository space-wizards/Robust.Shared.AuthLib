using System.Text.RegularExpressions;

namespace Robust.Shared.AuthLib
{
    public static class UsernameHelpers
    {
        public static readonly int NameLengthMax = 32;
        public static readonly int NameLengthMin = 3;

        private static readonly Regex ValidNameRegex = new Regex(@"^[a-z0-9_]+$", RegexOptions.IgnoreCase);

        /// <summary>
        /// Checks whether a user name is valid.
        /// </summary>
        /// <remarks>
        /// If this is false, feel free to kick the person requesting it. Loudly.
        /// </remarks>
        /// <param name="name">The name to check.</param>
        /// <param name="reason">The reason why the name is invalid.</param>
        /// <returns>True if the name is acceptable, false otherwise.</returns>
        public static bool IsNameValid(string name, out UsernameInvalidReason reason)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                reason = UsernameInvalidReason.Empty;
                return false;
            }

            if (name.Length < NameLengthMin)
            {
                reason = UsernameInvalidReason.TooShort;
                return false;
            }

            if (name.Length >= NameLengthMax)
            {
                reason = UsernameInvalidReason.TooLong;
                return false;
            }

            if (!ValidNameRegex.IsMatch(name))
            {
                reason = UsernameInvalidReason.InvalidCharacter;
                return false;
            }

            reason = UsernameInvalidReason.Valid;
            return true;
        }

        /// <summary>
        ///     Reasons for why a username is invalid.
        /// </summary>
        public enum UsernameInvalidReason
        {
            /// <summary>
            ///     The username is not actually invalid.
            /// </summary>
            Valid,

            /// <summary>
            ///     The username is empty.
            /// </summary>
            Empty,

            /// <summary>
            ///     The username is too long (<see cref="UsernameHelpers.NameLengthMin"/>).
            /// </summary>
            TooShort,

            /// <summary>
            ///     The username is too long (<see cref="UsernameHelpers.NameLengthMax"/>).
            /// </summary>
            TooLong,

            /// <summary>
            ///     Username contains an invalid character.
            /// </summary>
            InvalidCharacter
        }
    }
}