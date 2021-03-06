﻿using System.Collections.Generic;
using System.IO;
using DNX.Helpers.Strings;

namespace DNX.Helpers.CommandLine.CommandLine
{
    /// <summary>
    /// Class ArgumentExtensions.
    /// </summary>
    public static class ArgumentExtensions
    {
        /// <summary>
        /// Expands the arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        public static IEnumerable<string> Expand(this IEnumerable<string> args)
        {
            var expandedArgs = new List<string>();

            foreach (var arg in args)
            {
                var handled = false;
                if (arg.StartsWith("@"))
                {
                    var fileInfo = new FileInfo(arg.RemoveStartsWith("@"));
                    if (fileInfo.Exists)
                    {
                        expandedArgs.AddRange(File.ReadAllLines(fileInfo.FullName));
                        handled = true;
                    }
                }

                if (!handled)
                {
                    expandedArgs.Add(arg);
                }
            }

            return expandedArgs;
        }
    }
}
