# Scheduled Actions
[![nuget](https://img.shields.io/nuget/v/ScheduledActions.svg)](https://www.nuget.org/packages/ScheduledActions)
[![nuget](https://img.shields.io/nuget/dt/ScheduledActions.svg)](https://www.nuget.org/packages/ScheduledActions)

Provides a set of classes that allow to execute one or several `Action` instances on a regular time schedule.
If more than one `Action` instances are passed to a class, they will be executed sequentially.

## Installation

Using NuGet package manager console:

```
Install-Package ScheduledActions
```

Using .NET CLI:

```
dotnet add package ScheduledActions
```

## Usage

**Please Note:** All these classes implements the `IDisposable` interface, so any instance must be properly disposed when no longer needed. 

<!--
### Execute one or several actions each X minutes

``` csharp
new MinutelyAction(Action1)
new MinutelyAction(Action1, Action2)
new MinutelyAction(
```
-->

## HourlyAction

Prepares an action that will be executed each X hours.

## DailyAction

Prepares an action that will be executed each X days.

## WeeklyAction

Prepares an action that will be executed each X weeks.

## MonthlyAction

Prepares an action that will be executed each X months.

