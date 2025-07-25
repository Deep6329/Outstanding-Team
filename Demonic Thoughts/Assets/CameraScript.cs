using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform trackTarget;
    public float followSpeed = 0.75f;

    private void LateUpdate()
    {
        if(trackTarget!=null)
            transform.position = Vector3.Lerp(transform.position, trackTarget.transform.position, 1.0f - Mathf.Pow(1.0f - followSpeed, Time.deltaTime));

        Vector3 eul = transform.eulerAngles;

        eul.y = Mathf.Lerp(eul.y, PlayerBehaviour.Flipped ? 180.0f : 0.0f, 1.0f - Mathf.Pow(1.0f - followSpeed, Time.deltaTime));

        transform.eulerAngles = eul;
    }
}
