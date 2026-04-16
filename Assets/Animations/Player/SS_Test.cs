using UnityEngine;

public class SS_Test : MonoBehaviour
{
    [SerializeField] private Animation _animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.Play();
        }
    }
}
