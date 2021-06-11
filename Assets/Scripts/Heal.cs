using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public int healAmount;
    public ParticleSystem heal;
    private void OnTriggerEnter2D(Collider2D collision)
    {
         

       if (collision.gameObject.CompareTag("Player"))
        {
            heal.Play();
        }
       
    }


}
