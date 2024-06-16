using UnityEngine;

namespace h24s_15.Scenes.katsudon.edipancopy.scripts {
    public class RoleManager : MonoBehaviour {
        private Animator m_Animator = null;
        public GameObject dice1;
        public GameObject dice2;
        public GameObject dice3;
        public GameObject dice4;
        public GameObject dice5;

        private RoleStart ddice1;
        private RoleStart ddice2;
        private RoleStart ddice3;
        private RoleStart ddice4;
        private RoleStart ddice5;

        // Start is called before the first frame update
        private void Start() {
            m_Animator = GetComponent<Animator>();
            ddice1 = dice1.GetComponent<RoleStart>();
            ddice2 = dice2.GetComponent<RoleStart>();
            ddice3 = dice3.GetComponent<RoleStart>();
            ddice4 = dice4.GetComponent<RoleStart>();
            ddice5 = dice5.GetComponent<RoleStart>();
        }

        // Update is called once per frame
        private void Update() { }

        public void OnClick() {
            ddice1.Rolestart();
            ddice2.Rolestart();
            ddice3.Rolestart();
            ddice4.Rolestart();
            ddice5.Rolestart();
        }
    }
}
