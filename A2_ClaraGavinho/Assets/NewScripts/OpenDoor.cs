using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField]
    public Transform pivot;

    [SerializeField]
    public Item itemRef;

    [SerializeField] 
    private float duration = 2.0f;
    [SerializeField] 
    private float angle = -90.0f;

    //public bool isOpening = false;

    // Start is called before the first frame update
    void Start()
    {
        itemRef.OnUse.AddListener(HandleOpenDoor);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void HandleOpenDoor()
    {  
        StartCoroutine(DoorMove());
    }
    IEnumerator DoorMove()
    {
        //Quaternion firstRotation = pivot.rotation;
        Quaternion rotationMove = Quaternion.Euler(pivot.localEulerAngles + new Vector3(0, angle, 0));

        for (float i = 0; i < duration; i += Time.deltaTime)
        {
            pivot.localRotation = Quaternion.Slerp(pivot.rotation, rotationMove, i / duration);
            yield return null;
        }

        itemRef.OnUse.RemoveListener(HandleOpenDoor);
    }
}
