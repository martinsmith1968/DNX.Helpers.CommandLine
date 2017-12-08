
# DNX.Helpers.CommandLine


## CommandLine.ArgumentExtensions

Class ArgumentExtensions.


### M:DNX.Helpers.CommandLine.Expand(args)

Expands the arguments.

| Name | Description |
| ---- | ----------- |
| args | *System.Collections.Generic.IEnumerable{System.String}*<br>The arguments. |


#### Returns

IEnumerable<System.String>.


## Exceptions.ExtendedParserResultException

Class ParserResultException.


### M:DNX.Helpers.CommandLine.#ctor(failureResult)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| failureResult | *DNX.Helpers.CommandLine.Results.ExtendedParserResult{System.Object}*<br>The failure result. |


### M:DNX.Helpers.CommandLine.#ctor(failureResult, message)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| failureResult | *DNX.Helpers.CommandLine.Results.ExtendedParserResult{System.Object}*<br>The failure result. |
| message | *System.String*<br>The message. |


### M:DNX.Helpers.CommandLine.#ctor(failureResult, message, innerException)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| failureResult | *DNX.Helpers.CommandLine.Results.ExtendedParserResult{System.Object}*<br>The failure result. |
| message | *System.String*<br>The message. |
| innerException | *System.Exception*<br>The inner exception. |


### M:DNX.Helpers.CommandLine.GetFailureResultAs``1

Gets the failure result as.


#### Returns

T.


## Exceptions.ExtendedParserResultException`1

Class ParserResultException.


### M:DNX.Helpers.CommandLine.#ctor(extendedParserResult)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| extendedParserResult | *DNX.Helpers.CommandLine.Results.IExtendedParserResult{`0}*<br>The extended parser result. |


### M:DNX.Helpers.CommandLine.#ctor(extendedParserResult, message)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| extendedParserResult | *DNX.Helpers.CommandLine.Results.IExtendedParserResult{`0}*<br>The extended parser result. |
| message | *System.String*<br>The message. |

### M:DNX.Helpers.CommandLine.#ctor(extendedParserResult, message, innerException)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| extendedParserResult | *DNX.Helpers.CommandLine.Results.IExtendedParserResult{`0}*<br>The extended parser result. |
| message | *System.String*<br>The message. |
| innerException | *System.Exception*<br>The inner exception. |


### .ExtendedParserResult

Gets the parserResult.


### .HelpRequested

Gets a value indicating whether [help requested].


## Help.HelpBuilder

Class HelpBuilder.


### M:DNX.Helpers.CommandLine.BuildTemplatedHelpText``1

Builds the templated help text.


#### Returns

System.String.


### M:DNX.Helpers.CommandLine.BuildTemplatedHelpText``1(parserResult)

Builds the templated help text.

| Name | Description |
| ---- | ----------- |
| parserResult | *CommandLine.ParserResult{``0}*<br>The parser result. |


#### Returns

System.String.


### M:DNX.Helpers.CommandLine.BuildTemplatedHelpText``1(template, parserResult)

Builds the templated help text.

| Name | Description |
| ---- | ----------- |
| template | *CommandLine.ParserResult{``0}*<br>The template. |
| parserResult | *System.String*<br>The parser result. |


#### Returns

System.String.


### M:DNX.Helpers.CommandLine.BuildTemplatedHelpText``1(template, templateEngine, parserResult)

Builds the templated help text.

| Name | Description |
| ---- | ----------- |
| template | *CommandLine.ParserResult{``0}*<br>The template. |
| templateEngine | *System.String*<br>The template engine. |
| parserResult | *DNX.Helpers.CommandLine.Templating.ITemplateEngine*<br>The parser result. |


#### Returns

System.String.


### M:DNX.Helpers.CommandLine.GetHelpText``1(parserResult, verbsIndex, consoleWidth)

Gets the help text.

| Name | Description |
| ---- | ----------- |
| parserResult | *CommandLine.ParserResult{``0}*<br>The parserx result. |
| verbsIndex | *System.Boolean*<br>if set to true [verbs index]. |
| consoleWidth | *System.Int32*<br>Width of the console. |


#### Returns

System.String.


## Help.Maps.ArgumentsMap

Class ArgumentsMap.


### M:DNX.Helpers.CommandLine.Create``1

Creates this instance.


#### Returns

System.Object.


## Help.Maps.ParserErrorInfo

Class ParserError.


### .Id

Gets the identifier.


### .Message

Gets or sets the message.


## Help.Templates

Class Templates.


### .StandardTemplate

Gets the standard template.


### F:DNX.Helpers.CommandLine.StandardTemplateLines

The standard template lines


## Interfaces.IParserSettingsCustomiser

Interface IParserSettingsConfigurator


### M:DNX.Helpers.CommandLine.CustomiseSettings(settings)

Configures the Parser Settings

| Name | Description |
| ---- | ----------- |
| settings | *CommandLine.ParserSettings*<br>The settings. |

## Interfaces.IPostParseValidator

Interface ISettingsValidator


### M:DNX.Helpers.CommandLine.Validate

Validates this instance.


## ParserExtendedSettings

Class ParserExtendedSettings.


### M:DNX.Helpers.CommandLine.#ctor

Initializes a new instance of the class.


### .DefaultTemplateEngine

Gets or sets the default template engine.


### M:DNX.Helpers.CommandLine.GetExtendedSettings(argumentsInstance)

Gets the extended settings.

| Name | Description |
| ---- | ----------- |
| argumentsInstance | *System.Object*<br>The arguments instance. |


#### Returns

ParserExtendedSettings.


### .HelpTextWidth

Gets or sets the width of the help text.


### M:DNX.Helpers.CommandLine.Reset

Resets the settings.


### .TemplateEngine

Gets or sets the type of the default template engine.


### .ThrowOnParseFailure

Gets or sets a value indicating whether the Parser should throw an Exception if parsing fails


## ParserExtensions

Class ParserVerbExtensions.


### M:DNX.Helpers.CommandLine.ParseAndValidate``1(parser, args)

Parses the specified arguments.

| Name | Description |
| ---- | ----------- |
| parser | *CommandLine.Parser*<br>The parser. |
| args | *System.Collections.Generic.IEnumerable{System.String}*<br>The arguments. |


#### Returns

ParserResult<T>.


### M:DNX.Helpers.CommandLine.ParseAndValidate``10(parser, args)

Parses the specified Command arguments.

| Name | Description |
| ---- | ----------- |
| parser | *CommandLine.Parser*<br>The parser. |
| args | *System.Collections.Generic.IEnumerable{System.String}*<br>The arguments. |


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.ParseAndValidate``11(parser, args)

Parses the specified Command arguments.

| Name | Description |
| ---- | ----------- |
| parser | *CommandLine.Parser*<br>The parser. |
| args | *System.Collections.Generic.IEnumerable{System.String}*<br>The arguments. |


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.ParseAndValidate``12(parser, args)

Parses the specified Command arguments.

| Name | Description |
| ---- | ----------- |
| parser | *CommandLine.Parser*<br>The parser. |
| args | *System.Collections.Generic.IEnumerable{System.String}*<br>The arguments. |


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.ParseAndValidate``13(parser, args)

Parses the specified Command arguments.

| Name | Description |
| ---- | ----------- |
| parser | *CommandLine.Parser*<br>The parser. |
| args | *System.Collections.Generic.IEnumerable{System.String}*<br>The arguments. |


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.ParseAndValidate``14(parser, args)

Parses the specified Command arguments.

| Name | Description |
| ---- | ----------- |
| parser | *CommandLine.Parser*<br>The parser. |
| args | *System.Collections.Generic.IEnumerable{System.String}*<br>The arguments. |


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.ParseAndValidate``15(parser, args)

Parses the specified Command arguments.

| Name | Description |
| ---- | ----------- |
| parser | *CommandLine.Parser*<br>The parser. |
| args | *System.Collections.Generic.IEnumerable{System.String}*<br>The arguments. |


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.ParseAndValidate``16(parser, args)

Parses the specified Command arguments.

| Name | Description |
| ---- | ----------- |
| parser | *CommandLine.Parser*<br>The parser. |
| args | *System.Collections.Generic.IEnumerable{System.String}*<br>The arguments. |


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.ParseAndValidate``2(parser, args)

Parses the specified Command arguments.

| Name | Description |
| ---- | ----------- |
| parser | *CommandLine.Parser*<br>The parser. |
| args | *System.Collections.Generic.IEnumerable{System.String}*<br>The arguments. |


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.ParseAndValidate``3(parser, args)

Parses the specified Command arguments.

| Name | Description |
| ---- | ----------- |
| parser | *CommandLine.Parser*<br>The parser. |
| args | *System.Collections.Generic.IEnumerable{System.String}*<br>The arguments. |


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.ParseAndValidate``4(parser, args)

Parses the specified Command arguments.

| Name | Description |
| ---- | ----------- |
| parser | *CommandLine.Parser*<br>The parser. |
| args | *System.Collections.Generic.IEnumerable{System.String}*<br>The arguments. |


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.ParseAndValidate``5(parser, args)

Parses the specified Command arguments.

| Name | Description |
| ---- | ----------- |
| parser | *CommandLine.Parser*<br>The parser. |
| args | *System.Collections.Generic.IEnumerable{System.String}*<br>The arguments. |


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.ParseAndValidate``6(parser, args)

Parses the specified Command arguments.

| Name | Description |
| ---- | ----------- |
| parser | *CommandLine.Parser*<br>The parser. |
| args | *System.Collections.Generic.IEnumerable{System.String}*<br>The arguments. |


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.ParseAndValidate``7(parser, args)

Parses the specified Command arguments.

| Name | Description |
| ---- | ----------- |
| parser | *CommandLine.Parser*<br>The parser. |
| args | *System.Collections.Generic.IEnumerable{System.String}*<br>The arguments. |


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.ParseAndValidate``8(parser, args)

Parses the specified Command arguments.

| Name | Description |
| ---- | ----------- |
| parser | *CommandLine.Parser*<br>The parser. |
| args | *System.Collections.Generic.IEnumerable{System.String}*<br>The arguments. |


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.ParseAndValidate``9(parser, args)

Parses the specified Command arguments.

| Name | Description |
| ---- | ----------- |
| parser | *CommandLine.Parser*<br>The parser. |
| args | *System.Collections.Generic.IEnumerable{System.String}*<br>The arguments. |


#### Returns

CommandLine.ParserResult<System.Object>.


## ParserHelper

Class ParserManager.


### .DefaultParser

Gets the default parser.


### M:DNX.Helpers.CommandLine.GetParser``1

Gets a parser for the specified Arguments type


#### Returns

Parser.


### M:DNX.Helpers.CommandLine.GetParser``10

Gets a parser for the specified Command types


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.GetParser``11

Gets a parser for the specified Command types


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.GetParser``12

Gets a parser for the specified Command types


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.GetParser``13

Gets a parser for the specified Command types


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.GetParser``14

Gets a parser for the specified Command types


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.GetParser``15

Gets a parser for the specified Command types


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.GetParser``16

Gets a parser for the specified Command types


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.GetParser``2

Gets a parser for the specified Command types


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.GetParser``3

Gets a parser for the specified Command types


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.GetParser``4

Gets a parser for the specified Command types


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.GetParser``5

Gets a parser for the specified Command types


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.GetParser``6

Gets a parser for the specified Command types


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.GetParser``7

Gets a parser for the specified Command types


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.GetParser``8

Gets a parser for the specified Command types


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.GetParser``9

Gets a parser for the specified Command types


#### Returns

CommandLine.ParserResult<System.Object>.


### M:DNX.Helpers.CommandLine.GetParserAndParse``1(args)

Gets a parser for the specified Arguments type and parses

| Name | Description |
| ---- | ----------- |
| args | *System.String[]*<br>The arguments. |


#### Returns

CommandLine.ParserResult<T>.


### M:DNX.Helpers.CommandLine.GetParserAndParse``10(System.String[])

Gets a parser for the specified Command types and parses


### M:DNX.Helpers.CommandLine.GetParserAndParse``11(System.String[])

Gets a parser for the specified Command types and parses


### M:DNX.Helpers.CommandLine.GetParserAndParse``12(System.String[])

Gets a parser for the specified Command types and parses


### M:DNX.Helpers.CommandLine.GetParserAndParse``13(System.String[])

Gets a parser for the specified Command types and parses


### M:DNX.Helpers.CommandLine.GetParserAndParse``14(System.String[])

Gets a parser for the specified Command types and parses


### M:DNX.Helpers.CommandLine.GetParserAndParse``15(System.String[])

Gets a parser for the specified Command types and parses


### M:DNX.Helpers.CommandLine.GetParserAndParse``16(System.String[])

Gets a parser for the specified Command types and parses


### M:DNX.Helpers.CommandLine.GetParserAndParse``2(System.String[])

Gets a parser for the specified Command types and parses


### M:DNX.Helpers.CommandLine.GetParserAndParse``3(System.String[])

Gets a parser for the specified Command types and parses


### M:DNX.Helpers.CommandLine.GetParserAndParse``4(System.String[])

Gets a parser for the specified Command types and parses


### M:DNX.Helpers.CommandLine.GetParserAndParse``5(System.String[])

Gets a parser for the specified Command types and parses


### M:DNX.Helpers.CommandLine.GetParserAndParse``6(System.String[])

Gets a parser for the specified Command types and parses


### M:DNX.Helpers.CommandLine.GetParserAndParse``7(System.String[])

Gets a parser for the specified Command types and parses


### M:DNX.Helpers.CommandLine.GetParserAndParse``8(System.String[])

Gets a parser for the specified Command types and parses


### M:DNX.Helpers.CommandLine.GetParserAndParse``9(System.String[])

Gets a parser for the specified Command types and parses


## ParserResultExtensions

Class ParserResultExtensions.


### M:DNX.Helpers.CommandLine.CreateExtendedResult``1(result, parser)

Creates the extended result.

| Name | Description |
| ---- | ----------- |
| result | *CommandLine.ParserResult{``0}*<br>The result. |
| parser | *CommandLine.Parser*<br>The parser. |


#### Returns

IExtendedParserResult.


### M:DNX.Helpers.CommandLine.ErrorResult``1(result)

Returns the failure result

| Name | Description |
| ---- | ----------- |
| result | *CommandLine.ParserResult{``0}*<br>The result. |


#### Returns

NotParsed<T>.


### M:DNX.Helpers.CommandLine.GetArguments``1(result)

Gets the arguments.

| Name | Description |
| ---- | ----------- |
| result | *CommandLine.ParserResult{``0}*<br>The result. |


#### Returns

T.


### M:DNX.Helpers.CommandLine.GetErrors``1(result)

Gets the errors.

| Name | Description |
| ---- | ----------- |
| result | *CommandLine.ParserResult{``0}*<br>The result. |


#### Returns

System.Collections.Generic.IEnumerable<CommandLine.Error>.


### M:DNX.Helpers.CommandLine.Ok``1(result)

Oks the specified result.

| Name | Description |
| ---- | ----------- |
| result | *CommandLine.ParserResult{``0}*<br>The result. |


#### Returns

true if XXXX, false otherwise.


### M:DNX.Helpers.CommandLine.PostProcessResult``1(result)

Post processes the result.

| Name | Description |
| ---- | ----------- |
| result | *DNX.Helpers.CommandLine.Results.IExtendedParserResult{``0}*<br>The result. |


#### Returns

ParserResult<T>.

*Exceptions.ExtendedParserResultException`1:* 


### M:DNX.Helpers.CommandLine.SuccessResult``1(result)

Returns the success result

| Name | Description |
| ---- | ----------- |
| result | *CommandLine.ParserResult{``0}*<br>The result. |


#### Returns

Parsed<T>.


### M:DNX.Helpers.CommandLine.ValidateInstance``1(result)

Custom validation on a parsed arguments instance

| Name | Description |
| ---- | ----------- |
| result | *CommandLine.Parsed{``0}*<br> |

## ParserSettingsChain

Class ParserSettingsChain.


### M:DNX.Helpers.CommandLine.Create(chain)

Creates the specified chain.

| Name | Description |
| ---- | ----------- |
| chain | *System.Action{CommandLine.ParserSettings}[]*<br>The chain. |


#### Returns

Action<ParserSettings>.


### M:DNX.Helpers.CommandLine.Create(chain)

Creates the specified chain.

| Name | Description |
| ---- | ----------- |
| chain | *System.Collections.Generic.IList{System.Action{CommandLine.ParserSettings}}*<br>The chain. |


#### Returns

Action<ParserSettings>.


## ParserSettingsHelper

Class ParserSettingsCustomiserHelper.


### M:DNX.Helpers.CommandLine.CanCustomiseSettings(type)

Determines whether this instance can customise the settings for the specified parser.

| Name | Description |
| ---- | ----------- |
| type | *System.Type*<br>The type. |


#### Returns

true if this instance can customise the settings for the specified parser; otherwise, false.


### M:DNX.Helpers.CommandLine.CanCustomiseSettings``1

Determines whether this instance can customise the settings for the specified parser.


#### Returns

true if this instance can customise the settings for the specified parser; otherwise, false.


### F:DNX.Helpers.CommandLine.DefaultParserCustomiser

The default parser customiser


### M:DNX.Helpers.CommandLine.GetSettingsCustomiser``1

Gets the settings customiser.


#### Returns

Action<ParserSettings>.


## Results.ExtendedParserResult`1

Class ExtendedParserResult.


### M:DNX.Helpers.CommandLine.#ctor(result, parser)

Initializes a new instance of the class.

| Name | Description |
| ---- | ----------- |
| result | *CommandLine.ParserResult{`0}*<br>The result. |
| parser | *CommandLine.Parser*<br>The parser. |

### .Parser

Gets the parser.


### .Result

Gets the result.


### .Success

Gets a value indicating whether this is success.


## Results.ExtendedParserResultExtensions

Class ExtendedParserResultExtensions.


### M:DNX.Helpers.CommandLine.WithNotParsed``1(result, action)

Withes the not parsed.

| Name | Description |
| ---- | ----------- |
| result | *DNX.Helpers.CommandLine.Results.IExtendedParserResult{``0}*<br>The result. |
| action | *System.Action{System.Collections.Generic.IEnumerable{CommandLine.Error}}*<br>The action. |


#### Returns

ParserResult<T>.


### M:DNX.Helpers.CommandLine.WithParsed``1(result, action)

Withes the parsed.

| Name | Description |
| ---- | ----------- |
| result | *DNX.Helpers.CommandLine.Results.IExtendedParserResult{``0}*<br>The result. |
| action | *System.Action{``0}*<br>The action. |


#### Returns

ParserResult<T>.


### M:DNX.Helpers.CommandLine.WithParsed``1(result, action)

Withes the parsed.

| Name | Description |
| ---- | ----------- |
| result | *DNX.Helpers.CommandLine.Results.IExtendedParserResult{System.Object}*<br>The result. |
| action | *System.Action{``0}*<br>The action. |


#### Returns

ParserResult<System.Object>.


## Results.IExtendedParserResult`1

Interface IExtendedParserResult


### .Parser

Gets the parser.


### .Result

Gets the result.


### .Success

Gets a value indicating whether this is success.


## Settings.ExtendedParserSettings

Class ExtendedParserSettings.


### M:DNX.Helpers.CommandLine.#ctor

Initializes a new instance of the class.


### .DefaultTemplateEngine

Gets or sets the default template engine.


### .HelpTextWidth

Gets or sets the width of the help text.


### M:DNX.Helpers.CommandLine.Reset

Resets the settings.


### .TemplateEngine

Gets or sets the type of the default template engine.


### .ThrowOnParseFailure

Gets or sets a value indicating whether the Parser should throw an Exception if parsing fails


## Templating.BaseTemplateEngine

Class DotLiquidTemplateEngine.


### M:DNX.Helpers.CommandLine.#ctor

Initializes a new instance of the class.


### M:DNX.Helpers.CommandLine.AddObject(name, instance)

Adds the object.

| Name | Description |
| ---- | ----------- |
| name | *System.String*<br>The name. |
| instance | *System.Object*<br>The instance. |

### M:DNX.Helpers.CommandLine.Render(templateLines)

Renders the specified template lines.

| Name | Description |
| ---- | ----------- |
| templateLines | *System.Collections.Generic.IList{System.String}*<br>The template lines. |


#### Returns

System.String.


### M:DNX.Helpers.CommandLine.Render(template)

Renders the specified template.

| Name | Description |
| ---- | ----------- |
| template | *System.String*<br>The template. |


#### Returns

System.String.

*System.NotImplementedException:* 


### M:DNX.Helpers.CommandLine.Reset

Resets this instance.


### F:DNX.Helpers.CommandLine.Substitutables

The substitutables


## Templating.DotLiquid.DotLiquidTemplateEngine

Class DotLiquidTemplateEngine.


### M:DNX.Helpers.CommandLine.#ctor

Initializes a new instance of the class.


### M:DNX.Helpers.CommandLine.Render(template)

Renders the specified template.

| Name | Description |
| ---- | ----------- |
| template | *System.String*<br>The template. |


#### Returns

System.String.


## Templating.ITemplateEngine

Interface ITemplateEngine


### M:DNX.Helpers.CommandLine.AddObject(name, instance)

Adds the object.

| Name | Description |
| ---- | ----------- |
| name | *System.String*<br>The name. |
| instance | *System.Object*<br>The instance. |

### M:DNX.Helpers.CommandLine.Render(templateLines)

Renders the specified template lines.

| Name | Description |
| ---- | ----------- |
| templateLines | *System.Collections.Generic.IList{System.String}*<br>The template lines. |


#### Returns

System.String.


### M:DNX.Helpers.CommandLine.Render(template)

Renders the specified template.

| Name | Description |
| ---- | ----------- |
| template | *System.String*<br>The template. |


#### Returns

System.String.


### M:DNX.Helpers.CommandLine.Reset

Resets this instance.


## T:SampleApp.Arguments

Arguments class for command line


## T:SampleApp.Program

Program controller class


### M:SampleApp.Program.Main(args)

Defines the entry point of the application.

| Name | Description |
| ---- | ----------- |
| args | *System.String[]*<br>The arguments. |


#### Returns

System.Int32.


### M:SampleApp.Program.Run(arguments)

Runs the program using the specified arguments.

| Name | Description |
| ---- | ----------- |
| arguments | *SampleApp.Arguments*<br>The arguments. |

