# Updates made from lecturer feedback

Genius Mhirizhonga, ST10541838, AAPD7112

## Part 2 feedback

> Improve the feature of researching for categories, allow the user to type in any choice of
> their categories in a textfield.

### What I changed

1. **Category is now a text field.** On the Local Events page the category drop down list is
   replaced with a text box (`txtCategory` in `LocalEventsForm`). The user can type anything.
2. **Suggestions while typing.** The text box uses auto complete with the known categories, so
   typing `sp` suggests `Sports`, but the user is not limited to the list.
3. **Partial and multiple categories.** `EventService.Search` now accepts part of a name
   (`sport` finds Sports) and more than one category separated by commas (`community, workshop`).
4. **Words that are not a category still work.** If what was typed does not match a category,
   the search looks in the event titles and descriptions instead (`water` finds the Water Outage
   Notice), and the page says what was matched.
5. **Recent searches can be rerun.** Double clicking a recent search puts it back in the box and
   searches again.
6. **Same idea on the new page.** On Service Request Status the area and category filters are also
   free text fields with suggestions.

### Files changed

- `Forms/LocalEventsForm.cs` and `Forms/LocalEventsForm.Designer.cs`
- `Services/EventService.cs` (new `Search`, `RecordSearch` and `LastSearchNote`)

### How to check it

Open Local Events and Announcements and search for `sport`, then `community, workshop`, then `water`.
