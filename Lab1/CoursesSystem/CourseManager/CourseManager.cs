using System.Security.Cryptography;

namespace CoursesSystem.CourseManager
{
    public class CourseManager
    {
        public List<Course> Courses { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Student> Students { get; set; }
        private int _nextCourseID = 1;
        private int _nextUserID = 1;

        public CourseManager()
        {
            Courses = new List<Course>();
            Teachers = new List<Teacher>();
            Students = new List<Student>();
        }

        private Course _findCourseByCode(string courseCode)
        {
            var course = Courses.FirstOrDefault(c => c.CourseCode == courseCode);
            if (course == null)
            {
                throw new Exception("Course not found");
            }
            return course;
        }

        private Course _getCourseByID(int courseID)
        {
            var course = Courses.FirstOrDefault(c => c.CourseID == courseID);
            if (course == null)
            {
                throw new Exception("Invalid Course ID");
            }
            return course;
        }

        private User _getUserByID(int userID)
        {
            if (userID < 1 || userID > (Teachers.Count + Students.Count))
            {
                throw new Exception("Invalid User ID");
            }

            var user = Teachers.FirstOrDefault(t => t.IDNumber == userID) as User
                       ?? Students.FirstOrDefault(s => s.IDNumber == userID) as User;

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }

        public void CreateOnlineCourse(string courseName, string courseCode, string platform)
        {
            var course = new OnlineCourse(courseName, courseCode, _nextCourseID, platform);
            _nextCourseID++;
            Courses.Add(course);
        }

        public void CreateOfflineCourse(string courseName, string courseCode, string location, string schedule, string room)
        {
            var course = new OfflineCourse(courseName, courseCode, _nextCourseID, location, schedule, room);
            _nextCourseID++;
            Courses.Add(course);
        }

        public void RegisterTeacher(string name, string email, string department, string qualification)
        {
            var teacher = new Teacher(name, email, _nextUserID, department, qualification);
            _nextUserID++;
            Teachers.Add(teacher);
        }

        public void RegisterStudent(string name, string email, string department, string group, string year)
        {
            var student = new Student(name, email, _nextUserID, department, group, year);
            _nextUserID++;
            Students.Add(student);
        }

        public void AssignUserToCourse(int userID, int courseID)
        {
            try
            {
                var user = _getUserByID(userID);
                var course = _getCourseByID(courseID);

                switch (user)
                {
                    case Teacher teacher:
                        if (!course.AssignedTeachers.Contains(teacher))
                        {
                            course.AssignedTeachers.Add(teacher);
                        }
                        if (!teacher.EnrolledCourses.Contains(course))
                        {
                            teacher.EnrolledCourses.Add(course);
                        }
                        break;
                    case Student student:
                        if (!course.EnrolledStudents.Contains(student))
                        {
                            course.EnrolledStudents.Add(student);
                        }
                        if (!student.EnrolledCourses.Contains(course))
                        {
                            student.EnrolledCourses.Add(course);
                        }
                        break;
                    default:
                        throw new Exception("User must be a Teacher or Student");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error assigning user to course: {ex.Message}");
            }
        }

        public void DeleteCourse(string courseCode)
        {
            // Implementation for deleting a course
        }
    }
}