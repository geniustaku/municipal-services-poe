# Municipal Services Application - PoE Final

Genius Mhirizhonga, ST10541838
AAPD7112 Advanced Application Development

This is the final part of the Municipal Services Application. It has all three features:
Report Issues (Part 1), Local Events and Announcements (Part 2) and Service Request Status (this part).

GitHub: https://github.com/geniustaku/municipal-services-poe

## What you need

To run it, any Windows 10 or 11 machine works, .NET Framework 4.8 is already on those.
To open and build the code you need Visual Studio 2022 with the ".NET desktop development"
workload. No database or internet connection is needed, the sample data loads when the app starts.

## How to compile and run

1. Open `MunicipalServices.sln` in Visual Studio 2022.
2. Choose Build > Build Solution (Ctrl+Shift+B). It should finish with 0 errors.
3. Press F5 to run.

There is also a built copy in the `Executable` folder. Double click `MunicipalServicesApp.exe`
to run it without Visual Studio (keep the .config file next to it).

## How to use it

The app opens on the main menu with three buttons.

**Report Issues** - fill in the location, category and description, attach a photo if you want,
and submit. You get a reference number like `MSA-20261113-0001`.

**Local Events and Announcements** - type any category in the box, for example `sports`,
`community, workshop` or just part of a word. Suggestions come up while you type. You can add a
date range. Recommendations come from what you search most. Double click a recent search to run it again.

**Service Request Status**

- The list shows every request, newest first. Critical ones are red, resolved ones are grey.
- Track a request: type its reference (`SR-1012`, `1012`, or the MSA number from Report Issues)
  and click Track. Anything you reported in Report Issues during the session shows up here.
- Filter requests: by status, area and category (type any text) and a date range.
- Click a request to see its details, progress bar, history and linked jobs.
- The tabs at the bottom:
  - **Next to attend** - the 10 most urgent open requests, plus the order to do linked jobs in.
  - **By department** - browse department > category > request.
  - **Crew route** - the shortest set of roads that links the depot to every area.
  - **Tree indexes** - the size and height of each tree, so you can see the balancing working.

Try tracking `SR-1012`. It waits on `SR-1005`, which waits on `SR-1009`.

## Data structures used in Service Request Status

All of these are written by me in the `DataStructures` folder, not taken from a library.

| Structure | Used for |
|---|---|
| Basic (general) tree | Department > category > request, shown in the By department tab |
| Binary tree | Base class with search and the in-order, pre-order and level-order traversals |
| Binary search tree | Finding a request by its number when you track it |
| AVL tree | Requests by date submitted, for date order and date range filters |
| Red-black tree | Requests by area, for the area filter |
| Min-heap | Next to attend, most urgent priority first then the oldest |
| Graph (directed) | Which jobs wait on other jobs, searched with breadth first search, work order with depth first search |
| Graph (undirected) + MST | Roads between areas, Kruskal's minimum spanning tree for the crew route |

The Implementation Report explains each one in more detail with examples.

## Changes from lecturer feedback

See `FEEDBACK_UPDATES.md`.

## Project layout

    MunicipalServicesApp\
        Program.cs
        Models\          Issue.cs, LocalEvent.cs, ServiceRequest.cs
        DataStructures\  BinaryTree, BinarySearchTree, AvlTree, RedBlackTree, BasicTree, MinHeap, Graph
        Services\        ServiceRequestService.cs, EventService.cs, PriorityQueue.cs, IssueRepository.cs, EngagementTracker.cs
        Forms\           MainMenuForm, ReportIssuesForm, LocalEventsForm, ServiceRequestStatusForm
