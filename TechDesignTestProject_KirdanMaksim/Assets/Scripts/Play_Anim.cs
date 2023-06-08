using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Anim : MonoBehaviour
{
    Animator anim;
    GameObject player;
   public GameObject button;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        anim = player.GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            var RayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));

           
                           
                if (RayHit.collider != null)
                {
                if(RayHit.collider.gameObject.CompareTag("Player"))
                {
                  anim.Play("Attack");
                }
                else if(RayHit.collider.gameObject.CompareTag("Tower"))
                {
                    anim.Play("Block");
                }
                else if (RayHit.collider.gameObject.CompareTag("Cloud"))
                {
                    button.SetActive(true);
                }
            }
            }
        }

}
