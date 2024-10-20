namespace StudentsManager
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Microsoft.Data.SqlClient;

    public class StudentGroupManager
    {
        private readonly string connectionString;

        public StudentGroupManager(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddStudent(string name, int age)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "INSERT INTO Students (Name, Age) VALUES (@Name, @Age)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Age", age);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void AddGroup(string groupName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "INSERT INTO Groups (GroupName) VALUES (@GroupName)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@GroupName", groupName);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void AddStudentToGroup(int studentId, int groupId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "INSERT INTO StudentGroups (StudentId, GroupId) VALUES (@StudentId, @GroupId)";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentId", studentId);
                command.Parameters.AddWithValue("@GroupId", groupId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<string> GetGroupsByStudent(int studentId)
        {
            var groups = new List<string>();
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"
                SELECT G.GroupName
                FROM Groups G
                INNER JOIN StudentGroups SG ON G.GroupId = SG.GroupId
                WHERE SG.StudentId = @StudentId";

                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentId", studentId);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        groups.Add(reader.GetString(0));
                    }
                }
            }
            return groups;
        }

        public List<string> GetStudentsByGroup(int groupId)
        {
            var students = new List<string>();
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"
                SELECT S.Name
                FROM Students S
                INNER JOIN StudentGroups SG ON S.StudentId = SG.StudentId
                WHERE SG.GroupId = @GroupId";

                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@GroupId", groupId);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(reader.GetString(0));
                    }
                }
            }
            return students;
        }

        public void DeleteStudent(int studentId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "DELETE FROM Students WHERE StudentId = @StudentId";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentId", studentId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateStudent(int studentId, string name, int age)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "UPDATE Students SET Name = @Name, Age = @Age WHERE StudentId = @StudentId";
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StudentId", studentId);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Age", age);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }

}
