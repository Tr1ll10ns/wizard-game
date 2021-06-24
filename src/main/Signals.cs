using Godot;
using System;

public static class Signals
{
    public static event Action<int> SpellNodeSelectedEvent;
    public static void PublishSpellNodeSelectedEvent(int spellNode) => SpellNodeSelectedEvent?.Invoke(spellNode);
}
