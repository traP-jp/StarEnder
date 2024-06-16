using System;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace h24s_15.Battle.GUI {
    public class PlayerCharacterHp : MonoBehaviour {
        [SerializeField] private Slider _hpSlider;
        [SerializeField] private PlayerCharacter.PlayerCharacter _playerCharacter;

        private void Start() {
            if (_hpSlider == null) {
                Debug.LogError("HP Slider is not set.");
            }

            if (_playerCharacter == null) {
                Debug.LogError("Player Character is not set.");
            }

            _hpSlider.maxValue = _playerCharacter.CurrentMaxHp.CurrentValue;
            _hpSlider.value = _playerCharacter.CurrentHp.CurrentValue;

            _playerCharacter.CurrentHp.Subscribe(_ => { _hpSlider.value = _playerCharacter.CurrentHp.CurrentValue; })
                .AddTo(this);
        }
    }
}
