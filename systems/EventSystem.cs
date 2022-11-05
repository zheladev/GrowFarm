using Godot;
using System;
using System.Collections.Generic;

public class EventSystem : Node2D
{
    public enum E_NAMES 
    {
        WaterCanToggled, //name is relevant, has to match a delegate.
    }

    public E_NAMES EVENT_NAMES { get; private set; }

    [Signal]
    public delegate void WaterCanToggled();

    public void EmitEvent(E_NAMES e, params object[] args)
    {
        string sig = "";

        switch (e)
        {
            case E_NAMES.WaterCanToggled: 
                sig = nameof(WaterCanToggled);
                break;
            default:
                return;
        }
        EmitSignal(sig, args);
    }
}
