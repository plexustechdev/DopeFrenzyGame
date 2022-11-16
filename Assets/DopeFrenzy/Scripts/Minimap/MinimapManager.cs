using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    //NEED OPTIMASI
namespace DopeFrenzy
{
    public class MinimapManager : MonoBehaviour
    {
        private Controller m_Controller;
        [SerializeField] private GameObject selfIcon;

        void Start(){
            m_Controller = GetComponentInParent<Controller>();
        }

        void LateUpdate(){
            if(m_Controller.facingTo == BaseController.FacingTo.Down){
                selfIcon.transform.eulerAngles = new Vector3(0, 0, 180);
            }else if(m_Controller.facingTo == BaseController.FacingTo.Up){
                selfIcon.transform.eulerAngles = new Vector3(0, 0, 0);
            }else if(m_Controller.facingTo == BaseController.FacingTo.Left){
                selfIcon.transform.eulerAngles = new Vector3(0, 0, 90);
            }else{
                selfIcon.transform.eulerAngles = new Vector3(0, 0, -90);
            }
        }
    }
}


