using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalmonKiller : MonoBehaviour
{
    [SerializeField] private string salmonTag;
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == salmonTag){
            Destroy(other.gameObject);
        }
    }
}
