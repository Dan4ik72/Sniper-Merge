using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthView : MonoBehaviour
{
    [SerializeField] private SliderView _enemyHealthSlider;

    private EnemyHealthViewPresenter _enemyHealthViewPresenter;

    public void Init(IModelHealth model)
    {
        _enemyHealthViewPresenter = new EnemyHealthViewPresenter(_enemyHealthSlider, model);
        _enemyHealthViewPresenter.Init();
        _enemyHealthSlider.Init();
        _enemyHealthSlider.GetCanvas().enabled = false;
    }

    public void Disable()
    {
        _enemyHealthViewPresenter.Destroy();
    }
}
