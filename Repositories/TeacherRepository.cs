using Microsoft.EntityFrameworkCore;
using WebAPIDemo.Data;
using WebAPIDemo.Models;

namespace WebAPIDemo.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DataContext _dataContext;

        public TeacherRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Teacher create(Teacher teacher)
        {
            _dataContext.Teachers.Add(teacher);
            _dataContext.SaveChanges();
            return _dataContext.Teachers.Find(teacher.TeacherId);
        }

        public List<Teacher> getAll()
        {
            return _dataContext.Teachers.Include(t => t.Courses).ToList();
        }
        public Teacher getOne(int teacherId)
        {
            return _dataContext.Teachers.Include(t => t.Courses).FirstOrDefault(t => t.TeacherId == teacherId);
        }

        public Teacher update(Teacher newTeacher)
        {
            Teacher dbTeacher = _dataContext.Teachers.Find(newTeacher.TeacherId);
            if (dbTeacher == null)
                throw new Exception("No teacher with id " + newTeacher.TeacherId);
            dbTeacher.FirstName = newTeacher.FirstName;
            dbTeacher.LastName = newTeacher.LastName;
            dbTeacher.Courses = newTeacher.Courses;
            _dataContext.SaveChanges();
            return getOne(dbTeacher.TeacherId);
        }

        public int delete(int teacherId)
        {
            Teacher teacher = _dataContext.Teachers.Find(teacherId);
            _dataContext.Teachers.Remove(teacher);
            _dataContext.SaveChanges();
            return teacherId;
        }
    }
}
