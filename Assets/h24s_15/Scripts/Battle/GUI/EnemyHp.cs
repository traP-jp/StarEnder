using R3;
using UnityEngine;

namespace h24s_15.Battle.GUI {
    public class EnemyHp : MonoBehaviour {
        [SerializeField] private Enemy.NormalEnemy _enemy;
        [SerializeField] private UnityEngine.UI.Slider _hpSlider;

        private void Start() {
            if (_hpSlider == null) {
                Debug.LogError("HP Slider is not set.");
            }

            if (_enemy == null) {
                Debug.LogError("Enemy is not set.");
            }

            _hpSlider.maxValue = _enemy.CurrentMaxHp.CurrentValue;
            _hpSlider.value = _enemy.CurrentHp.CurrentValue;

            _enemy.CurrentHp.Subscribe(_ => { _hpSlider.value = _enemy.CurrentHp.CurrentValue; }).AddTo(this);
        }
    }
}
