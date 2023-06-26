using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterManager : MonoBehaviour
{
    public UNIT_TYPE unitType;
    private bool isDeath;
    public bool canMove;
    [SerializeField] private float speed;
    [SerializeField] private Animator animator;
    public GameManager gameManager;
    public WaveManager waveManager;
    public bool boxFlag;
    public bool isGoal;
    public bool isTouchMagma;
    public Vector3 lastPos;
    [SerializeField] private GameObject audioObject;
    [SerializeField] private GameObject fireAudioObject;
    public float amplitude = 1f;  // 上下の振幅
    public float frequency = 2f;  // 上下の周波数
    Vector2 startPosition;

    public enum UNIT_TYPE
    {
        PLAYER,
        ENEMY,
    }
    private void Start()
    {
        startPosition = new Vector2(transform.position.x,transform.position.y);
        isTouchMagma = false;
        isGoal = false;
        isDeath = false;
        canMove = true;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (canMove)
        {
            transform.position += new Vector3(speed, Mathf.Sin(Time.time * frequency) * amplitude, 0) * Time.deltaTime;
        }
        else
        {
            if (!isDeath)
            {
                isDeath = true;
                StartCoroutine(Death());
            }
        }
    }

    IEnumerator Death()
    {
        animator.SetTrigger("Death");
        Instantiate(fireAudioObject,transform);
        yield return new WaitForSeconds(0.5f);
        if (this.gameObject.tag == "Player")
        {
            gameManager.isGameOver = true;
        }
        Destroy(this.gameObject);
    }

    private void OnMouseDown()
    {
        lastPos = transform.position;
    }

    void OnMouseDrag()
    {
        boxFlag = true;
        Vector3 thisPosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(thisPosition);
        worldPosition.z = 0f;
        this.transform.position = worldPosition;
    }
    void OnMouseUp()
    {
        //ドラッグ終了、吸い込んでよし
        boxFlag = false;
        if (!isTouchMagma)
            transform.position = lastPos;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Goal" && unitType == UNIT_TYPE.PLAYER)
        {
            Instantiate(audioObject,transform.position,transform.rotation);
            waveManager.currentWaveClearCnt.Value++;
            Destroy(this.gameObject);
        }
        else if(other.gameObject.tag == "Goal" && unitType == UNIT_TYPE.ENEMY)
        {
            gameManager.isGameOver = true;
        }
    }

}
