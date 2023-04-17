using TFT_Test.Models;
using TFT_Test.Data;
using System.Collections.Generic;
using System.Linq;

namespace TFT_Test.DataAccess
{
    public class DataAccessProviderActor: IDataAccessProviderActor
    {
        private readonly ActorCRUDContext _context;

        public DataAccessProviderActor(ActorCRUDContext context)
        {
            _context = context;
        }

        public void AddActorRecord(Actor actor) 
        {
            _context.Actor.Add(actor);
            _context.SaveChanges();
        }
        public async void UpdateActorRecord(Actor actor)
        {
            _context.Actor.Update(actor);
            _context.SaveChanges();
        }
        public void DeleteActorRecord(int id)
        {
            var entity = _context.Actor.FirstOrDefault(t => t.ActorId == id);
            if (entity != null) 
                _context.Actor.Remove(entity);
            _context.SaveChanges();
        }

        public Actor GetActorRecord(int id) 
        {

            return _context.Actor.FirstOrDefault(t => t.ActorId == id);
            
        }

        public List<Actor> GetAllActors() 
        {
            return _context.Actor.ToList();
        }
    }
}
