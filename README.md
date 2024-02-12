# Habit Trackers API

Have you ever wanted to track the amount of time you've successfully kept a habit? Are you looking to start a new habit and want to timestamp when you started? The Habit Trackers API is for you!


### How it Works
The Habit Trackers API stores any number of Habit objects that contain a unique hashed ID, the name of your habit, comments or notes about the habit's goals (Optional), and the unix timestamp of when you started. 

Habit data is stored in a MySQL database. The code assumes you're using MySQL, but feel free to change the connection code to whatever SQL database management system you prefer.

#### Habit Object
```C#
public class Habit
{
    // Hashed unique ID used for searching.
    public string? Id { get; set; }

    // Display name of the habit.
    public string? Name { get; set; }

    // Comments or notes about the habit.
    public string? Comments { get; set; }

    // Unix timestamp of when the habit was started. 
    // Can be used in the frontend for displaying the time thats elapsed since starting the habit.
    public int Start { get; set; }

}
```


### Current Endpoints
- Get All Habits (Debug for now, will remove in future)
- Get existing Habit by ID
- Add new Habit
- Delete existing habit


### Future Features
Items will be crossed off the list as they are implemented.
- Implement the concept of a "Cheat" day allowing for specific days of the week to not be counted towards progress.
- Edit an existing habit's information (Name, Comments, Start Date).
- Restart an existing habit.
- Implement a proper authentication system (Still debating if this is needed or an over complication).


### About
The Habit Trackers API was written in C# with the ASP.NET Core framework. This project is under the MIT license.

My motivation for creating this is API is my addiction to sugary snacks. I hope this can help others maintain or start new healthy habits. Cheers everyone!