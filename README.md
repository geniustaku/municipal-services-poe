# Municipal Services Application

AAPD7112 Portfolio of Evidence, Part 1
Genius Mhirizhonga, ST10541838

A Windows Forms application that lets a resident report a municipal issue, attach a photo or
document to it, and get a reference number back. It is written in C# on .NET Framework 4.8.

Only the Report Issues feature is built in this part. Local Events and Announcements and
Service Request Status appear on the main menu but are disabled, because they are part of
the later parts of the PoE.

## What you need

To just run it, any Windows 10 or Windows 11 machine will do. .NET Framework 4.8 is already
installed on those versions, so nothing extra is needed.

To open and build the source you need Visual Studio 2022 with the ".NET desktop development"
workload installed. That workload includes the .NET Framework 4.8 targeting pack.

## Running the compiled program

There is a ready built copy in the `Executable` folder. Double click
`MunicipalServicesApp.exe` and the application opens. Keep `MunicipalServicesApp.exe.config`
in the same folder as the exe, otherwise the program will not start.

If Windows shows a blue "Windows protected your PC" box, that is SmartScreen reacting to an
exe that was downloaded rather than installed. Click "More info" and then "Run anyway".

## Building from source

Open `MunicipalServices.sln` in Visual Studio, then press Ctrl+Shift+B to build, or F5 to
build and run in one step. The build output ends up in
`MunicipalServicesApp\bin\Debug\net48` or `bin\Release\net48` depending on the configuration
you picked.

If you would rather build from a terminal, run this from the folder holding the solution:

    dotnet build -c Release

## How to use it

**Main menu.** The application opens on the main menu. Report Issues is the only option that
is enabled. The other two are greyed out on purpose and there is a line underneath saying
why. A label at the bottom keeps count of how many issues have been reported since the
program was opened.

**Reporting an issue.** Click Report Issues and the reporting window opens. Fill in:

- Location. Free text, so a street address or a landmark both work.
- Category. Choose one from the dropdown, for example Sanitation or Roads and Potholes.
- Description. This is a rich text box, so you can type as much detail as you need.
- Attach Media. Optional. Opens a file dialog where you can pick one or more images or
  documents. The label next to the button shows what has been attached.

**The progress bar.** As you fill the form in, the bar at the bottom fills up and the message
under it changes. This is the user engagement strategy from the research task. Location and
category are worth 25 percent each, the description is worth 35 percent, and attaching a file
is worth the last 15 percent. A very short description only earns half of its share, because
a one word description is not much use to whoever has to fix the problem.

**Submitting.** Click Submit. If the location, category or description is missing, a warning
appears and the cursor jumps to the first field that still needs filling in. If everything is
there, the report is saved and a confirmation box shows the reference number, for example
MSA-20260902-0001. The form then clears itself so the next issue can be reported.

**Going back.** Back to Main Menu returns you to the menu. If you have typed something and not
submitted it, it asks first rather than throwing the report away silently.

## How the reports are stored

Reports are held in memory in a `List<Issue>` inside `IssueRepository`. A list was the right
fit here because reports are added one at a time and read back in the order they were
captured, and there is no need to look one up by key at this stage.

Because the storage is in memory, reports are lost when the application closes. That is
intentional for Part 1. The brief asks for an appropriate data structure rather than a
database, and adding persistence now would mean rewriting it later when the Service Request
Status feature needs proper storage.

## Project layout

    MunicipalServicesApp\
        Program.cs                      entry point
        Models\Issue.cs                 one reported issue
        Services\IssueRepository.cs     the list of issues and the reference numbers
        Services\EngagementTracker.cs   progress calculation and the messages
        Forms\MainMenuForm.cs           main menu
        Forms\ReportIssuesForm.cs       the reporting form
    Executable\                         prebuilt copy you can run without Visual Studio

## Known limitations

- Reports are not saved to disk, as explained above.
- Attachments are stored as file paths, not copied into the application. If the original file
  is moved or deleted the path will no longer point at anything. Copying the files properly
  belongs with the persistence work in a later part.
- The two disabled menu options do nothing yet by design.
