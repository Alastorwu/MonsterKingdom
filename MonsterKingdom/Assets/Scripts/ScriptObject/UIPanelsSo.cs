using System.Collections.Generic;
using Game.Common;
using UI;
using UnityEngine;

[CreateAssetMenu(fileName = "UIPanel",menuName = "UI/UIPanels")]
public class UIPanelsSo : ScriptableObject
{
    public List<UIPanelBase> uIPanels;
}
