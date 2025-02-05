using Dalamud.Configuration;
using System;
using System.Runtime.Serialization;
using Dalamud.Plugin;

public class Configuration : IPluginConfiguration
{
    public int Version { get; set; } = 1;

    public bool IsConfigWindowMovable { get; set; } = false;

    public bool Retainer1Enabled { get; set; } = false;
    public bool Retainer1Ventures { get; set; } = false;
    public bool Retainer1EachSale { get; set; } = false;
    public bool Retainer1HoldingAmount { get; set; } = false;
    public int Retainer1HoldingAmountValue { get; set; } = 0;

    public bool Retainer2Enabled { get; set; } = false;
    public bool Retainer2Ventures { get; set; } = false;
    public bool Retainer2EachSale { get; set; } = false;
    public bool Retainer2HoldingAmount { get; set; } = false;
    public int Retainer2HoldingAmountValue { get; set; } = 0;

    [NonSerialized]
    private IDalamudPluginInterface? pluginInterface;

    public void Initialize(IDalamudPluginInterface pluginInterface)
    {
        this.pluginInterface = pluginInterface;
    }

    public void Save()
    {
        pluginInterface?.SavePluginConfig(this);
    }
}
