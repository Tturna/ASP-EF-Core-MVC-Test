using ASP_ER_Core_MVC_Test.Models;

namespace ASP_ER_Core_MVC_Test.Data;

public static class DbInitializer
{
    public static void Initialize(BobContext context)
    {
        // Skip populating the DB if it's already been seeded
        if (context.Bobs.Any())
        {
            return;   // DB has been seeded
        }
        
        var brains = new BrainModel[]
        {
            new() { ID = 1, BrainSize = BrainSize.Microscopic, BrainSmoothness = 0 },
            new() { ID = 2, BrainSize = BrainSize.Small, BrainSmoothness = 10 },
            new() { ID = 3, BrainSize = BrainSize.Medium, BrainSmoothness = 50 },
            new() { ID = 4, BrainSize = BrainSize.Big, BrainSmoothness = 80 }
        };
        
        foreach (var brain in brains)
        {
            context.Brains.Add(brain);
        }
        
        // Hits the database and saves the changes
        context.SaveChanges();

        var bobs = new BobModel[]
        {
            new() { Name = "Bob Alpha", BrainID = 1 },
            new() { Name = "Bob Beta", BrainID = 2 },
            new() { Name = "Bob Gamma", BrainID = 3 },
            new() { Name = "Bob Delta", BrainID = 4 }
        };
        
        foreach (var bob in bobs)
        {
            context.Bobs.Add(bob);
        }
        
        context.SaveChanges();
    }
}