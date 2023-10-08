using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Session; 

public class CoachSessionController : Controller
{
    // Sample data for coach sessions 
    private readonly List<Session> _sessions = new List<Session>
    {
        new Session { Id = 1, Date = DateTime.Now, Time = "10:00 AM", Lesson = "Swimming Basics", EnrolledSwimmers = 5 },
        new Session { Id = 2, Date = DateTime.Now.AddDays(1), Time = "2:00 PM", Lesson = "Advanced Techniques", EnrolledSwimmers = 7 },
    };

    public IActionResult MySessions()
    {
        // Pass the list of sessions to the view
        return View(_sessions);
    }

    public IActionResult Details(int id)
    {
        // Find the session by ID 
        var session = _sessions.FirstOrDefault(s => s.Id == id);

        if (session == null)
        {
            return NotFound(); // Session not found
        }

        return View(session);
    }
}
