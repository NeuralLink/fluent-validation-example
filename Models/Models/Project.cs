namespace Models.Models
{
    public class Project
    {
        public string Customer { get; set; }

        public ICollection<Developer> Developers { get; set; }

        public string Name { get; set; }

        public string ProjectNumber { get; set; }
    }
}