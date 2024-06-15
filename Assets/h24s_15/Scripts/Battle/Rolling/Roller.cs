using UnityEngine;

namespace h24s_15.Battle.Rolling {
    public class Roller : MonoBehaviour {
        [SerializeField] private DiceSet _diceSet;

        public void RollAll() {
            var result = _diceSet.Roll();
            var role = RollingUtils.EvaluateRole(result);

            Debug.Log($"ダイスを5個振って「{string.Join(", ", result)}」が出ました。役は「{role.ToJapaneseText()}」です。");
        }
    }
}
