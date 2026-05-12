using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class BuyableDoor : MonoBehaviour
{
    private int scoreRequirement;
    private Rigidbody body;

    private void Start()
    {
        body = GetComponent<Rigidbody>();
    }
    private void OnTriggerStay(Collider other)
    {
        /*if (Input.GetKey(KeyCode.E) && other.TryGetComponent<ScoreManager>().score == scoreRequirement)
        {
            body.isKinematic = true;
            Destroy(gameObject,5);
        }*/
    }

}
