using WebAPIDemo.Models;

namespace WebAPIDemo.Services
{
    public interface ITeacherService
    {
        Teacher create(Teacher teacher);
        Teacher getOne(int teacherId);
        List<Teacher> getAll();
        Teacher update(Teacher teacher);
        int delete(int teacherId);
    }
}
