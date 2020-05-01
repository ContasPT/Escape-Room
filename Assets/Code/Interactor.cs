using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactor : MonoBehaviour
{
    public float InteractionLength;
    public GameObject RaycastOrigin;
    public Text Tooltip;
    public GameObject UI;

    private enum RaycastObject
    {
        Nothing,
        Interactable,
        Physical,
        Pickupable,
        Document
    }
    private RaycastObject LastRaycastedObject;
    private GameObject TargetObject;

    public GameObject HoldOrigin;
    private GameObject PhysicalObject;
    public float ThrowStrength;

    void Start()
    {
        LastRaycastedObject = RaycastObject.Nothing;
    }

    void Update()
    {
        RaycastHit hit;
        TargetObject = null;
        Tooltip.text = "";
        LastRaycastedObject = RaycastObject.Nothing;

        if (!PhysicalObject && UI.active)
        {
            if (Physics.Raycast(RaycastOrigin.transform.position, transform.forward, out hit, InteractionLength))
            {
                //Have I hit something? 
                //If I have, I should get in this If.
                if (hit.transform)
                {
                    if (hit.transform.CompareTag("Interactable"))
                    {
                        TargetObject = hit.transform.gameObject;

                        if (TargetObject.GetComponent<InteractiveObject>().CanBeInteractedWith)
                        {
                            LastRaycastedObject = RaycastObject.Interactable;
                            Tooltip.text = "[E] " + TargetObject.GetComponent<InteractiveObject>().Tooltip;
                        }
                    }
                    else if (hit.transform.CompareTag("Pickupable"))
                    {
                        LastRaycastedObject = RaycastObject.Pickupable;
                        TargetObject = hit.transform.gameObject;
                        Tooltip.text = "[E] Pick Up";
                    }
                    else if (hit.transform.CompareTag("Physical"))
                    {
                        LastRaycastedObject = RaycastObject.Physical;
                        TargetObject = hit.transform.gameObject;
                        Tooltip.text = "[RMB] Hold Object";
                    }
                    else if (hit.transform.CompareTag("Document"))
                    {
                        LastRaycastedObject = RaycastObject.Document;
                        TargetObject = hit.transform.gameObject;
                        Tooltip.text = "[E] Read";
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (LastRaycastedObject == RaycastObject.Interactable)
            {
                TargetObject.GetComponent<InteractiveObject>().ExecuteInteractiveAction();
            }
            //else if (LastRaycastedObject == RaycastObject.Pickupable)
            //{

            //    InventoryManager.TheInventory.AddItem(
            //        TargetObject.GetComponent<InventoryPickup>().AssociatedItem);
            //    TargetObject.SetActive(false);
            //}
            //else if (LastRaycastedObject == RaycastObject.Document)
            //{
            //    if (UIManager.TheUI.AreAnyUIsActive()) return;

            //    DocumentManager.TheManager.OpenDocumentPanel(TargetObject.GetComponent<DocumentScript>());
            //}
        }

        // Physical Object Manipulation
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // If I am NOT holding something... I need to make some checks.
            if (!PhysicalObject)
            {
                if (TargetObject)
                {
                    if (LastRaycastedObject == RaycastObject.Physical)
                    {
                        PhysicalObject = TargetObject;
                        PhysicalObject.GetComponent<Collider>().enabled = false;
                        PhysicalObject.GetComponent<Rigidbody>().isKinematic = true;
                        PhysicalObject.GetComponent<Rigidbody>().useGravity = false;
                    }
                }
            }
            // If I AM ACTUALLY holding something, I probably need to throw it.
            else
            {
                PhysicalObject.GetComponent<Collider>().enabled = true;
                PhysicalObject.GetComponent<Rigidbody>().isKinematic = false;
                PhysicalObject.GetComponent<Rigidbody>().useGravity = true;
                PhysicalObject.GetComponent<Rigidbody>().velocity =
                    transform.forward * ThrowStrength;
                PhysicalObject = null;
            }
        }

        if (PhysicalObject)
        {
            PhysicalObject.transform.position =
                Vector3.Lerp(PhysicalObject.transform.position,
                HoldOrigin.transform.position,
                0.75f);
        }
    }
}
