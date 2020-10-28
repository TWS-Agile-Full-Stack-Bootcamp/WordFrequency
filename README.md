# dotnet-project-template


## How to add stylecop and rule set


1. Select a project in VS and add nuget package: StyleCop.Analyzers

2. Edit the .csproj file, add `<CodeAnalysisRuleSet>StyleCop.ruleset</CodeAnalysisRuleSet>` to the `<PropertyGroup>`

3. Copy StyleCop.ruleset to the same folder of .csproj file 
