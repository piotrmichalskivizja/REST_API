using ClassLibraryEntity.EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WykladWersjaKlasyczna.Models;

namespace WykladWersjaKlasyczna.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Person> Get()
        {
            Wyklad2025RestStacjonarneEntities1 entities1 =
                new Wyklad2025RestStacjonarneEntities1();

            var osobylyList = entities1.osoby.ToList();

            List<Person> results = new List<Person>();

            foreach (var o in osobylyList)
            {
                Person person = new Person()
                {
                    Id = o.id_osoby,
                    Name = o.imie,
                    Surname = o.nazwisko
                };
                results.Add(person);
            }

            return results;
        }

        // GET api/values/5
        public osoby Get(int id)
        {
            Wyklad2025RestStacjonarneEntities1 entities1 = new Wyklad2025RestStacjonarneEntities1();

            #region Wersja 1
            //List<osoby> wiersz = entities1.osoby.Where(x => x.id_osoby == id).ToList();

            //if (wiersz.Count == 0) { return null; }

            //return wiersz[0];
            #endregion

            #region Wersja 2
            //osoby wiersz = null;
            //try
            //{
            //    wiersz = entities1.osoby.Where(x => x.id_osoby == id).First();
            //}
            //catch (Exception)
            //{
            //}
            //return wiersz;

            #endregion

            #region Dodawanie rekordu
            //osoby o = new osoby()
            //{
            //    nazwisko = "Smith",
            //    imie = "John"
            //};

            //entities1.osoby.Add(o);

            //entities1.SaveChanges();
            #endregion

            #region Aktualizacja rekodu
            //List<osoby> results = entities1.osoby.ToList();
            //foreach (osoby o in results)
            //{
            //    o.imie += " 1";
            //}

            //entities1.SaveChanges();
            #endregion

            #region Usuwanie rekordu

            //List<osoby> rekord = entities1.osoby.Where(x => x.id_osoby == id).ToList();

            //if (rekord.Count == 0) { return null; }

            //entities1.osoby.Remove(rekord[0]);

            //entities1.SaveChanges();

            #endregion

            osoby wiersz = null;

            return wiersz;
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
