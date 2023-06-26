using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaManager : MonoBehaviour
{
    [SerializeField] private Vector3 deathPosition;
    [SerializeField] private GameManager gameManager;
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player")
        {
            var characterManager = other.gameObject.GetComponent<CharacterManager>();
            characterManager.isTouchMagma = true;
            if (characterManager.boxFlag == false)
            {
                other.transform.position = deathPosition;
                characterManager.boxFlag = true;
                characterManager.canMove = false;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player")
        {
            var characterManager = other.gameObject.GetComponent<CharacterManager>();
            characterManager.isTouchMagma = false;
        }
    }
}
