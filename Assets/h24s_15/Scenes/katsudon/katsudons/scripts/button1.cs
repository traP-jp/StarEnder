using System;
using Cysharp.Threading.Tasks;
using h24s_15.Buff;
using UnityEngine;

namespace h24s_15.Scenes.katsudon.katsudons.scripts {
    public class button1 : MonoBehaviour {
        public BuffData buffData;

        private afterbutton NextKanri;

        private bool supagethiF;

        // Start is called before the first frame update
        private void Start() {
            NextKanri = GameObject.Find("NextKanri").GetComponent<afterbutton>();
        }

        // Update is called once per frame
        private void Update() {
            if (supagethiF) {
                transform.position = Vector3.MoveTowards(transform.position, new Vector2(0, +0), 3);
            }
        }

        public async void OnClick() {
            if (NextKanri.buttonF == 0) {
                Debug.Log("一個目（左のやつ）が押されたよ"); // ログを出力
                NextKanri.buttonF = 1;
                NextKanri.downmove(GameObject.Find("Button2"));
                NextKanri.downmove(GameObject.Find("Button3"));
                gameObject.transform.localScale = Vector3.one;
                Invoke(nameof(MigiMove), 1.0f);

                await UniTask.Delay(TimeSpan.FromSeconds(1.0f));

                BuffSelectManager.Instance.ApplyBuffData(buffData);
            }
        }

        public void AssignBuffData(BuffData data) {
            buffData = data;
        }

        public void Checkappear1() {
            NextKanri.Checkappear();
        }

        public void MigiMove() {
            supagethiF = true;
        }

        public void OnMouseOver() {
            if (NextKanri.buttonF == 0) {
                gameObject.transform.localScale = Vector3.one * 1.1f;
            }
        }

        public void OnMouseExit() {
            gameObject.transform.localScale = Vector3.one;
        }
    }
}
