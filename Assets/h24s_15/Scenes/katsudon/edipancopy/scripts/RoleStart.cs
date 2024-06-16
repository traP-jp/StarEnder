using UnityEngine;

namespace h24s_15.Scenes.katsudon.edipancopy.scripts {
    public class RoleStart : MonoBehaviour {
        [SerializeField] private Animator m_Animator = null;
        private static readonly int Ispushed = Animator.StringToHash("ispushed");

        public void Rolestart() {
            Debug.Log(m_Animator);
            m_Animator.SetBool(Ispushed, true);
        }
    }
}
