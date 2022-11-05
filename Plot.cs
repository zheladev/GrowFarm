using Godot;
using System;

public class Plot : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    public Crop crop;
    private float waterLevel;
    private float drynessFactor;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        crop = GetNode<Crop>("Crop");
        waterLevel = 0.0f;
        drynessFactor = 0.3f;
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        //water lost per second
        float lostWaterValue = drynessFactor/1000 * delta;
        float newWaterLevel = waterLevel - lostWaterValue;
        waterLevel = newWaterLevel >= 0.0f ? newWaterLevel : 0.0f;
    }
}
