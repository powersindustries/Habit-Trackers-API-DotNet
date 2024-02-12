namespace Models
{
    public class Habit
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Comments { get; set; }
        public int Start { get; set; }

        public bool IsEmpty()
        {
            return Id == null && Name == null && Comments == null && Start == 0;
	    }
    }
}