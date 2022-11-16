using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DopeFrenzy
{

    public abstract class Drug : MonoBehaviour
    {
        public abstract string drugName { set; get; }
        public abstract float duration { set; get; }
        public abstract bool isPickedUp { set; get; }


        protected abstract void PickedUp();

        protected abstract void Activate();

        protected abstract void Stop();


        protected virtual void OnTriggerEnter2D(Collider2D other)
        {


        }

    }
}

