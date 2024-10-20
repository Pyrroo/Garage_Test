using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float pickupRange = 10f; 
    public float throwForce = 600f;
    public Transform holdPosition;
    public Transform RayOrigin;

    public GameObject UI_Panel;

    private GameObject heldObject = null;
    private Rigidbody heldObjectRb = null;

    void Update()
    {
        ShowUI();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                TryPickupObject();
            }
            else
            {
                DropObject();
            }
        }

        if (heldObject != null)
        {
            MoveHeldObject();
        }
    }
    
    void TryPickupObject()
    {
        RaycastHit hit;
        if (Physics.Raycast(RayOrigin.position, RayOrigin.transform.forward, out hit, pickupRange))
        {
            if (hit.collider.gameObject.CompareTag("Pickupable"))
            {
                PickupObject(hit.collider.gameObject);
            }
        }
    }

    void PickupObject(GameObject pickObject)
    {
        heldObject = pickObject;
        heldObjectRb = heldObject.GetComponent<Rigidbody>();
        if (heldObjectRb != null)
        {
            heldObjectRb.useGravity = false;
            heldObjectRb.constraints = RigidbodyConstraints.FreezeRotation;
            heldObject.transform.position = holdPosition.position;
            heldObject.transform.SetParent(holdPosition);
        }
    }

    void DropObject()
    {
        if (heldObjectRb != null)
        {
            heldObjectRb.useGravity = true;
            heldObjectRb.constraints = RigidbodyConstraints.None;
            
        }
        heldObject.transform.SetParent(null); 
        heldObject = null;
        heldObjectRb = null;
    }

    void MoveHeldObject()
    {
        if (heldObjectRb != null)
        {
            Vector3 moveDirection = holdPosition.position - heldObject.transform.position;
            heldObjectRb.velocity = moveDirection * 10;
        }
    }
    void ShowUI()
    {
        RaycastHit hit2;
        if (Physics.Raycast(RayOrigin.position, RayOrigin.transform.forward, out hit2, pickupRange))
        {
            if (hit2.collider.gameObject.CompareTag("Pickupable") && heldObject == null)
            {
               
                UI_Panel.SetActive(true);
            }
            else
            {
               
                UI_Panel.SetActive(false);
            }
        }
        else
        {
            UI_Panel.SetActive(false);
        }
    }
    private void Start()
    {
        UI_Panel.SetActive(false);
    }
}
