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
    private float angle = 90.0f;

    //public bool isOpening = false;

    // Start is called before the first frame update
    void Start()
    {
        if (pivot != null)
        {
            pivot = transform;
        }
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
        Quaternion firstRotation = pivot.rotation;
        Quaternion rotationMove = Quaternion.Euler(pivot.eulerAngles + new Vector3(0, angle, 0));

        for (float i = 0; i < duration; i += Time.deltaTime)
        {
            pivot.rotation = Quaternion.Slerp(firstRotation, rotationMove, i / duration);
            yield return null;
        }
    }
}
