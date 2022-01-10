using System.COmponentModel.DataAnnotations;

namespace BlazorToDo.Models
{
    public class TaskModel
    {
        public TaskModel() { }
        public int Id { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        [Required] public DateTime DueDate { get; set; }
        public Urgency ReportedUrgency { get; set; }
        public string[] Tags { get; set; }
        public bool Completed { get; set; }
        public bool Archived { get; set; }
        public List<TaskComment> Comments { get; set; }
    }
}
