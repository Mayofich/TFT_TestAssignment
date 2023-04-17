using TFT_Test.Models;
using TFT_Test.Data;
using System.Collections.Generic;
using System.Linq;

namespace TFT_Test.DataAccess
{
    public class DataAccessProvider: IDataAccessProvider
    {
        private readonly DirectorCRUDContext _context;

        public DataAccessProvider(DirectorCRUDContext context)
        {
            _context = context;
        }

        public void AddDirectorRecord (Director director) 
        {
            _context.Directors.Add(director);
            _context.SaveChanges();
        }
        public async void UpdateDirectorRecord(Director director)
        {
            _context.Directors.Update(director);
            _context.SaveChanges();
        }
        public void DeleteDirectorRecord(int id)
        {
            var entity = _context.Directors.FirstOrDefault(t => t.DirectorId == id);
            _context.Directors.Remove(entity);
            _context.SaveChanges();
        }

        public Director GetDirectorRecord(int id) 
        {
            return _context.Directors.FirstOrDefault(t => t.DirectorId == id);
        }

        public List<Director> GetAllDirectors() 
        {
            return _context.Directors.ToList();
        }
    }
}
