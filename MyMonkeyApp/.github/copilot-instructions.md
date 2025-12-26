This project is .NET 9 and uses C# 13.

Make sure all code generated is inside the MyMonkeyApp project.

## Project Context
Console application that manages monkey species data and integrates with GitHub through MCP servers.

## C# Coding Standards
- PascalCase for classes and methods
- camelCase for variables
- XML documentation comments
- async/await where applicable
- Nullable reference types enabled
- File-scoped namespaces

## Architecture
- Console UI
- MonkeyHelper static service
- Monkey model class

## GitHub CLI Commands
To create a new issue for implementing the Monkey Console Application, use the following command:
```bash
gh issue create --title "Implement Monkey Console Application" --body "$(Get-Content .github/ISSUE_TEMPLATE/implement-monkey-console.md)" --label "enhancement,good first issue"
