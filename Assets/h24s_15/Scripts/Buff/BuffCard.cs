using R3;
using TMPro;
using UnityEngine;

namespace h24s_15.Buff {
    public class BuffCard : MonoBehaviour {
        [SerializeField] private BuffData _buffData;
        [SerializeField] private TMP_Text _descriptionText;

        private readonly Subject<Unit> _onClick = new();
        public Observable<Unit> OnClickObservable => _onClick;

        public BuffData BuffData => _buffData;
        public TMP_Text DescriptionText => _descriptionText;

        public void AssignBuffData(BuffData data) {
            _buffData = data;
            _descriptionText.text = data.GetDescription();
        }

        public void OnClick() {
            _onClick.OnNext(Unit.Default);
        }
    }
}
