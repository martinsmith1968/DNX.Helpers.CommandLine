using System;

#pragma warning disable 1591
namespace DNX.Helpers.CommandLine.Help
{
    /// <summary>
    /// Class Templates.
    /// </summary>
    public static class Templates
    {
        public static readonly string ProgramHeader = "{{Program.Title}} v{{Program.SimplifiedVersion}}{% if Program.Description.Length > 0 %} - {{Program.Description}}{% endif %}";

        public static readonly string ProgramArgumentOptionValues = "{% if o.MetaValueList %} ({{ o.MetaValueList }})"
                                                                    + "{% elseif o.ValueList %}"
                                                                       + "{% if o.VerboseValueList %} (Values: {{ o.ValueList }})"
                                                                       + "{% else %}:{{ o.ValueList }}"
                                                                       + "{% endif %}"
                                                                    + "{% elseif o.ValueTypeName and !o.VerboseValueList %} ({{o.ValueTypeName}})"
                                                                    + "{% endif %}";

        public static readonly string ProgramArgumentPositional = " {% if o.Optional %}{ {% endif %}[{{o.Name}}" + ProgramArgumentOptionValues + "]{% if o.Optional %} }{% endif %}";
        public static readonly string ProgramUsage = "{{Program.FileName}}{% for o in Arguments.Positional %}" + ProgramArgumentPositional + "{% endfor %}{% if Arguments.Options %} { [options] }{% endif %}";

        public static readonly string ProgramOptionName = "{% capture optionName %}-{{ o.Shortcut }}{% if o.Name %}, --{{ o.Name | padright: Arguments.MaxOptionNameLength }}{% endif %}{% endcapture %}";
        public static readonly string ProgramOptionLine = ProgramOptionName + "{{ optionName }}    {% if o.Required %}Required. {% endif %}{{ o.Description }}" + ProgramArgumentOptionValues;

        /// <summary>
        /// The standard template lines
        /// </summary>
        public static readonly string[] StandardTemplateLines =
        {
            ProgramHeader,
            "{{Program.Copyright}}",
            "{% if ParserResult.Failed -%}",
            "",
            "Errors:",
            "{% for e in ParserResult.Errors -%}",
            "{{e.Message}}",
            "{% endfor -%}",
            "{% endif -%}",
            "",
            "Usage:",
            ProgramUsage,
            "{% if Arguments.Options -%}",
            "",
            "Options:",
            "{% for o in Arguments.Options -%}",
            ProgramOptionLine,
            "{% endfor -%}",
            "{% endif -%}",
            "",
        };

        /// <summary>
        /// Gets the standard template.
        /// </summary>
        /// <value>The boilerplate template.</value>
        public static string StandardTemplate
        {
            get { return string.Join(Environment.NewLine, StandardTemplateLines); }
        }
    }
}
