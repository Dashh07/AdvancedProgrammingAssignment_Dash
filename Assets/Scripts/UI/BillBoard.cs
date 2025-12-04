using UnityEngine;

public class BillBoard : MonoBehaviour
{
    [Header("References")]
    public Transform cam;
 

    // Update is called once per frame
    void LateUpdate()
    {
        if (cam == null) return;
        
        transform.LookAt(transform.position + cam.forward);
    }
}
