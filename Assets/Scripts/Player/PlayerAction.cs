using UnityEngine;

namespace FirstGame
{
    public class PlayerAction : MonoBehaviour
    {
        #region Variables
        //
        public Transform player;
        public Transform grabPosition;
        private PlayerCasting playerCasting;

        // 거리
        [SerializeField] private float distance;
        [SerializeField] private float grabableDistance = 5f;
        [SerializeField] private float breakableDistance = 5f;

        //
        [SerializeField] private bool isGrab = false;
        private bool currentIsHit;

        // 포지션
        //private Vector3 grabPositionOffset = new Vector3(1f, 1f, 1f);

        //
        RaycastHit hit;
        #endregion

        private void Start()
        {
            playerCasting = GetComponentInChildren<PlayerCasting>();
            hit = playerCasting.hit;

        }

        private void Update()
        {
            distance = PlayerCasting.distanceFromTarget;
            hit = playerCasting.hit;
            currentIsHit = playerCasting.currentIsHit;
            DropToObject();
            GrabToObject();
            BreakToObject();

        }

        private void GrabToObject()
        {
            if (Input.GetMouseButtonDown(1) && isGrab == false)
            {
                
                if (!currentIsHit) return;
                Grabable grabable = hit.transform.GetComponent<Grabable>();

                if(distance < grabableDistance && grabable != null)
                {
                    Debug.Log("GrabToObject");
                    Grab(grabable.transform);
                }
                
            }
        }

        private void BreakToObject()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!currentIsHit) return;
                Breakable breakable = hit.transform.GetComponent<Breakable>();
                if(distance < breakableDistance && breakable != null)
                {
                    if (breakable.IsBroken) return;
                    Debug.Log("BreakToObject");
                    Destroy(breakable.gameObject);
                    
                    //Break(breakable.gameObject);
                }
            }
        }

        private void DropToObject()
        {
            if (Input.GetMouseButtonDown(1) && isGrab == true)
            {
                Transform grabObject = player.Find("GrabObject");
                Debug.Log("DrobToObject");
                Drop(grabObject);

            }
        }

        private void Grab(Transform obj)
        {
            obj.parent = this.transform.GetChild(0).GetChild(0);
            //Rigidbody rb = obj.GetComponent<Rigidbody>();
            BoxCollider collider = obj.GetComponent<BoxCollider>();
            //rb.useGravity = false;
            //collider.enabled = false;
            isGrab = true;
            //Debug.Log("Grab");
            obj.Translate(obj.parent.transform.position);
        }

        private void Break(GameObject obj)
        {
            

            //Debug.Log("Break");
        }

        private void Drop(Transform grabObject)
        {
            Debug.Log("Drop");
            if(grabObject.GetChild(0) != null)
            {
                BoxCollider collider = grabObject.GetChild(0).GetComponent<BoxCollider>();
                collider.enabled = true;
                isGrab = false;
            }
            //Rigidbody rb = obj.GetComponent<Rigidbody>();
            //rb.useGravity = true;
        }
    }
}

