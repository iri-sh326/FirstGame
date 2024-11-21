using UnityEngine;

namespace FirstGame
{
    public class Breakable : MonoBehaviour
    {
        #region Variables
        public bool IsBroken { get; set; }
        #endregion

        private void Start()
        {
            IsBroken = false;
        }
    }
}

