using UnityEngine;

namespace BattleTank
{
    public class TankHealth : MonoBehaviour
    {
        private Camera cam;

        private void Start( )
        {
            this.cam = UIService.Instance.CameraMain;
        }
        private void LateUpdate( )
        {
            transform.LookAt( transform.position + cam.transform.forward );
        }
    }
}
