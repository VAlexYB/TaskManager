namespace TaskManager.Models
{
    public class SimpleTask : BaseModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeadlineDate { get; set; }
        public TimeSpan EstimatedRime { get; set; }
        public virtual User Executor { get; set; } = new User();

    }
}
