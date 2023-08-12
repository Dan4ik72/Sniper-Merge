using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class EnemyView : MonoBehaviour
{
    private Enemy _enemy;

    public void Init(Enemy enemy) => _enemy = enemy;
}
