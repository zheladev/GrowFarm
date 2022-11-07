using Godot;
using System;

//Dumb scene, doesn't know anything other than which sprite to render.
public class Crop : Node2D
{
    private string[] Sprites;
    private int CurrentSprite;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    public void Init(string[] sprites)
    {
        Sprites = sprites;
        CurrentSprite = 0;
        //TODO: set sprite
    }

    public void AdvanceSprite()
    {
        if (CurrentSprite < Sprites.Length - 1) CurrentSprite++;
        //TODO: set sprite
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
