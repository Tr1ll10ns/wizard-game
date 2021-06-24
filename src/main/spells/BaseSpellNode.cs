using Godot;
using System;
using System.Collections.Generic;

public class BaseSpellNode : Node
{
    private List<BaseSpellNode> outputConnections;
    private List<BaseSpellNode> inputConnections;
    private int manaCap = 0;
    private int mana = 0;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        outputConnections = new List<BaseSpellNode>();
        inputConnections = new List<BaseSpellNode>();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

    }

    // Connects two spell nodes.
    public void ConnectNodes(BaseSpellNode sender, BaseSpellNode receiver)
    {
        if (sender != receiver)
        {
            sender.outputConnections.Add(receiver);
            receiver.inputConnections.Add(sender);
        }
        else
        {

        }
    }

    // Disconnects two spell nodes.
    public void DisconnectNodes(BaseSpellNode node1, BaseSpellNode node2)
    {
        node1.outputConnections.Remove(node2);
        node1.inputConnections.Remove(node2);
        node2.outputConnections.Remove(node1);
        node2.inputConnections.Remove(node1);
    }

    public void OnInputChanged(object input, int index)
    {

    }
}
