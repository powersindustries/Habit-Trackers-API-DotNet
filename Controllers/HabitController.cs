using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitController : Controller
    {


        // -----------------------------------------------------
        // GET - All Habit data.
        // -----------------------------------------------------
        [HttpGet("get/all")]
        public IActionResult GetAllHabits()
        {
            List<Models.Habit> habitListData = Helpers.SqlHelpers.GetAllHabits();
            if (habitListData.Count == 0)
            {
                return StatusCode(500, "Habit database is empty.");
            }

            return Ok(habitListData);
        }


        // -----------------------------------------------------
        // GET - Habit data by ID.
        // -----------------------------------------------------
        [HttpGet("get/{id}")]
        public IActionResult GetByHabitID(string inID)
        {
            string hashedId = Helpers.Helpers.StringToHash(inID);

            Models.Habit habitData = Helpers.SqlHelpers.GetHabitByHashedID(hashedId);
            if (habitData.IsEmpty())
	        {
                return StatusCode(500, "Habit ID (" + inID + ") doesnt exist.");
            } 

	        return Ok(habitData);
        }


        // -----------------------------------------------------
        // POST - Create new Habit data.
        // -----------------------------------------------------
        [HttpPost("add")]
        public IActionResult AddNewHabitData([FromBody] Models.Habit inHabitData)
        {
            if (inHabitData.IsEmpty())
            { 
                return StatusCode(500, "Body habit object is empty.");
	        }

            inHabitData.Id = Helpers.Helpers.StringToHash(inHabitData.Id);

            if (!Helpers.SqlHelpers.CreateNewHabit(inHabitData))
            {
                return StatusCode(500, "Failed to create new Habit object.");
	        }

            return Ok("Success");
        }


        // -----------------------------------------------------
        // DELETE -  Habit data by ID.
        // -----------------------------------------------------
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteHabitByID(string id)
        {
            string hashedID = Helpers.Helpers.StringToHash(id);

            if (!Helpers.SqlHelpers.DeleteHabit(hashedID))
            {
                return StatusCode(500, "Failed to create new Habit object.");
	        }

            return Ok("Success");
        }
    }
}

