  using UnityEngine;
  using System.Collections;
public class FireTrap : MonoBehaviour

{
    
    [SerializeField] private float damage;

    [Header ("FireTrap Timers")]

    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator Anim;
    private SpriteRenderer spriteRend;

    private bool triggered; // triggered trap
    private bool active; //active trap



    private void Awake()
    { 
        Anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    { 
    if(collision.tag == "Player")
        { 
        if(!triggered)
             
             StartCoroutine(ActivateFiretrap());
            
        if(active)
                collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
    private IEnumerator ActivateFiretrap()
    { //turn the sprite red to notify the player and trigger the trap
      triggered = true;
        //wait for delay, activate trap, turn on animation, return color back to normal
        spriteRend.color = Color.red;
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white;
        active = true;
        Anim.SetBool("activated", true);

        //wait until x seconds, deactivate traps and reset all variables and animator
        yield return new WaitForSeconds(activationDelay);
        active = false;
        triggered = false;
        Anim.SetBool("activated", false);
    }


}

