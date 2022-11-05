using Godot;
using System;
using System.Collections.Generic;

public class PlotGrid : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private PackedScene plotScene;
    public List<Plot> plots;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        InitValues();
        Plot plot = plotScene.Instance<Plot>();

        for(int i = 0; i < 9;i++) {
            AddChild(plot);
            plots.Add(plot);
        }
    }

    private void InitValues() 
    {
        plotScene = ResourceLoader.Load<PackedScene>("res://Plot.tscn");
        plots = new List<Plot>();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
