using UnityEngine;

public class SpriteRotator : MonoBehaviour
{
    private void LateUpdate()
    {
        Vector3 camPos = Camera.main.transform.position;
        Vector3 pos = transform.position;

        Vector2 toCam = new Vector2(camPos.x - pos.x, camPos.z - pos.z);
        toCam.Normalize();
        float angle = Vector2.SignedAngle(new Vector2(0, -1), toCam);
        Vector3 euler = transform.eulerAngles;
        euler.y = -angle;
        transform.eulerAngles = euler;
    }
}
