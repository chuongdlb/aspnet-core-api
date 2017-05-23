using System.Collections.Generic;
using System.Linq;
using NetcoreMvc.EntityFrameworkCore;
using NetcoreMvc.EntityFrameworkCore.Entities;

namespace NetcoreMvc
{
    public static class CityInfoExtensions
    {
        public static void EnsureSeedDataForContext(this ApplicationContext context)
        {
            if (context.Cities.Any())
            {
                return;
            }
            var cities = new List<City>()
            {
                new City()
                {
                    Name = "New York",
                    Description = "New York City comprises 5 boroughs sitting where the Hudson River meets the Atlantic" +
                                  " Ocean. At its core is Manhattan, a densely populated borough that’s among the " +
                                  "world’s major commercial, financial and cultural centers. Its iconic sites include " +
                                  "skyscrapers such as the Empire State Building and sprawling Central Park. " +
                                  "Broadway theater is staged in neon-lit Times Square.",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Central Park",
                            Description = "A big park with a lot of trees. The most visited urban park in US."
                        },
                        new PointOfInterest()
                        {
                            Name = "Empire State Building",
                            Description = "A 102-story skyscrapper located in Midtown Manhattan."
                        }
                    }
                },
                new City()
                {
                    Name    = "Paris",
                    Description = "Paris, France's capital, is a major European city and a global center for art, " +
                                  "fashion, gastronomy and culture. Its 19th-century cityscape is crisscrossed by wide " +
                                  "boulevards and the River Seine. Beyond such landmarks as the Eiffel Tower and the " +
                                  "12th-century, Gothic Notre-Dame cathedral, the city is known for its cafe culture and " +
                                  "designer boutiques along the Rue du Faubourg Saint-Honoré.",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Eiffel Tower",
                            Description = "The Eiffel Tower is a wrought iron lattice tower on the Champ de Mars in Paris, " +
                                          "France. It is named after the engineer Gustave Eiffel, whose company designed " +
                                          "and built the tower. "
                        },
                        new PointOfInterest()
                        {
                            Name = "The Louvre",
                            Description = "The Louvre or the Louvre Museum is the world's largest museum and a historic " +
                                          "monument in Paris, France. A central landmark of the city, it is located on " +
                                          "the Right Bank of the Seine in the city's 1st arrondissement."
                        }
                    }
                    
                },
                new City()
                {
                    Name = "London", 
                    Description = "London, the capital of England and the United Kingdom, is a 21st-century city with" +
                                  " history stretching back to Roman times. At its centre stand the imposing " +
                                  "Houses of Parliament, the iconic ‘Big Ben’ clock tower and Westminster Abbey, " +
                                  "site of British monarch coronations. Across the Thames River, the London Eye observation " +
                                  "wheel provides panoramic views of the South Bank cultural complex, and the entire city.",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Big Ben",
                            Description = "Big Ben is the nickname for the Great Bell of the clock at the north end of " +
                                          "the Palace of Westminster in London and is usually extended to refer to both " +
                                          "the clock and the clock tower as well"
                        }
                    }
                },
                new City()
                {
                    Name = "Tokyo",
                    Description = "Tokyo, Japan’s busy capital, mixes the ultramodern and the traditional, from neon-lit" +
                                  " skyscrapers to historic temples. The opulent Meiji Shinto Shrine is known for" +
                                  " its towering gate and surrounding woods. The Imperial Palace sits amid large public gardens. " +
                                  "The city's many museums offer exhibits ranging from classical art " +
                                  "(in the Tokyo National Museum) to a reconstructed kabuki theater (in the Edo-Tokyo Museum).",
                    PointsOfInterest = new List<PointOfInterest>()
                    {
                        new PointOfInterest()
                        {
                            Name = "Tokyo Tower",
                            Description = "Tokyo Tower is a communications and observation tower in the Shiba-koen " +
                                          "district of Minato, Tokyo, Japan. At 332.9 metres, it is the second-tallest" +
                                          " structure in Japan."
                        }
                    }
                }
            };
            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}