namespace DNX.Helpers.CommandLine.Templating.DotLiquid
{
    /// <summary>
    /// Class TextPadder.
    /// </summary>
    public static class TextPadder
    {
        // ReSharper disable InconsistentNaming
        /// <summary>
        /// Right pads the specified text to the required length
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="length">The length.</param>
        /// <returns>System.String.</returns>
        public static string padright(string input, int length)
        {
            return (input ?? string.Empty).PadRight(length);
        }

        /// <summary>
        /// Left pads the specified text to the required length
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="length">The length.</param>
        /// <returns>System.String.</returns>
        public static string padleft(string input, int length)
        {
            return (input ?? string.Empty).PadLeft(length);
        }

        /// <summary>
        /// Left and Right pads the specified text to centre it within the required length
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="length">The length.</param>
        /// <returns>System.String.</returns>
        public static string padcentre(string input, int length)
        {
            return (input ?? string.Empty).PadLeft(length / 2).PadRight(length);
        }
    }
}
