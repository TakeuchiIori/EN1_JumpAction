using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    private Animator animator;
    private void OnTriggerEnter(Collider other)
    {
        animator.SetTrigger("Get");
        //DestroySelf();

    }
    private void OnTriggerStay(Collider other)
    {

    }
    private void OnTriggerExit(Collider other)
    {

    }
    private void DestroySelf()
    {
        Destroy(gameObject);
        
    }
    // Start is called before the first frame update
    void Start()
    {
      animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
