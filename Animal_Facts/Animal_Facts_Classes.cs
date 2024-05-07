using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Animal_Facts
{
    class Animal_Facts_Classes
    {
    }

    public class Animal
    {
        public string name { get; set; }
        public Taxonomy taxonomy { get; set; }
        public string[] locations { get; set; }

        public Characteristics characteristics { get; set; }

    }
    public class Taxonomy
    {
        public string Kingdom { get; set; } = null;
        public string Phylum { get; set; } = null;
        [JsonPropertyName("class")]
        public string Class { get; set; } = null;
        public string Order { get; set; } = null;
        public string Family { get; set; } = null;
        public string Genus { get; set; } = null;
        public string Scientific_name { get; set; } = null;

    }

    public class Characteristics
    {
        public string pray { get; set; } = null;
        public string name_of_young { get; set; } = null;
        public string group_behavior { get; set; } = null;

        public string estimated_population_size { get; set; } = null;

        public string biggest_threat { get; set; } = null;

        public string most_distinctive_feature { get; set; } = null;

        public string gestation_period { get; set; } = null;

        public string habitat { get; set; } = null;

        public string diet { get; set; } = null;

        public string average_litter_size { get; set; } = null;

        public string lifestyle { get; set; } = null;

        public string common_name { get; set; } = null;

        public string number_of_species { get; set; } = null;

        public string location { get; set; } = null;

        public string slogan { get; set; } = null;

        public string group { get; set; } = null;

        public string color { get; set; } = null;

        public string skin_type { get; set; } = null;

        public string top_speed { get; set; } = null;

        public string lifespan { get; set; } = null;

        public string weight { get; set; } = null;

        public string height { get; set; } = null;

        public string age_of_sexual_maturity { get; set; } = null;

        public string age_of_weaning { get; set; } = null;

        public string favorite_food { get; set; } = null;

        public string type { get; set; } = null;

        public string temperament { get; set;} = null;

        public string biggerst_threat { get; set; } = null;

        public string length { get; set; } = null;

        public string optimum_ph_level { get; set; } = null;

        public string migratory { get; set; } = null;
        public string wingspan { get; set; } = null;
        [JsonPropertyName("other_name(s)")]
        public string other_names { get; set; } = null;
        public string age_of_molting { get; set; } = null;
        public string nesting_location { get; set; } = null;

        public string water_type { get; set; } = null;
    }

    public class Recipe
    {
        public string title { get; set; }
        public string ingredients { get; set; }
        public string servings { get; set; }
        public string instructions { get; set; }
    }

    public class Cocktail
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("instructions")]
        public string Instructions { get; set; }
        [JsonPropertyName("ingredients")]
        public string[] Ingredients { get; set; }

    }

    public class Drinks
    {
        public List<Drink> drinks { get; set; } = new List<Drink>();
    }


    public class Drink
    {
        [JsonPropertyName("strDrink")]
        public string Name { get; set; }
        [JsonPropertyName("strGlass")]
        public string Glass_Type { get; set; }
        [JsonPropertyName("strInstructions")]
        public string Instructions { get; set; }
        [JsonPropertyName("strDrinkThumb")]
        public string Picture_link { get; set; }
        [JsonPropertyName("strIngredient1")]
        public string Ingredient_1 { get; set; }
        [JsonPropertyName("strIngredient2")]
        public string Ingredient_2 { get; set; }
        [JsonPropertyName("strIngredient3")]
        public string Ingredient_3 { get; set; }
        [JsonPropertyName("strIngredient4")]
        public string Ingredient_4 { get; set; }
        [JsonPropertyName("strIngredient5")]
        public string Ingredient_5 { get; set; }
        [JsonPropertyName("strIngredient6")]
        public string Ingredient_6 { get; set; }
        [JsonPropertyName("strIngredient7")]
        public string Ingredient_7 { get; set; }
        [JsonPropertyName("strIngredient8")]
        public string Ingredient_8 { get; set; }
        [JsonPropertyName("strIngredient9")]
        public string Ingredient_9 { get; set; }
        [JsonPropertyName("strIngredient10")]
        public string Ingredient_10 { get; set; }
        [JsonPropertyName("strIngredient11")]
        public string Ingredient_11 { get; set; }
        [JsonPropertyName("strIngredient12")]
        public string Ingredient_12 { get; set; }
        [JsonPropertyName("strIngredient13")]
        public string Ingredient_13 { get; set; }
        [JsonPropertyName("strIngredient14")]
        public string Ingredient_14 { get; set; }
        [JsonPropertyName("strIngredient15")]
        public string Ingredient_15 { get; set; }
        [JsonPropertyName("strMeasure1")]
        public string Measurement_1 { get; set; }
        [JsonPropertyName("strMeasure2")]
        public string Measurement_2 { get; set; }
        [JsonPropertyName("strMeasure3")]
        public string Measurement_3 { get; set; }
        [JsonPropertyName("strMeasure4")]
        public string Measurement_4 { get; set; }
        [JsonPropertyName("strMeasure5")]
        public string Measurement_5 { get; set; }
        [JsonPropertyName("strMeasure6")]
        public string Measurement_6 { get; set; }
        [JsonPropertyName("strMeasure7")]
        public string Measurement_7 { get; set; }
        [JsonPropertyName("strMeasure8")]
        public string Measurement_8 { get; set; }
        [JsonPropertyName("strMeasure9")]
        public string Measurement_9 { get; set; }
        [JsonPropertyName("strMeasure10")]
        public string Measurement_10 { get; set; }
        [JsonPropertyName("strMeasure11")]
        public string Measurement_11 { get; set; }
        [JsonPropertyName("strMeasure12")]
        public string Measurement_12 { get; set; }
        [JsonPropertyName("strMeasure13")]
        public string Measurement_13 { get; set; }
        [JsonPropertyName("strMeasure14")]
        public string Measurement_14 { get; set; }
        [JsonPropertyName("strMeasure15")]
        public string Measurement_15 { get; set; }


        public class Empty_
        {
            public string Name { get; set; } = "Nothig found";
            public string title { get; set; } = "Nothig found";
        }



    }
}
