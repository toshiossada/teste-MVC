using System;
using PokemonGOCore.Model;
using PokemonGOCore.Service;
using PokemonGOWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PokemonGOWeb.Controllers
{
    public class PokemonController : Controller
    {
        public ActionResult Index()
        {
            var service = new PokemonService();
            List<Pokemon> allPokemons = service.FindAll();

            if (Session["ListaPessoas"] == null)
                Session["ListaPessoas"] = allPokemons;

            return View(allPokemons);
        }
        [HttpPost]
        public ActionResult Index(string texto)
        {
            var pokemons = (List<Pokemon>)Session["ListaPessoas"];


            return View(pokemons.Where(x => x.Name.ToUpper().Contains(texto.ToUpper()) || x.PokemonType.Description.ToUpper().Contains(texto.ToUpper())).ToList());
        }

        public ActionResult Search(string word)
        {
            return View("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(Pokemon pokemon)
        {

            var service = new PokemonService();
            service.Deletar(pokemon.Id);

            return View("Index", service.FindAll());
        }


        public ActionResult Editar(int id)
        {
            var service = new PokemonService();

            var pokemon = service.BuscarPorID(id);
            return View("Delete", pokemon);
        }


        [HttpPost]
        public ActionResult Save(PokemonViewModel pokemon)
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {

            var service = new PokemonService();
            service.Deletar(id);
            var all = service.FindAll();
            Session["ListaPessoas"] = all;

            return View("Index", all);
        }

        public ActionResult Check(int id)
        {
            var service = new PokemonService();

            var pokemon = service.BuscarPorID(id);

            pokemon.CurrentHave = !pokemon.CurrentHave;


            service.Salvar(pokemon);

            var all = service.FindAll();
            Session["ListaPessoas"] = all;

            return View("Index", all);
        }

        public JsonResult buscarTipo()
        {
            var service = new PokemonTypeService();

            var tipos = service.FindAll();

            JsonResult result = Json(tipos, JsonRequestBehavior.AllowGet);

            return result;
        }


        [HttpPost]
        public void CadastrarPokemon(string Name, string ImagePath, int type)
        {

            var servicePokemon = new PokemonService();

            Pokemon pokemon = new Pokemon()
            {
                Name = Name,
                CurrentHave = false,
                ImagePath = ImagePath,
                PokemonTypeId = type
            };

            servicePokemon.Inserir(pokemon);

        }

    }
}