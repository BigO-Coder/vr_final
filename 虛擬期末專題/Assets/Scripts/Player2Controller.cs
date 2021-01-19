using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    private float moveSpeed = 15.0f;
    private float turnSpeed = 25.0f;

    public Rigidbody bullet;  //子弹预制体
    public int HP = 3;//現有血量
    public int Max_hp = 3;//血量最大值
    public GameObject hpImg;//綠色
    private float bulletSpeed = 500f;
    private float timer; //計時器
    private bool hasCollided = false; //是否碰撞

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        playerMove();
        timeCouter();
        shownHp();

        if (HP <= 0 || (transform.position.y < -20f)) //沒血或掉落消失
        {
            Destroy(gameObject);
        }

    }

    private void playerMove()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-Vector3.up, turnSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }
    }

    private void playerAttack() //玩家攻擊
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            timer += 0.01f; //啟動計時器

            Rigidbody bulletCopy = (Rigidbody)Instantiate(bullet, transform.position + new Vector3(0, 2f, -6.5f), transform.rotation);
            bulletCopy.velocity = bulletCopy.transform.TransformDirection(Vector3.forward * bulletSpeed);
        }
    }


    void timeCouter() //計時器（2.5s）
    {
        if (timer == 0)
        {
            playerAttack();
        }
        else
        {
            timer += Time.deltaTime;

            if (timer > 2.5f)
            {
                timer = 0;
            }
        }
    }

    void shownHp() //顯示血量
    {
        if (HP >= 0)
        {
            float _percent = ((float)HP / (float)Max_hp);
            hpImg.transform.localScale = new Vector3(_percent, hpImg.transform.localScale.y, hpImg.transform.localScale.z);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (hasCollided) { return; } //確保子彈碰到戰車只會被判斷一次

        else
        {
            if (other.gameObject.tag == "Bullet") //碰到子彈時
            {
                Destroy(other.gameObject);
                HP -= 1;
            }

            hasCollided = true;
        }
    }

    void LateUpdate()
    {
        hasCollided = false;
    }
}