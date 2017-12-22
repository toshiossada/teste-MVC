using PokemonGOCore.Infrastructure;
using PokemonGOCore.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PokemonGOCore.Repository
{
    public class PokemonTypeRepository
    {
        protected DbSet<PokemonType> _Repository;

        public PokemonTypeRepository()
        {
            _Repository = UnitOfWork.Context.Set<PokemonType>();
        }


        public List<PokemonType> FindAll()
        {
            return _Repository.ToList();
        }

        public PokemonType FindById(int id)
        {
            return _Repository.Find(id);
        }
    }
}
