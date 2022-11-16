using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Inspector_triggerExit2D : MonoBehaviour
{
    [Header("Main Settings")]
    public string TagObject;
    public UnityEvent TriggerEvent;
    public bool DestroyTrigger;
    public bool DestroyThisGameObject;
    // Start is called before the first frame update

    public void InvokeTrigger()
    {
        TriggerEvent.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == TagObject)
        {
            TriggerEvent.Invoke();
            if (DestroyTrigger)
            {
                Destroy(other.gameObject);
            }
            if (DestroyThisGameObject)
            {
                Destroy(gameObject);
            }
        }
    }
}
