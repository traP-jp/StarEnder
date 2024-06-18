using System;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace h24s_15.Battle.GUI {
    public class TurnEndButton : MonoBehaviour {
        private Button _button;
        private readonly Subject<Unit> _onClicked = new();
        public Observable<Unit> OnClicked => _onClicked;

        private void Awake() {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(() => { _onClicked.OnNext(Unit.Default); });
        }
    }
}
