﻿using NetCoreADO.Models;
using NetCoreADO.Utility;
using System.Data;
using System.Data.SqlClient;

namespace NetCoreADO.DataAccessLayer
{
    public class StudentDAL
    {
        string connectionString = ConnectionString.cName;
        public IEnumerable<Student> GetAllStudent()
        {
            List<Student> lststudents = new List<Student>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SPGetAllStudent", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.Id = Convert.ToInt32(reader["Id"]);
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                    student.Email = reader["Email"].ToString();
                    student.Mobile = reader["Mobile"].ToString();
                    student.Address = reader["Address"].ToString();
                    lststudents.Add(student);
                }
                //sqlCommand.ExecuteNonQuery();
                con.Close();
            }
            return lststudents;
        }

        public void AddStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SPAddStudent",con);
                sqlCommand.CommandType=CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@FirstName", student.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", student.LastName);
                sqlCommand.Parameters.AddWithValue("@Email", student.Email);
                sqlCommand.Parameters.AddWithValue("@Mobile", student.Mobile);
                sqlCommand.Parameters.AddWithValue("@Address", student.Address);
                con.Open();
                sqlCommand.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SPUpdateStudent", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", student.Id);
                sqlCommand.Parameters.AddWithValue("@FirstName", student.FirstName);
                sqlCommand.Parameters.AddWithValue("@LastName", student.LastName);
                sqlCommand.Parameters.AddWithValue("@Email", student.Email);
                sqlCommand.Parameters.AddWithValue("@Mobile", student.Mobile);
                sqlCommand.Parameters.AddWithValue("@Address", student.Address);
                con.Open();
                sqlCommand.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteStudent(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SPDeleteStudent", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Id", id);
                con.Open();
                sqlCommand.ExecuteNonQuery();
                con.Close();
            }
        }

        public Student GetStudentData(int? id)
        {
            Student student = new Student();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "select * from student where Id=@Id";
                SqlCommand sqlCommand = new SqlCommand(query, con);
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    student.Id = Convert.ToInt32(reader["Id"]);
                    student.FirstName = reader["FirstName"].ToString();
                    student.LastName = reader["LastName"].ToString();
                    student.Email = reader["Email"].ToString();
                    student.Mobile = reader["Mobile"].ToString();
                    student.Address = reader["Address"].ToString();
                }
                con.Close();
            }
            return student;
        }
    }
}
