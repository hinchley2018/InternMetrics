namespace InternMetrics.Models
{
    public class Intern
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int HomeStateEnum { get; set; }
        public string DesiredSkill { get; set; }
    }
}