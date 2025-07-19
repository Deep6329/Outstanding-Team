using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool flipped = true;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out PlayerBehaviour playerBehaviour))
        {
            PlayerBehaviour.Flipped = flipped;
        }
    }
}
