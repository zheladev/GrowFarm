using Godot;
using System;
using System.Collections.Generic;

public class Main : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    public Vector2 screenCenter;

    private PlotGrid plotGrid;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        InitValues();
        plotGrid.Position = screenCenter;
    }

    private void InitValues() 
    {
        plotGrid = GetNode<PlotGrid>("PlotGrid");
        Vector2 screen = GetViewportRect().Size;
        screenCenter = screen / 2;
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
