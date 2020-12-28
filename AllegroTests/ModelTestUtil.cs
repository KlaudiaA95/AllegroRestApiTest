using System.Collections.Generic;

namespace AllegroTests
{
    //Just for showcase purposes.
    //This kind of data should be taken from one source of truth for example company business rules engine/database
    public class ModelTestUtil
    {
        public static Dictionary<string, string> GetCategoriesDictionary()
        {
            Dictionary<string, string> predefinedIdToCategoryMappings = new Dictionary<string, string>()
            {
                {"5","Dom i Ogród"},
                {"11763", "Dziecko"},
                {"42540aec-367a-4e5e-b411-17c09b08e41f", "Elektronika"},
                {"4bd97d96-f0ff-46cb-a52c-2992bd972bb1", "Firma i usługi"},
                {"a408e75a-cede-4587-8526-54e9be600d9f", "Kolekcje i sztuka"},
                {"38d588fd-7e9c-4c42-a4ae-6831775eca45", "Kultura i rozrywka"},
                {"ea5b98dd-4b6f-4bd0-8c80-22c2629132d0", "Moda"},
                {"3", "Motoryzacja"},
                {"20782", "Nieruchomości"},
                {"3919", "Sport i turystyka"},
                {"258832", "Supermarket"},
                {"1429", "Uroda"},
                {"121882", "Zdrowie"}
            };
            return predefinedIdToCategoryMappings;
        }

        public static Dictionary<string, string> GetCategoriesForParentDictionary()
        {
            Dictionary<string, string> predefinedIdToCategoryMappings = new Dictionary<string, string>()
            {
                { "300881", "Bilety" },
                { "20585", "Filmy" },
                { "306453", "Gadżety" },
                { "9", "Gry" },
                { "122640", "Instrumenty" },
                { "257900", "Kody i doładowania" },
                { "7", "Książki i Komiksy" },
                { "1", "Muzyka" },
                { "301130", "Wyjątkowe chwile" },
            };
            return predefinedIdToCategoryMappings;
        }
    }
}