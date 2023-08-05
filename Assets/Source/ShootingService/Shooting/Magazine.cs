using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

internal class Magazine
{
    private int _allBullets;

    [Inject]
    public Magazine()
    {
        _allBullets = 20;
    }

    public bool IsLoaded => _allBullets > 0;

    public void ReceiveBullet(/*BulletType bulletType*/)
    {
        _allBullets++;
    }

    public int GiveBullet()
    {
        _allBullets--;
        return 1;
        //return damage;
    }
}
