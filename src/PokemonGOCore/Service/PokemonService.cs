using PokemonGOCore.Model;
using PokemonGOCore.Repository;
using System.Collections.Generic;

namespace PokemonGOCore.Service
{
    public class PokemonService
    {
        protected PokemonRepository _Repository;

        public PokemonService()
        {
            _Repository = new PokemonRepository();
        }

        public List<Pokemon> FindAll()
        {
            return _Repository.FindAll();
        }

        public void Salvar(Pokemon pokemon)
        {
            _Repository.Update(pokemon);
        }

        public void Inserir(Pokemon pokemon)
        {
            _Repository.Create(pokemon);
        }

        public Pokemon BuscarPorID(int idpokemon)
        {
            return _Repository.FindById(idpokemon);
        }

        public void Deletar(int idpokemon)
        {
            _Repository.Remove(idpokemon);
        }
    }
}
