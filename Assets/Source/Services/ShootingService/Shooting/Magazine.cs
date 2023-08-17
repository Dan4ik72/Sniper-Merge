using VContainer;

internal class Magazine
{
    private int _allBullets;

    [Inject]
    internal Magazine()
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
