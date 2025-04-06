
# ekvip.CommandShell

A C# console application that supports dynamic command execution and undo functionality using the Command Pattern.

## Commands Supported

- `increment`: increases result by 1
- `decrement`: decreases result by 1
- `double`: multiplies result by 2
- `randadd`: adds a random number between -10 and 50
- `undo`: reverts the last non-undo operation

## Running the App

### Locally
```bash
dotnet run --project ekvip.CommandShell -- 5

or 

Simply just run the run-all.sh file and follow the prompts
```

### With Docker
```bash
docker build -f ekvip.CommandShell/Dockerfile -t ekvip-shell-app .
docker run -it ekvip-shell-app 5
```

## Running Tests

```bash
dotnet test
```

## Project Structure

- `ekvip.CommandShell/` — main console app
- `ekvip.CommandShell.UnitTest/` — unit tests
- `ekvip.CommandShell.IntegrationTest/` — integration tests

## Design

Uses the **Command Pattern** to encapsulate all command operations with `Execute` and `Undo`. A command invoker manages history for undo functionality.

---
