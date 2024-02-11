using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool isEquipped;
    private Rigidbody itemRb;
    public Transform rightHand;

    void Start()
    {
        isEquipped = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isEquipped)
        {
            GrabItem();
        }

        if (Input.GetKeyDown(KeyCode.G) && isEquipped)
        {
            DropItem();
        }
    }

    private void GrabItem()
{
    Collider[] colliders = Physics.OverlapSphere(rightHand.position, 0.5f);
    foreach (Collider col in colliders)
    {
        if (col.CompareTag("Weapon"))
        {
            isEquipped = true;

            Rigidbody colRb = col.GetComponent<Rigidbody>();
            if (colRb != null)
            {
                itemRb = colRb;
                itemRb.transform.parent = rightHand;  
                itemRb.transform.localPosition = new Vector3(0f, -0.05f, 0f);
                itemRb.transform.localRotation = Quaternion.Euler(new Vector3(270f, 0f, 0f));  
                itemRb.isKinematic = true;
                itemRb.detectCollisions = false;
            }
            
            break;
        }
    }
}


    private void DropItem()
    {
        itemRb.transform.parent = null;
        isEquipped = false;
        itemRb.isKinematic = false;
        itemRb.detectCollisions = true;
        itemRb = null;
    }

    /*public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon") && Input.GetKey(KeyCode.E) && !isEquipped)
        {
            GrabItem();
        }
    }*/
    
}
