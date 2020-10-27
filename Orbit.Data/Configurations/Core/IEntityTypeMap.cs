using Microsoft.EntityFrameworkCore;

namespace Orbit.Data.Configurations.Core
{
    public interface IEntityTypeMap
    {
        void Map(ModelBuilder builder);
    }
}