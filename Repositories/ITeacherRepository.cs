using WebAPIDemo.Models;

namespace WebAPIDemo.Repositories
{
    public interface ITeacherRepository
    {
        Teacher create(Teacher teacher);
        List<Teacher> getAll();
        Teacher getOne(int teacherId);
        Teacher update(Teacher teacher);
        int delete(int teacherId);

    }
}
