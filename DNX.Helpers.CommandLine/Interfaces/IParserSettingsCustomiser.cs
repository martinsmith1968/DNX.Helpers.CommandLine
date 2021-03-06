﻿using CommandLine;

namespace DNX.Helpers.CommandLine.Interfaces
{
    /// <summary>
    /// Interface IParserSettingsConfigurator
    /// </summary>
    public interface IParserSettingsCustomiser
    {
        /// <summary>
        /// Configures the Parser Settings
        /// </summary>
        /// <param name="settings">The settings.</param>
        void CustomiseSettings(ParserSettings settings);
    }
}
