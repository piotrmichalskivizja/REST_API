using ClassLibraryEntity.EntityModel;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;
using System.Text.Json;
using System.Xml.Serialization;
using WykladVS2022.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WykladVS2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            #region Operacje plikowe
            //string fileNameXML = "dane.xml";
            //string fileNameJson = "dane.json";

            //List<Person>? results = new List<Person>();

            //XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));

            //#region Wersja 1 z TRY
            ////using (TextReader reader = new StreamReader(fileName))
            ////{
            ////    try
            ////    {
            ////        results = (List<Person>)serializer.Deserialize(reader);
            ////    }
            ////    catch (Exception)
            ////    {
            ////        throw;
            ////    }
            ////}
            //#endregion

            //#region Wersja 2 z AS
            ////using (TextReader reader = new StreamReader(fileName))
            ////{
            ////    object o = serializer.Deserialize(reader);

            ////    results = o as List<Person>;
            ////}
            //#endregion

            //#region Wersja 3 z AS + TRY
            ////using (TextReader reader = new StreamReader(fileName))
            ////{
            ////    object? o;
            ////    try
            ////    {
            ////        o = serializer.Deserialize(reader);
            ////    }
            ////    catch (Exception)
            ////    {
            ////        throw;
            ////    }

            ////    results = o as List<Person>;
            ////}
            //#endregion

            //#region Wersja 4 - po przeniesieniu odczytu do metody
            ////results = ReadPersonFromXML(fileNameXML);
            //#endregion

            //#region Wersja 5 - Json
            //results = ReadPersonFromJSON(fileNameJson);
            //#endregion

            ////reader.Close(); // Ponieważ użyto "using"

            #endregion


            Wyklad2025RestStacjonarneEntities1 entities1 =
                new Wyklad2025RestStacjonarneEntities1();

            DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);


            var osobylyList = entities1.osoby.ToList();

            List<Person>? results = new List<Person>();

            foreach (var o in osobylyList)
            {
                Person person = new Person()
                {
                    Id = o.id_osoby,
                    Name = o.imie,
                    Surname = o.nazwisko
                };
            }

            return results;

            //return new Person[] {
            //    new Person { Id = 1, Name = "Jan", Surname= "Kowalski" },
            //    new Person { Id = 2, Name = "Stanisław", Surname = "Nowaka" }
            //    };
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            string fileNameJson = "dane.json";
            List<Person>? results = ReadPersonFromJSON(fileNameJson);
            Person returnValue = null;

            #region Forma "dawna" - ale ok
            //for (int i = 0; i < results.Count; i++)
            //{
            //    if (results[i].Id == id)
            //    {
            //        returnValue = results[i];
            //        break;
            //    }
            //}
            #endregion

            #region Forma współczena - optymalna

            returnValue = results.Where(p => p.Id == id).First();
            
            #endregion

            return returnValue;
        }

        // POST api/<PersonController>
        [HttpPost]
        public void Post([FromBody] List<Person> list)
        {
            string fileNameXML = "dane.xml";
            string fileNameJson = "dane.json";
            

            //List<Person> persons = ReadPersonFromXML(fileNameXML);
            List<Person> persons = ReadPersonFromJSON(fileNameJson);

            foreach (Person person in list) 
            {
                persons.Add(person);
            }
            
            //WritePersonToXML(fileNameXML, persons);
            WritePersonToJson(fileNameJson, persons);
            
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            /*
             * Aktualizacja tylko wybranych pól - tych które się zmieniły
             * - zwiększone obciążenie obliczeniowe => musimy sprawdzić które pola się 
             *      zmieniły
             * + zmiejszenie ilości danych przesyłanych przez sieć
             *      
             * Aktualizacja całego obiektu - wzięcie nowego
             * + Zmiejszone obciążenie obliczeniowe => nie musimy sprawdzić które pola się 
             *      zmieniły
             * - Zwiększenie ilości danych przesyłanych przez sieć
             */
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private List<Person> ReadPersonFromXML(string fileName)
        {
            List<Person> results = new List<Person>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));

            using (TextReader reader = new StreamReader(fileName))
            {
                object? o;
                try
                {
                    o = serializer.Deserialize(reader);
                }
                catch (Exception)
                {
                    throw;
                }
                
                results = o as List<Person>;
            }
            return results;
        }

        private void WritePersonToXML(string fileName, List<Person> list)
        {
            XmlSerializer serializer = new XmlSerializer (typeof(List<Person>));
            using(TextWriter writer = new StreamWriter(fileName))
            {
                try
                {
                    serializer.Serialize(writer, list);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private void WritePersonToJson(string fileName, List<Person> list)
        {
            using(TextWriter writer = new StreamWriter(fileName))
            {
                try
                {
                    string jsonText = JsonSerializer.Serialize(list);
                    writer.Write(jsonText);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private List<Person> ReadPersonFromJSON(string fileName)
        {
            List<Person>? results = new List<Person>();
            string jsonText = System.IO.File.ReadAllText(fileName);

            using (TextReader reader = new StreamReader(fileName))
            {
                try
                {
                    results = JsonSerializer.Deserialize<List<Person>>(jsonText);
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return results;
        }
    }
}
