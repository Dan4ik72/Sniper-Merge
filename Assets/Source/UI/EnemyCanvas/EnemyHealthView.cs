using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthView : MonoBehaviour
{
    [SerializeField] private TextView _maxHealthView;
    [SerializeField] private TextView _currentHealthView;
    [SerializeField] private SliderView _enemyHealthSlider;

    private EnemyHealthViewPresenter _enemyHealthViewPresenter;

    public void Init(IModelHealth model)
    {
        _enemyHealthViewPresenter = new EnemyHealthViewPresenter(_maxHealthView, _currentHealthView, _enemyHealthSlider, model);
        _enemyHealthViewPresenter.Init();
        _maxHealthView.Init();
        _currentHealthView.Init();
        _enemyHealthSlider.Init();
        _enemyHealthSlider.GetCanvas().enabled = false;
    }
}
