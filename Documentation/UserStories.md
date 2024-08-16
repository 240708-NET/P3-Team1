# Reevature Online Eniversity

## Description
ROE is an online university that offers an array of extremely normal courses for working professionals. This app is a means by which students can sign up for these courses. Users will be able to login to the site, see which courses they have already signed up for, and sign up for new courses.

### User Stories
- Users will be able to register for an account.
- Users will be able to login to the site with their account, at which point they are directed to their home page.
- Users will have access to at least two main pages: the current courses page (which will also serve as home page), and the register for courses page.
- Through the Register course page, users can register for new courses.
- The user can sort currently offered courses by course type (ie Business, Biology, Poli Sci, etc).
- Users can search courses with a search bar.
- Users can view course description, available times, and other relevant details.
- Courses which are currently at capacity will display as unavailable for students to register for.
- If a user has already registered for a course that conflicts with the time of a course that the user is currently looking at, the user will be notified as such (ex. if the user is already taking a course at 9am on Mondays, they will be notified if they attempt to register for a course that happens at 9am on Mondays)
- The user can remove courses from their currently registered courses, either from their current courses page or from the search courses page.
#### Stretch Goals
- JWT implementation with OAuth (auth0 suggested)
- Course pre-requisites
- Students can see their current schedule formated as a weekly calendar.
- Faculty members can login as faculty members.
- Faculty members can see the course sections which they currently teach.
- Faculty can create new courses or delete extant course sections (time slots of courses that they teach).
- If a faculty member attempts to delete a course section to which students are already registered, the faculty member will be alerted to this before proceeding.
- If a course section is deleted which already has registered students, the students will be notified of the deletion.