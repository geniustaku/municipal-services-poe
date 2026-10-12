# Municipal Services Application - PoE Part 2

Genius Mhirizhonga, ST10541838
AAPD7112 Advanced Application Development

This is Part 2 of the Municipal Services Application. It builds on the Part 1 app and adds
the Local Events and Announcements page.

GitHub: https://github.com/geniustaku/municipal-services-poe

## What you need

To run it, any Windows 10 or 11 machine works, .NET Framework 4.8 is already on those.
To open and build the code you need Visual Studio 2022 with the ".NET desktop development"
workload.

## How to build and run

Open `MunicipalServices.sln` in Visual Studio and press F5. That builds and runs it.
There is also a built copy in the `Executable` folder, double click
`MunicipalServicesApp.exe` to run without Visual Studio (keep the .config file next to it).

## How to use it

The app opens on the main menu. Report Issues is from Part 1. Click
**Local Events and Announcements** to open the new page.

On that page you can:

- See all upcoming events, already sorted by date.
- Search by category and by a date range (tick the date box to use it).
- Click an event to read its details.
- See recommendations, which come from the categories you search most.
- See your recent searches.

## Data structures used

- **Sorted dictionary** - keeps events in date order so upcoming events list correctly.
- **Dictionary** - events grouped by category for fast lookup when you search.
- **Sets (HashSet)** - the unique list of categories and dates, no duplicates.
- **Queue** - the upcoming events in chronological order.
- **Stack** - recent searches, newest on top.
- **Priority queue** - a small one I wrote, used to order recommendations soonest first.

## Recommendation feature

The app counts how many times you search each category. When you search, it looks at the
category you use most and suggests the soonest upcoming events from it, using the priority
queue to put the nearest dates first.

## Project layout

    MunicipalServicesApp\
        Program.cs
        Models\        Issue.cs, LocalEvent.cs
        Services\      EventService.cs, PriorityQueue.cs, plus the Part 1 services
        Forms\         MainMenuForm, ReportIssuesForm, LocalEventsForm
