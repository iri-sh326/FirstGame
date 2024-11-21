using UnityEngine;

namespace FirstGame
{
    public class Grabable : MonoBehaviour
    {
        #region Variables
        private Collider m_Collider;
        #endregion

        private void Start()
        {
            m_Collider = GetComponent<Collider>();
        }

        void DoAction()
        {
            if (m_Collider != null)
            {

            }
        }
    }
}

