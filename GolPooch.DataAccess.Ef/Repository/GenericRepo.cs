using Elk.EntityFrameworkCore;

namespace GolPooch.DataAccess.Ef
{
    public class GenericRepo<T> : EfGenericRepo<T> where T : class
    {
        public GenericRepo(GolPoochDbContext golPoochDbContext) : base(golPoochDbContext) { }
    }
}
