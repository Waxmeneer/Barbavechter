using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    private bool canAttack;
    public Animator animator;
    public GameObject projectilePF;
    public Transform spawnLocation;
    public float force;
    public float attackEnd;
    private PlayerMovement playerMovement;

    private KeyCode rangedAttackButton;

    private void Start()
    {
        rangedAttackButton = GetComponent<PlayerMovement>().rangedAttackButton;
        playerMovement = GetComponent<PlayerMovement>();
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(rangedAttackButton) && canAttack)
        {
            StartCoroutine(DoAttack());
        }
    }

    IEnumerator DoAttack()
    {
        GetComponentInParent<PlayerMovement>().canMove = false;
        GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;

        animator.SetBool("RangedAttack", true);
        yield return new WaitForEndOfFrame();
        animator.SetBool("RangedAttack", false);
        canAttack = false;

        GameObject projectile = Instantiate(projectilePF, spawnLocation.position, Quaternion.identity);
        if (playerMovement.isFacingRight)
        {
            projectile.GetComponent<Rigidbody2D>().AddForce(transform.right * force, ForceMode2D.Impulse);
        }
        else
        {
            projectile.GetComponent<Rigidbody2D>().AddForce(-transform.right * force, ForceMode2D.Impulse);
            projectile.transform.Rotate(new Vector3(0, 0, 180));
        }

        yield return new WaitForSeconds(attackEnd);
      
        canAttack = true;
        GetComponentInParent<PlayerMovement>().canMove = true;

        yield return null;
    }
}
