using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

internal class EnemySetup
{
    private EnemyInfo _config;
    private Enemy _model;
    private EnemyView _view;

    [Inject]
    public EnemySetup(EnemyInfo info, Enemy model, EnemyView view)
    {
        _config = info;
        _model = model;
        _view = view;
    }

    public Enemy Model => _model;
    public EnemyView View => _view;
    public EnemyInfo Info => _config;
}
