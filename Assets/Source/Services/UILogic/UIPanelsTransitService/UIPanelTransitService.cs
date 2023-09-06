using System.Collections.Generic;
using System.Linq;
using Codice.Client.BaseCommands;
using UnityEngine;
using VContainer;

public class UIPanelTransitService
{
    private static IReadOnlyList<IUiPanel> _allUiPanels;

    [Inject]
    public UIPanelTransitService(IReadOnlyList<IUiPanel> allUiPanels)
    {
        _allUiPanels = allUiPanels;
    }
    
    public static void SetUiPanelActivity<T>(bool isActive) where T : IUiPanel
    {
        var panel = _allUiPanels.FirstOrDefault(panel => panel.GetType() == typeof(T));

        if (panel == null)
        {
            Debug.LogWarning("There is no such a ui panel : " + typeof(T));
            return;
        }

        panel.GetCanvas().enabled = isActive;
    }

    public static bool TryGetUiPanelByType<T>(out T panel) where T : IUiPanel
    {
        panel = default;
        
        var firstOrDefault = _allUiPanels.FirstOrDefault(panel => panel.GetType() == typeof(T));

        if (firstOrDefault == null)
            return false;

        panel = (T)firstOrDefault;

        return true;
    }
}
