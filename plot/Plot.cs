using Godot;
using System;

public class Plot : Node2D
{
    GlobalVars g;
    EventSystem es;

    enum PlotStates
    {
        dry,
        wet
    }
    AnimatedSprite Sprite;

    [Export]
    public PackedScene CropScene;
    private float WaterLevel;
    private float DrynessFactor;
    public Seed Seed;
    public Crop Crop;
    public bool IsCropPlanted;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _InitValues();
    }

    private void _InitValues()
    {
        g = GetNode<GlobalVars>("/root/GlobalVars");
        es = GetNode<EventSystem>("/root/EventSystem");
        Sprite = GetNode<AnimatedSprite>("AnimatedSprite");
        WaterLevel = 0.0f;
        DrynessFactor = 0.3f;
        IsCropPlanted = false;
    }

    private void _UpdateSprite()
    {
        string currAnim = WaterLevel == 0 ? nameof(PlotStates.dry) : nameof(PlotStates.wet);
        if (currAnim != Sprite.Animation)
        {
            Sprite.Animation = currAnim;
        }
    }

    public void OnPlotInputEvent(Node viewport, InputEvent e, int shape_idx)
    {
        if (e is InputEventMouseButton && e.IsPressed())
        {
            _HandleClickEvent();
        }
    }

    private void _HandleClickEvent()
    {
        if (g.IsWaterCanSelected) //switch with states to plant, till or water the plot.
        {
            WaterLevel += 5;
        }
        PlantSeed(0); //TODO: remove, debug
        _UpdateSprite();
    }

    public void PlantSeed(int seedIdx)
    {
        //TODO: ERROR PRONE. GetSeed may try to access an index out of bonds.
        var s = g.SeedRepository.GetSeed(seedIdx);
        if (IsCropPlanted) return;
        if (s == null) return;
        
        Seed = s;
        Crop c = CropScene.Instance<Crop>();
        c.Init(s.SpritePaths());
        Crop = c;
        AddChild(Crop);
        IsCropPlanted = true;
    }

    public void CollectCrop()
    {
        if (Seed == null) return;

        float moneyCollected = Seed.SellValue;

        Seed = null;
        Crop.QueueFree();
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        //grow crop if able and reduce water based on crop consumption
        float lostWaterValue = 1; // per second
        float newWaterLevel = WaterLevel - lostWaterValue * delta;
        WaterLevel = newWaterLevel >= 0.0f ? newWaterLevel : 0.0f;

        _UpdateSprite();
    }
}
