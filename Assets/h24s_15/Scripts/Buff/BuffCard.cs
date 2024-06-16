using TMPro;
using UnityEngine;

namespace h24s_15.Buff {
    public class BuffCard : MonoBehaviour {
        [SerializeField] private BuffData _buffData;
        [SerializeField] private TMP_Text _descriptionText;

        public BuffData BuffData => _buffData;
        public TMP_Text DescriptionText => _descriptionText;

        public void AssignBuffData(BuffData data) {
            _buffData = data;
            _descriptionText.text = data.GetDescription();
        }

        public void OnClick() {
            BuffSelectManager.Instance.ApplyBuffData(_buffData);
        }
    }
}
