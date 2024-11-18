using UnityEngine;

namespace FirstGame
{
    public class PlayerAction : MonoBehaviour
    {
        #region Variables
        public Transform player;
        [SerializeField] private float distance;

        RaycastHit hit;
        #endregion

        private void Start()
        {
            
        }

        private void Update()
        {
            distance = PlayerCasting.distanceFromTarget;
            GrabToObject();
            BreakToObject();
        }

        private void GrabToObject()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("GrabToObject");
                Grab();
            }
        }

        private void BreakToObject()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("BreakToObject");
                Break();
            }
        }

        private void Grab()
        {
            Debug.Log("Grab");
        }

        private void Break()
        {
            Debug.Log("Break");
        }
    }
}

