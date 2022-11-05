using Godot;
using System;

public class FarmToolsUIContainer : Container
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void OnCanClicked(InputEvent e)
    {
        if (e is InputEventMouseButton && e.IsPressed())
        {
            GD.Print("lol");
        }
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
