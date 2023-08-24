using UnityEngine;

internal class BulletViewFactory
{
    private Transform _spawnPoint;

    private BulletViewFactory(Transform spawnPoint)
    {
        _spawnPoint = spawnPoint;
    }

    public BulletView CreateBulletView(BulletInfo bulletInfo)
    {
        return CreateInternal(bulletInfo.BulletViewPrefab, _spawnPoint.transform.position, _spawnPoint.transform);
    }

    private BulletView CreateInternal(BulletView prefab, Vector3 position, Transform parent)
    {
        return Object.Instantiate(prefab, position, Quaternion.identity, parent);
    } 
}
