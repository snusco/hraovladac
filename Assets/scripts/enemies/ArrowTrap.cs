using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [SerializeField] private float AttackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrows;
    private float cooldownTimer;

    [SerializeField] private AudioClip arrowSound;


    private void Attack()
    { 
        cooldownTimer = 0;

        arrows[Findarrow()].transform.position = firePoint.position;
        arrows[Findarrow()].GetComponent<EnemyProjectile>().ActivateProjectile();

        SoundManager.Instance.PlaySound(arrowSound);
    }
    private int Findarrow()
    { 
    for (int i = 0; i <arrows.Length; i++)
        { 
         if(!arrows[i].activeInHierarchy) 
                return i;
        }
        return 0;
    }

    private void Update()
    { 
        cooldownTimer += Time.deltaTime;
    if(cooldownTimer>= AttackCooldown)
            Attack();
    }
}

