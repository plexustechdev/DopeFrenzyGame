using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DopeFrenzy
{
    public class Screen : MonoBehaviour
    {
        public string screenName;
        public bool isOpen;

        public void Hide(){
            this.gameObject.SetActive(false);
        }

        public void Show(){
            this.gameObject.SetActive(true);
        }
    }
}


