using Godot;
using System;

public class SpellEditor : Node
{
    private ItemList itemList;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        itemList = FindNode("ItemList") as ItemList;
        itemList.AddItem("ItemName125", ResourceLoader.Load<Texture>("res://icon.png"));
        itemList.AddItem("ItemName3Sir", ResourceLoader.Load<Texture>("res://icon.png"));
        itemList.AddItem("ItemName3", ResourceLoader.Load<Texture>("res://icon.png"));
        itemList.Connect("item_selected", this, nameof(OnItemListSpellNodeSelected));
        Signals.SpellNodeSelectedEvent += OnSpellNodeSelected;
    }

    private void OnSpellNodeSelected(int index)
    {

        GD.Print($"SpellNode selected: Index: {index}, Value: {itemList.GetItemText(index)}");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

    }

    void OnItemListSpellNodeSelected(int index)
    {
        Signals.PublishSpellNodeSelectedEvent(index);
    }
}
