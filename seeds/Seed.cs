using Godot;
using System.Collections.Generic;

public class Seed
{
    static private Dictionary<S_TYPES, string> SpriteDirectories = new Dictionary<S_TYPES, string>()
    {
        { S_TYPES.GREEN, "green"},
        //TODO: add rest
    };

    static string PATH_PREFIX = "res://img/seeds/";
    public enum S_TYPES 
    {
        GREEN = 0,
        TYPE_1 = 1,
        TYPE_2 = 2,
    }
    
    public int Stages;
    public S_TYPES SeedType;
    public float WaterConsumption;
    public float GrowthRequired;
    public float SellValue;



    public Seed(S_TYPES seedType, float sellValue, float wConsumption, float gRequired, int stages)
    {
        Stages = stages;
        SeedType = seedType;
        SellValue = sellValue;
        WaterConsumption = wConsumption;
        GrowthRequired = gRequired;
    }

    private string _GetSpritePath()
    {
        return PATH_PREFIX + SpriteDirectories[SeedType];
    }

    public string[] SpritePaths()
    {
        string[] _paths = new string[Stages];
        for(int i = 0; i < Stages;i++)
        {
            _paths[i] = $"{_GetSpritePath()}/stage-{i}.png";
        }

        return _paths;
    }
}