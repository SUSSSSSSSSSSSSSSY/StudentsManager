namespace StudentsManager
{

    using StudentsManager;

    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=DESKTOP-9PK656A\\SQLEXPRESS;Database=StudentGroupDB;Trusted_Connection=True;TrustServerCertificate=True";
            var manager = new StudentGroupManager(connectionString);

            manager.AddStudent("Ivan Ivanov", 20);
            manager.AddGroup("Group A");

            manager.AddStudentToGroup(1, 1);

            var groups = manager.GetGroupsByStudent(1);
            Console.WriteLine("Группы студента:");
            groups.ForEach(Console.WriteLine);

            var students = manager.GetStudentsByGroup(1);
            Console.WriteLine("Студенты в группе:");
            students.ForEach(Console.WriteLine);

            manager.UpdateStudent(1, "Ivan Petrov", 21);

            manager.DeleteStudent(1);
        }
    }

}
