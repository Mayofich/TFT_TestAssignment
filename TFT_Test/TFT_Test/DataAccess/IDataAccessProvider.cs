using TFT_Test.Models;
using TFT_Test.Data;
using System.Collections.Generic;


namespace TFT_Test.DataAccess
{
    public interface IDataAccessProvider
    {
        void AddDirectorRecord(Director director);
        void UpdateDirectorRecord(Director director);
        void DeleteDirectorRecord(int id);
        Director GetDirectorRecord(int id);
        List<Director> GetAllDirectors();
    }
}
