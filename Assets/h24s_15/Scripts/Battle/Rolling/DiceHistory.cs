using System.Collections.Generic;
using h24s_15.Battle.GUI;
using h24s_15.Battle.TurnBattleSystem;
using h24s_15.Utils;
using UnityEngine;

namespace h24s_15.Battle.Rolling {
    public class DiceHistory : SingletonMonoBehaviour<DiceHistory> {
        [SerializeField] private DiceHistoryUnit _unitPrefab;
        [SerializeField] private GameObject _contentParent;

        private readonly List<DiceResultUnit> _history = new();
        private readonly List<DiceHistoryUnit> _units = new();

        public IReadOnlyList<DiceResultUnit> History => _history;
        public IReadOnlyList<DiceHistoryUnit> Units => _units;

        protected override void Awake() {
            base.Awake();

            TurnBattleManager.Instance.Data.DiceHistory = this;

            foreach (var child in _contentParent.transform) {
                Destroy(((Transform)child).gameObject);
            }
        }

        public void AddHistory(DiceResultUnit result) {
            _history.Add(result);

            var unit = Instantiate(_unitPrefab, _contentParent.transform);
            unit.Initialize(result);
            _units.Add(unit);

            Debug.Log($"History added: {result.Role}");
        }

        public void ClearHistory() {
            foreach (Transform child in _contentParent.transform) {
                Destroy(child.gameObject);
            }

            _history.Clear();
        }
    }
}
