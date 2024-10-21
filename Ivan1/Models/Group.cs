namespace Ivan1.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int DisciplineID { get; set; }
        public Discipline Discipline { get; set; }
        public Group()
        {

        }
    }
}
