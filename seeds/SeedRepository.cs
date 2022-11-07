using System.Collections.Generic;

public class SeedRepository
{

    public List<Seed> SeedList;


    public SeedRepository()
    {
        SeedList = new List<Seed>()
        {
            new Seed(Seed.S_TYPES.GREEN, 10.0f, 4),
        };
    }

    
}