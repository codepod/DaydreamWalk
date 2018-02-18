using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class Throwable : MonoBehaviour
{
    private Vector3 throwVelocity;
    private Vector3 previousPosition;

    // Use this for initialization
    void Start()
    {
        //listeners for button clicks
        gameObject.AddListener(EventTriggerType.PointerDown, Hold);
        gameObject.AddListener(EventTriggerType.PointerUp, Release);
    }

    // Update is called once per frame
    void Update()
    {
        // velocity based on the position in the last frame
        Vector3 frameVelocity = (transform.position - previousPosition) / Time.deltaTime;

        // calculate average velocity from the last frame
        const int samples = 3;
        throwVelocity = throwVelocity * (samples - 1) / samples + frameVelocity / samples;
        previousPosition = transform.position;
    }

    public void Hold()
    {
        Transform pointerTransform = GvrPointerInputModule.Pointer.PointerTransform;

        // make the gameobject part of the pointer
        transform.SetParent(pointerTransform, false);

        // position it in the view(delete this to lock it onto the pointer in it's current position)
        transform.localPosition = new Vector3(0, 0, 2);

        // disable physics (kinematic = moves with arm model)
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void Release()
    {
        // release the object from the pointer
        transform.SetParent(null, true);
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        // reset velocity
        rigidbody.velocity = Vector3.zero;

        // enable gameObject physics
        rigidbody.isKinematic = false;

        //throw the object once released 
        rigidbody.AddForce(throwVelocity, ForceMode.VelocityChange);
    }
}

//extends GameObject to add AddListener
public static class EventExtensions
{

    public static void AddListener(this GameObject gameObject,
        EventTriggerType eventTriggerType,
        UnityAction action)
    {

        // get the EventTrigger component; if it doesn't exist, create one and add it
        EventTrigger eventTrigger = gameObject.GetComponent<EventTrigger>()
            ?? gameObject.AddComponent<EventTrigger>();

        // check to see if the entry already exists
        EventTrigger.Entry entry;
        entry = eventTrigger.triggers.Find(e => e.eventID == eventTriggerType);

        if (entry == null)
        {
            // if it does not, create and add it
            entry = new EventTrigger.Entry { eventID = eventTriggerType };

            // add the entry to the triggers list
            eventTrigger.triggers.Add(entry);
        }

        // add the callback listener
        entry.callback.AddListener(_ => action());
    }

}

