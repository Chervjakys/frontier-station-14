﻿using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.XAML;

namespace Content.Client._NF.LateJoin.ListItems;

[GenerateTypedNameReferences]
public sealed partial class StationListItem : PanelContainer
{
    public sealed class ViewState(
        NetEntity stationEntity,
        string stationName,
        string stationSubtext,
        string stationDescription,
        bool selected,
        string? iconPath)
    {
        public string StationName { get; } = stationName;
        public string StationSubtext { get; } = stationSubtext;
        public string StationDescription { get; } = stationDescription;
        public NetEntity StationEntity { get; } = stationEntity;

        public bool Selected { get; set; } = selected;

        public string IconPath { get; } = iconPath ?? "";
    }

    public StationListItem(ViewState state)
    {
        RobustXamlLoader.Load(this);

        StationName.Text = state.StationName;
        StationSubtext.Text = state.StationSubtext;

        // Disallow repeated selection of same station that does UI reloads.
        StationButton.Disabled = state.Selected;

        if (state.IconPath.Length > 0)
        {
            StationIcon.TexturePath = state.IconPath;
        }
    }
}