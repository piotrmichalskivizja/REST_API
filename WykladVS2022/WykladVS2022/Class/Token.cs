namespace WykladVS2022.Class
{
    public class Token
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public DateTime DataWaznosciTokenu { get; set; }

        public int Id { get; set; }

        public string WygenerujToken()
        {
            //Poddajemu nasz obiekt serializacji
            //Poddajemy szyfrowaniu
            //zamieniamu na string

            return "fasndjfmioamc isdjmaimi4jm34moifmoimdsafvjoemv";
        }

        public static Token OdczytajToken(string token)
        {
            //deszyfrujemy
            //deserializujemy 
            //zwracamy obiekt

            return new Token
            {
                Imie = "Jan",
                Nazwisko = "Kowalski",
                DataWaznosciTokenu = DateTime.Now,
                Id = 1
            };
        }
    }
}
