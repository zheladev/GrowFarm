using Godot;
using System;
using System.Collections.Generic;

public class PlotGrid : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export]
    public int plotNumber;
    private PackedScene plotScene;
    public List<Plot> plots;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _InitValues();

        for (int i = 0; i < plotNumber; i++)
        {
            Plot plot = plotScene.Instance<Plot>();
            AddChild(plot);
            plots.Add(plot);
        }

        _DrawPlots();
    }

    private void _DrawPlots()
    {
        int _plotPxSize = 64;
        int _minPerfectSquare = Mathf.CeilToInt(Mathf.Sqrt(plots.Count));
        //if even, 32 to properly center the grid
        int _defaultOffset = _minPerfectSquare % 2 == 0 ? _plotPxSize / 2 : 0;
        int _minOffset = _minPerfectSquare / 2 * _plotPxSize * -1;

        for (int i = 0; i < plots.Count; i++)
        {
            int _col = i % _minPerfectSquare;
            int _row = i / _minPerfectSquare;

            Vector2 pos = new Vector2(_minOffset + (_col * _plotPxSize) + _defaultOffset, 
                                        _minOffset + (_row * _plotPxSize) + _defaultOffset);
            plots[i].Position = pos;
        }
    }

    private void _InitValues()
    {
        plotScene = ResourceLoader.Load<PackedScene>("res://Plot.tscn");
        plots = new List<Plot>();
    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
    public void OnPlotTimerTimeout() 
    {
        foreach(Plot _plot in plots)
        {
            _plot.Step();
        }
    }
}
