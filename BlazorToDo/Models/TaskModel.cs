namespace BlazorToDo.Models
{
    public class TaskModel
    {
        public TaskModel() { }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public Urgency ReportedUrgency { get; set; }
        public string[] Tags { get; set; }
        public bool Completed { get; set; }
        public bool Archived { get; set; }
    }
}
