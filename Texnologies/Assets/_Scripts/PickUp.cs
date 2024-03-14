using UnityEngine;

public class PickUp : MonoBehaviour
{
    public bool isEquipped;
    private Rigidbody itemRb;
    public Transform rightHand;

    void Start()
    {
        isEquipped = false; //the player doesn't have anything equipped
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !isEquipped)
        {
            GrabItem(); //when you press F, you grab the item
        }

        if (Input.GetKeyDown(KeyCode.G) && isEquipped)
        {
            DropItem(); //when you press G while holding an item, you drop it
        }
    }

    private void GrabItem()
{
    Collider[] colliders = Physics.OverlapSphere(rightHand.position, 0.5f);
    foreach (Collider col in colliders)
    {
        if (col.CompareTag("Weapon")) //check if the item has the tag "Weapon"
        {
            isEquipped = true;

            Rigidbody colRb = col.GetComponent<Rigidbody>();
            if (colRb != null)
            { //positions it correctly in the player's hand
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
    { //drop item
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