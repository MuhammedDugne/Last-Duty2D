using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Fire : MonoBehaviour
{
    [SerializeField] private GameObject gunMuzzle;
    [SerializeField] private GameObject[] guns;
    private GameObject tempAmmo;
    [SerializeField] private GameObject ammo;
    [SerializeField] private GameObject target;
    private Quaternion rotasyon;
    private RaycastHit2D playerRay;
    private RaycastHit2D sightRay;
    private LayerMask   layerMask;
    private Vector3 mousePosition;
    private float   mousePlayerDistance = 0.0f;

    private float fireTime;
    private float changeTime;
    private int gunsIndex = 1;
    public Image[] gunsImage;
    public float _damage;
    public PlayerStatManager playerStat;
    private ShakeCamera shake;

    public GameObject playerMusic;
    private Rigidbody2D voiceRb;
    private PlayerMusic voice;
    public GameObject pauseObj;

    // Start is called before the first frame update
    void Start()
    {
        GameObject cam = GameObject.FindWithTag("Virtual");
        Rigidbody2D camRb = cam.GetComponent<Rigidbody2D>();
        shake = camRb.GetComponent<ShakeCamera>();
        playerStat = GetComponent<PlayerStatManager>();
        voiceRb = playerMusic.GetComponent<Rigidbody2D>();
        voice = voiceRb.GetComponent<PlayerMusic>();
        if (guns[0].activeSelf)
        {
            gunsIndex = 1;
            gunsImage[1].color = new Color(255, 0, 0); // standart renk 135, 129, 129; burada deactive.
        }
        else
        {
            gunsImage[0].color = new Color(255, 0, 0); // standart renk 135, 129, 129; burada deactive.
            gunsIndex = 2;
        }
        _damage = playerStat.getDamage(gunsIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        changeTime += Time.fixedDeltaTime;
        fireTime += Time.fixedDeltaTime;
        if (Input.GetMouseButton(0))
        {
            if (((gunsIndex == 1 && fireTime > 0.25f) || (gunsIndex == 2 && fireTime > 3.5f)) && (!pauseObj.activeSelf))
            {
                _damage = playerStat.getDamage(gunsIndex);
                if (playerStat._energy >= 100f && gunsIndex == 2 && Input.GetKey(KeyCode.LeftControl))
                {
                    playerStat._energy = 0f;
                    _damage = playerStat.getDamage(2) * 2;
                    shake.StartShakeCoroutine(0.2f, 5.0f);
                    shoot();
                    voice.stopSelectedVoice();
                    _damage = playerStat.getDamage(2);
                }
                else
                    shoot();
                    //voice.stopSelectedVoice();
            }
        }
        if (changeTime > 3.0f)
            changeWeapon();
        mousePos();
        rayDraw();
    }

    private void shoot()
    {
        voice.playGunsVoice();
        tempAmmo = Instantiate(ammo, gunMuzzle.transform.position, Quaternion.identity);
        tempAmmo.GetComponent<Rigidbody2D>().AddForce((target.transform.position - transform.position).normalized * 3000);
        fireTime = 0.0f;
        Debug.Log(_damage);
    }

    private void rayDraw()
    {
        playerRay = Physics2D.Raycast(transform.position, target.transform.position, 100, layerMask);

        mousePlayerDistance = Vector3.Distance(transform.position, target.transform.position);


        if (mousePlayerDistance > 5)
        {
            /// Fare karaktere 5 metre uzaksa  nisangahtan cikan ray fareye g�re de�il 
            /// imlece g�re �izer
            sightRay = Physics2D.Raycast(gunMuzzle.transform.position, target.transform.position, 100, layerMask);
        }
        else
        {
            /// Fare karaktere 5 metre yakinlastiginda nisangahtan cikan ray fareye g�re de�il 
            /// d�z bi�imde �izmeye ba�lar
            sightRay = Physics2D.Raycast(gunMuzzle.transform.position, gunMuzzle.transform.up , 100, layerMask);
        }

        
        Debug.DrawLine(gunMuzzle.transform.position, target.transform.position,Color.magenta);
        Debug.DrawLine(transform.position, target.transform.position, Color.green);
    }

    private void mousePos()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
    }

    private void changeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && gunsIndex != 1 || Input.GetKey(KeyCode.Keypad1))
        {
            Changer(1);
            changeTime = 0.0f;
            _damage = playerStat.getDamage(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && gunsIndex != 2 || Input.GetKey(KeyCode.Keypad2))
        {       
            Changer(2);
            fireTime += 20.0f;
            changeTime = 0.0f;
            _damage = playerStat.getDamage(2);
        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0f)
        {
            Changer(1);
            changeTime = 0.0f;
            _damage = playerStat.getDamage(1);
        }
        else if (Input.GetAxisRaw("Mouse ScrollWheel") < 0f)
        {
            Changer(2);
            fireTime += 20.0f;
            changeTime = 0.0f;
            _damage = playerStat.getDamage(2);
        }
    }

    private void Changer(int number)
    {
        for(int i =0; i<guns.Length; i++)
        {
            guns[i].SetActive(false);
        }
        guns[number - 1].SetActive(true);
        gunsIndex = number;
        if (number == 1)
        {
            gunsImage[0].color = new Color(135, 129, 129);
            gunsImage[1].color = new Color(255, 0, 0);
        }
        else if (number == 2)
        {
            gunsImage[1].color = new Color(135, 129, 129);
            gunsImage[0].color = new Color(255, 0, 0);
        }
    }

    public int getGunsIndex()
    {
        return (gunsIndex - 1);
    }
}
