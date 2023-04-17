using TFT_Test.Models;
using TFT_Test.Data;
using System.Collections.Generic;


namespace TFT_Test.DataAccess
{
    public interface IDataAccessProviderActor
    {
        void AddActorRecord(Actor actor);
        void UpdateActorRecord(Actor actor);
        void DeleteActorRecord(int id);
        Actor GetActorRecord(int id);
        List<Actor> GetAllActors();
    }
}
