using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TowerBullet : MonoBehaviour
{
    [SerializeField] protected float bulletspeed = 1.2f;  // �Ѿ� ���ǵ�
    Vector2 myPos;
    //Transform target = null;
    CapsuleCollider2D capsuleCollider = null;
    private void Awake()
    {
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        myPos = transform.position;
        //target = GameObject.FindGameObjectWithTag("Mon").transform;
    }

    void Update()
    {
        Greatbullet();
    }

    void Greatbullet()
    {

        if(this.transform.position.y - myPos.y > 1f)
        {
            Destroy(this.gameObject);
        }
        //RotateTarget(myPos);
        this.transform.Translate(Vector3.up * this.bulletspeed * Time.deltaTime);
    }

    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Mon")
        {
            collision.transform.GetComponent<Monster>().Attack();
            Destroy(this.gameObject);
        }
    }
    
}
