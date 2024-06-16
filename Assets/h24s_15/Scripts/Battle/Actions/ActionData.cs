using System.Collections.Generic;
using UnityEngine;

namespace h24s_15.Battle.Actions {
    [CreateAssetMenu(menuName = "h24s_15/Battle/Actions/ActionData")]
    public class ActionData : ScriptableObject, IActionData {
        [Tooltip("単発の攻撃の値")] [SerializeField]
        private int _singleAttackValue = 0;

        [Tooltip("単発のシールドの値")] [SerializeField]
        private int _singleShieldValue = 0;

        [Tooltip("次ターン移行の毎ターンの攻撃の値")] [SerializeField]
        private int _consecutiveAttackValue = 0;

        [Tooltip("毎ターン攻撃の継続ターン数")] [SerializeField]
        private int _consecutiveAttackTurns = 0;

        [Tooltip("次ターン移行の毎ターンのシールドの値")] [SerializeField]
        private int _consecutiveShieldValue = 0;

        [Tooltip("毎ターンシールドの継続ターン数")] [SerializeField]
        private int _consecutiveShieldTurns = 0;

        [Tooltip("単発の特殊効果")] [SerializeField]
        private SpecialEffectTypes _singleSpecialEffect = SpecialEffectTypes.None;

        public int SingleAttackValue => _singleAttackValue;
        public int SingleShieldValue => _singleShieldValue;
        public int ConsecutiveAttackValue => _consecutiveAttackValue;
        public int ConsecutiveAttackTurns => _consecutiveAttackTurns;
        public int ConsecutiveShieldValue => _consecutiveShieldValue;
        public int ConsecutiveShieldTurns => _consecutiveShieldTurns;
        public SpecialEffectTypes SingleSpecialEffect => _singleSpecialEffect;

        public IReadOnlyList<ActionTypes> GetActionTypes() {
            var actionTypes = new List<ActionTypes>();

            if (_singleAttackValue > 0) {
                actionTypes.Add(ActionTypes.Attack);
            }

            if (_singleShieldValue > 0) {
                actionTypes.Add(ActionTypes.Shield);
            }

            if (_singleSpecialEffect is not SpecialEffectTypes.None) {
                actionTypes.Add(ActionTypes.Special);
            }

            return actionTypes;
        }

        public int GetActionValue(ActionTypes actionType) {
            return actionType switch {
                ActionTypes.Attack => _singleAttackValue,
                ActionTypes.Shield => _singleShieldValue,
                ActionTypes.Special => 0,
                _ => 0
            };
        }
    }
}
