
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class EnemyControll : MonoBehaviour
{
    private Vector3 producedPoint;
    private  Vector3 _Enposition;
    private Vector3 pointDifference;
    private Vector3 playerEnemyDifference;
    private Vector3 directionPos, enemyPos, playerEnemyDifferenceVec;
    private Vector3 enemyDirectionAngleVEC;
    private float enemyDirectionAngle = 0;
    private float randomX = 0, randomY = 0;
    private float distance = 0;
    private float waitTime = 0;
    private float waitRand = 0;
    private GameObject _pointObject;
    private GameObject _PlayerObject;
    private enemySituation situation = enemySituation.pointNotFound;
    private RaycastHit2D _rayPoint ,charterRay;

    [SerializeField] LayerMask PointMask;
    [SerializeField] Sprite[] enemySprite;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private GameObject[] enemylimb;
    [SerializeField] private GameObject blood;
    bool charterSeeThat = true;

    private Quaternion _enemyRotation;
    int can = 100;
    

     void Start()
    {
        producedPoint = new Vector3();
        pointDifference= new Vector3();
        enemyDirectionAngleVEC = new Vector3();
        _pointObject = new GameObject("Düþmanýn Gideceði nokta");
        _PlayerObject = GameObject.FindGameObjectWithTag("Player");
        _spriteRenderer = GetComponent<SpriteRenderer>();
        CircleCollider2D col = _pointObject.AddComponent<CircleCollider2D>();
        col.isTrigger = true;
        col.radius = 0.15f;
       

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       

        if (situation != enemySituation.playerSeen)
        {
            spotFinder();
            
        }
        enemyMove();
        chracterRayDriwe();
        enemyRotation();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(producedPoint, 0.5f);
    }

    private void spotFinder()
    {
        if(situation == enemySituation.pointNotFound)
        {
            _Enposition = transform.position;
            randomX = Random.Range(2, 7);
            randomY = Random.Range(2, 7);

            producedPoint.Set(_Enposition.x + Random.Range(randomX * -1, randomX), _Enposition.y + Random.Range(randomY * -1, randomY), 0);
            _pointObject.transform.position = producedPoint;
            drawRayPoint();
        }

       
    }


    private void drawRayPoint()
    {
        pointDifference = (producedPoint - transform.position).normalized;
        _rayPoint = Physics2D.Raycast(transform.position, pointDifference, 100,PointMask);
        Debug.DrawLine(transform.position,_rayPoint.point);

        if(_rayPoint && _rayPoint.collider.name == _pointObject.name)
        {
            situation = enemySituation.pointFound;
        }

    }


    private void chracterRayDriwe()
    {

        playerEnemyDifference = (_PlayerObject.transform.position - transform.position).normalized;
        charterRay = Physics2D.Raycast(transform.position, playerEnemyDifference, 1000, PointMask);
        Debug.DrawLine(transform.position, charterRay.point);
        if (charterRay && charterRay.collider.tag == "Player")
        {
            situation = enemySituation.playerSeen;
            charterSeeThat = true;
        }
        else
        {
            if (charterSeeThat)
            {
                situation = enemySituation.pointNotFound;
                charterSeeThat = false;
            }

        }






    }
    private void enemyMove()
    {
        if(situation == enemySituation.playerSeen)
        {
            transform.position += playerEnemyDifference * Time.fixedDeltaTime * 2.5f;
        }
        else
        {
            
            if(situation == enemySituation.pointFound)
            {
                transform.position += pointDifference*Time.fixedDeltaTime*2.5f;
                distance = Vector3.Distance(transform.position, _rayPoint.point);
                
                //mesafe 0.1f eþitse bekleyecek
                if (distance <= 0.5f)
                {
                    situation = enemySituation.wait;
                    waitRand = Random.Range(2.0f, 0.2f);
                    
                }
            }
            else if(situation == enemySituation.wait)
            {
                waitTime += Time.fixedDeltaTime;
                if (waitTime > waitRand)
                {
                    situation = enemySituation.pointNotFound;
                    waitTime= 0;
                }
            }
            
        }
    }

   private void enemyRotation()
    {
        if (situation == enemySituation.playerSeen)
        {
            directionPos = _PlayerObject.transform.position;
        }
        else
        {
            directionPos = _pointObject.transform.position;
        }
        enemyPos = transform.position;
       
        playerEnemyDifferenceVec = (enemyPos - directionPos).normalized;
        enemyDirectionAngle = Mathf.Atan2(playerEnemyDifferenceVec.y, playerEnemyDifferenceVec.x) * Mathf.Rad2Deg;
        enemyDirectionAngleVEC.Set(0, 0, enemyDirectionAngle);
        _enemyRotation = Quaternion.Euler(enemyDirectionAngleVEC);
        _enemyRotation *= Quaternion.Euler(0, 0, 90);
        transform.rotation = Quaternion.Lerp(transform.rotation, _enemyRotation, 0.1f);

    }
    private void animation()
    {

    }

    public void enemyDead()
    {
        for (int i = 0; i <Random.Range(5,10); i++)
        {
            GameObject enemylimbs = Instantiate(enemylimb[Random.Range(0, enemylimb.Length)], transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            Vector2 enemylimbVec = new Vector2(Random.Range(-1000, 1000), Random.Range(-1000.0f, 1000.0f));

            enemylimbs.GetComponent<Rigidbody2D>().AddForce(enemylimbVec);
        }

        for (int i = 0; i < Random.Range(5, 10); i++)
        {
            Vector3 bloodVec = new Vector3(transform.position.x + Random.Range(-2.0f, 2.0f), transform.position.y + Random.Range(-2.0f, 2.0f), 0);
            Instantiate(blood, bloodVec, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        }
        GetComponent<CircleCollider2D>().enabled = false;
        Destroy(this);
        
        Destroy(gameObject, 2);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "bullet")
        {
            can -= 15;
            print(can);
            Destroy(col.gameObject);
            if (can <= 0)
            {
                enemyDead();
            }
        }
    }

}



public enum enemySituation
{
    pointFound =1,
    pointNotFound =2,
    wait = 3,
    playerSeen = 4

}
