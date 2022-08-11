using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{

    [SerializeField]
	private int maxHealth, currentHealth;
    public UnityEvent<GameObject> OnHitWithReference, OnDeathWithReference;

    [SerializeField]
    public bool isDead = false;

    public void InitializeHealth(int healthValue)
    {
        currentHealth = healthValue;
        maxHealth = healthValue;
        isDead = false;
    }

    public void GetHit(int amount, GameObject sender)
    {
        if (isDead)
            return;
        //prevent hit self
        if (sender.layer == gameObject.layer)
            return;

        currentHealth -= amount;

        if (currentHealth > 0)
        {
            OnHitWithReference?.Invoke(sender);
        }
        else
        {
            OnDeathWithReference?.Invoke(sender);
            isDead = true;
            Destroy(gameObject);
        }

    }

	//public HealthBar healthBar;

    void Awake()
    {
        //InputActions = new PlayerInputAction();
    }
    // Start is called before the first frame update
    void Start()
    {
            //maxHealth = 120;
		    //currentHealth = maxHealth;
		//healthBar.SetMaxHealth(maxHealth);
        //InputActions.Player.Damage.performed += HandleDamage =>
        //{
        //    Debug.Log("ADUH");
        //    TakeDamage(20);
            
        //};
    }


    private void OnEnable()
    {
        //InputActions.Player.Damage.Enable();
    }

    private void OnDisable()
    {

        //InputActions.Player.Damage.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void TakeDamage(int damage)
	{
            //Debug.Log("URGH");
            //currentHealth -= damage;
            //Debug.Log("Hp remaining : " + currentHealth);
		//healthBar.SetHealth(currentHealth);
	}
}
