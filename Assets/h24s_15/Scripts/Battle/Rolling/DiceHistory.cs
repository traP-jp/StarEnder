using System.Collections.Generic;
using h24s_15.Battle.GUI;
using h24s_15.Utils;
using UnityEngine;

namespace h24s_15.Battle.Rolling {
    public class DiceHistory : SingletonMonoBehaviour<DiceHistory> {
        [SerializeField] private DiceHistoryUnit _unitPrefab;
        [SerializeField] private GameObject _contentParent;

        private List<DiceResultUnit> _history = new();

        public void AddHistory(DiceResultUnit result) {
            _history.Add(result);
        }
    }
}
