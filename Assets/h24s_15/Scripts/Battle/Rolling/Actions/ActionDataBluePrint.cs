using System;
using System.Collections.Generic;
using UnityEngine;

namespace h24s_15.Battle.Rolling.Actions {
    [Serializable]
    public record ActionData : IActionData {
        [Tooltip("単発の攻撃の値")] [SerializeField]
        private int _singleAttackValue;

        [Tooltip("単発のシールドの値")] [SerializeField]
        private int _singleShieldValue;

        [Tooltip("次ターン移行の毎ターンの攻撃の値")] [SerializeField]
        private int _consecutiveAttackValue;

        [Tooltip("毎ターン攻撃の継続ターン数")] [SerializeField]
        private int _consecutiveAttackTurns;

        [Tooltip("次ターン移行の毎ターンのシールドの値")] [SerializeField]
        private int _consecutiveShieldValue;

        [Tooltip("毎ターンシールドの継続ターン数")] [SerializeField]
        private int _consecutiveShieldTurns;

        [Tooltip("単発の特殊効果")] [SerializeField]
        private SpecialEffectTypes _singleSpecialEffect;

        public int SingleAttackValue => _singleAttackValue;
        public int SingleShieldValue => _singleShieldValue;
        public int ConsecutiveAttackValue => _consecutiveAttackValue;
        public int ConsecutiveAttackTurns => _consecutiveAttackTurns;
        public int ConsecutiveShieldValue => _consecutiveShieldValue;
        public int ConsecutiveShieldTurns => _consecutiveShieldTurns;
        public SpecialEffectTypes SingleSpecialEffect => _singleSpecialEffect;

        public ActionData(int singleAttackValue, int singleShieldValue, int consecutiveAttackValue,
            int consecutiveAttackTurns, int consecutiveShieldValue, int consecutiveShieldTurns,
            SpecialEffectTypes singleSpecialEffect) {
            _singleAttackValue = singleAttackValue;
            _singleShieldValue = singleShieldValue;
            _consecutiveAttackValue = consecutiveAttackValue;
            _consecutiveAttackTurns = consecutiveAttackTurns;
            _consecutiveShieldValue = consecutiveShieldValue;
            _consecutiveShieldTurns = consecutiveShieldTurns;
            _singleSpecialEffect = singleSpecialEffect;
        }

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

        public IActionData ApplyRoleInfo(Role role) {
            var roleMultiplier = RoleInfoManager.Instance.CurrentRoleMultipliers.GetMultiplier(role);
            _singleAttackValue *= roleMultiplier;
            _singleShieldValue *= roleMultiplier;
            _consecutiveAttackValue *= roleMultiplier;
            _consecutiveShieldValue *= roleMultiplier;
            return this;
        }
    }

    [CreateAssetMenu(menuName = "h24s_15/Battle/Actions/ActionDataBluePrint")]
    public class ActionDataBluePrint : ScriptableObject {
        [SerializeField] private ActionData _actionData;

        public int SingleAttackValue => _actionData.SingleAttackValue;
        public int SingleShieldValue => _actionData.SingleShieldValue;
        public int ConsecutiveAttackValue => _actionData.ConsecutiveAttackValue;
        public int ConsecutiveAttackTurns => _actionData.ConsecutiveAttackTurns;
        public int ConsecutiveShieldValue => _actionData.ConsecutiveShieldValue;
        public int ConsecutiveShieldTurns => _actionData.ConsecutiveShieldTurns;
        public SpecialEffectTypes SingleSpecialEffect => _actionData.SingleSpecialEffect;

        public IReadOnlyList<ActionTypes> GetActionTypes() {
            return _actionData.GetActionTypes();
        }

        public int GetActionValue(ActionTypes actionType) {
            return _actionData.GetActionValue(actionType);
        }
    }
}
