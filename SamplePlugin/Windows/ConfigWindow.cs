using System;
using System.Numerics;
using Dalamud.Interface.Windowing;
using ImGuiNET;

namespace SamplePlugin.Windows;

public class ConfigWindow : Window, IDisposable
{
    private Configuration Configuration;

    public ConfigWindow(Plugin plugin) : base("Retainer Notification Settings###RetainerConfig")
    {
        Flags = ImGuiWindowFlags.NoCollapse;
        SizeCondition = ImGuiCond.FirstUseEver; // Allow user resizing to persist

        Configuration = plugin.Configuration;
    }

    public void Dispose() { }

    public override void PreDraw()
    {
        if (Configuration.IsConfigWindowMovable)
        {
            Flags &= ~ImGuiWindowFlags.NoMove;
        }
        else
        {
            Flags |= ImGuiWindowFlags.NoMove;
        }
    }

    public override void Draw()
    {
        // Retainer 1 settings
        var retainer1Enabled = Configuration.Retainer1Enabled;
        if (ImGui.Checkbox("Enable Retainer 1", ref retainer1Enabled))
        {
            Configuration.Retainer1Enabled = retainer1Enabled;
            Configuration.Save();
        }

        ImGui.Indent();
        ImGui.Text("Notifications for:");

        ImGui.BeginDisabled(!retainer1Enabled);

        var ventures1 = Configuration.Retainer1Ventures;
        if (ImGui.Checkbox("Retainer 1's Ventures", ref ventures1))
        {
            Configuration.Retainer1Ventures = ventures1;
            Configuration.Save();
        }

        var eachSale1 = Configuration.Retainer1EachSale;
        if (ImGui.Checkbox("Each Sale by Retainer 1", ref eachSale1))
        {
            Configuration.Retainer1EachSale = eachSale1;
            Configuration.Save();
        }

        var holdingAmount1 = Configuration.Retainer1HoldingAmount;
        if (ImGui.Checkbox("Retainer 1's Holding Amount", ref holdingAmount1))
        {
            Configuration.Retainer1HoldingAmount = holdingAmount1;
            Configuration.Save();
        }

        if (holdingAmount1)
        {
            int holdingValue1 = Configuration.Retainer1HoldingAmountValue;
            if (ImGui.InputInt("Retainer 1's Holding Amount Value", ref holdingValue1))
            {
                holdingValue1 = Math.Clamp(holdingValue1, 0, 999999999); // Clamp to range 0 - 999,999,999
                Configuration.Retainer1HoldingAmountValue = holdingValue1;
                Configuration.Save();
            }
        }


        ImGui.EndDisabled();
        ImGui.Unindent();

        ImGui.Separator();

        // Retainer 2 settings
        var retainer2Enabled = Configuration.Retainer2Enabled;
        if (ImGui.Checkbox("Enable Retainer 2", ref retainer2Enabled))
        {
            Configuration.Retainer2Enabled = retainer2Enabled;
            Configuration.Save();
        }

        ImGui.Indent();
        ImGui.Text("Notifications for:");

        ImGui.BeginDisabled(!retainer2Enabled);

        var ventures2 = Configuration.Retainer2Ventures;
        if (ImGui.Checkbox("Retainer 2's Ventures", ref ventures2))
        {
            Configuration.Retainer2Ventures = ventures2;
            Configuration.Save();
        }

        var eachSale2 = Configuration.Retainer2EachSale;
        if (ImGui.Checkbox("Each Sale by Retainer 2", ref eachSale2))
        {
            Configuration.Retainer2EachSale = eachSale2;
            Configuration.Save();
        }

        var holdingAmount2 = Configuration.Retainer2HoldingAmount;
        if (ImGui.Checkbox("Retainer 2's Holding Amount", ref holdingAmount2))
        {
            Configuration.Retainer2HoldingAmount = holdingAmount2;
            Configuration.Save();
        }

        if (holdingAmount2)
        {
            int holdingValue2 = Configuration.Retainer2HoldingAmountValue;
            if (ImGui.InputInt("Retainer 2's Holding Amount Value", ref holdingValue2))
            {
                holdingValue2 = Math.Clamp(holdingValue2, 0, 999999999); // Clamp to range 0 - 999,999,999
                Configuration.Retainer2HoldingAmountValue = holdingValue2;
                Configuration.Save();
            }
        }

        ImGui.EndDisabled();
        ImGui.Unindent();
    }
}
