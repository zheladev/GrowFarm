using System.Collections.Generic;

public class SeedRepository
{

    public Dictionary<int, Seed> SeedList;


    public SeedRepository()
    {
        SeedList = new Dictionary<int, Seed>()
        {
            {(int) Seed.S_TYPES.GREEN, new Seed(Seed.S_TYPES.GREEN, 10.0f, 4)}
        };
    }

    #nullable enable
    public Seed? GetSeed(int idx)
    {
        return SeedList[idx];
    }
    #nullable disable
}