using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace WebAPIdemo.DataStore
{
    // This context allows us to store items in-memory
    // To retrieve, add, remove and update objects
    // It also assigns a property to 'Id'
    public class InMemoryContext {
        
        private static readonly List<Entity> Data = new List<Entity>();
        
        public T Find<T>(int id) where T : Entity
        {
            return Data.OfType<T>().SingleOrDefault(o => o.Id == id);
        }
        
        public IEnumerable<T> Set<T>() where T : Entity
        {
            return Data.OfType<T>();
        }
        
        public T Add<T>(T newEntity) where T : Entity
        {
            newEntity.Id = Data.Any() ? Data.Max(o => o.Id) + 1 : 1;
            Data.Add(newEntity);
            return newEntity;
        }
        
        public void Remove(Entity entity)
        {
            var entry = Data.SingleOrDefault(e => e.Id == entity.Id);
            if (entry != null) Data.Remove(entry);
        }
        
        public T Update<T>(T entity) where T : Entity
        {
            // TODO
            return entity;
        }
    }
    
    public abstract class Entity {
        public int Id { get; internal set; }
    }
}