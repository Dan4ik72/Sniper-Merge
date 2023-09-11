using System.Collections.Generic;
using VContainer;

public class UIBootstrapService
{
    private IReadOnlyList<IUiPanel> _allPanels;

    [Inject]
    public UIBootstrapService(IReadOnlyList<IUiPanel> panels)
    {
        _allPanels = panels;
    }

    public IReadOnlyList<IUiPanel> AllPanels => _allPanels;
    
    public void Init()
    {
        foreach (var panel in _allPanels)
            panel.Init();
    }

    public void Disable()
    {
        foreach(var panel in _allPanels)
            panel.Disable();
    }
}
