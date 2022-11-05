using Godot;
using System;

public class GlobalVars : Node2D
{
    //public int selectedTool;
    // -1 nothing selected, 0 watering can, 2 hoe, etc
    public Boolean IsWaterCanSelected;
    public override void _Ready()
    {
        _InitValues();
    }

    private void _InitValues()
    {
        IsWaterCanSelected = false;
    }
}
