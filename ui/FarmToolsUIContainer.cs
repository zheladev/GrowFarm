using System;
using Godot;

public class FarmToolsUIContainer : Container
{
    GlobalVars g;
    EventSystem es;
    public override void _Ready()
    {
        _InitValues();
        _ConnectEvents();
    }

    private void _ConnectEvents()
    {
        es.Connect(nameof(EventSystem.E_NAMES.WaterCanToggled), this, "Print");
    }

    private void _InitValues()
    {
        g = GetNode<GlobalVars>("/root/GlobalVars");
        es = GetNode<EventSystem>("/root/EventSystem");
    }

    public void OnCanClicked(InputEvent e)
    {
        if (e is InputEventMouseButton && e.IsPressed())
        {
            es.EmitEvent(EventSystem.E_NAMES.WaterCanToggled);
        }
    }

    public void ToggleWatercan()
    {
        g.IsWaterCanSelected = !g.IsWaterCanSelected;
    }
}
