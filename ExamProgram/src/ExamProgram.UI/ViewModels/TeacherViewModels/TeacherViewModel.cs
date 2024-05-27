namespace ExamProgram.UI.ViewModels.TeacherViewModels
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Fullname
        {
            get { return $"{Name} {Surname}"; }
        }
    }
}
