using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public Fire player;
    public float damage;

    void Awake()
    {
        GameObject ammo = GameObject.Find("Soldier");
        Rigidbody2D rbAmmo = ammo.GetComponent<Rigidbody2D>();
        player = rbAmmo.GetComponent<Fire>();
        damage = player._damage;
    }
    // Start is called before the first frame update
    void Start()
    {
        // Rigidbody2D bileşenini al ve varsa Collision Detection Mode'unu ayarla
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "box")
        {
            CollectableManager box = collision.gameObject.GetComponent<CollectableManager>();
            if (box != null)
            {
                box.takeDamage(damage);
            }
        }
        Destroy(gameObject);
    }
}
