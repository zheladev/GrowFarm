using Godot;
using System;

public class Plot : Node2D
{
    enum PlotStates
    {
        dry,
        wet
    }

    GlobalVars g;
    EventSystem es;
    AnimatedSprite sprite;
    public Crop crop;
    private float waterLevel;
    private float drynessFactor;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _InitValues();
    }

    private void _InitValues()
    {
        g = GetNode<GlobalVars>("/root/GlobalVars");
        es = GetNode<EventSystem>("/root/EventSystem");
        sprite = GetNode<AnimatedSprite>("AnimatedSprite");
        crop = GetNode<Crop>("Crop");
        waterLevel = 0.0f;
        drynessFactor = 0.3f;
    }

    public void Step()
    {
        //grow crop if able and reduce water based on crop consumption
        float lostWaterValue = 1;
        float newWaterLevel = waterLevel - lostWaterValue;
        waterLevel = newWaterLevel >= 0.0f ? newWaterLevel : 0.0f;

        UpdateSprite();
    }

    public void UpdateSprite()
    {
        sprite.Animation = waterLevel == 0 ? nameof(PlotStates.dry) : nameof(PlotStates.wet);
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
            waterLevel += 10;
        }
        UpdateSprite();
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    // public override void _Process(float delta)
    // {
    // }
}
