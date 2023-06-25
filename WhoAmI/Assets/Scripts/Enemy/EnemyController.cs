using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float health = 100f;
    public string playerTag = "Player";
    public float followDistance = 5f;
    public float attackDistance = 2f;

    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private GameObject playerObject;
    private bool isFollowingPlayer = false;
    private bool isAttackingPlayer = false;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        playerObject = GameObject.FindGameObjectWithTag(playerTag);
    }

    private void Update()
    {
        if (playerObject == null)
        {
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, playerObject.transform.position);

        if (distanceToPlayer <= followDistance)
        {
            isFollowingPlayer = true;
        }
        else
        {
            isFollowingPlayer = false;
            isAttackingPlayer = false;
        }

        if (isFollowingPlayer)
        {
            navMeshAgent.SetDestination(playerObject.transform.position);

            if (distanceToPlayer <= attackDistance)
            {
                isAttackingPlayer = true;
                Punch();
            }
            else
            {
                isAttackingPlayer = false;
            }
        }
    }

    public void Punch()
    {
        if (isAttackingPlayer)
        {
            if (isAttackingPlayer)
            {
                navMeshAgent.isStopped = true;
                animator.SetBool("Attack", true);
            }
        }

    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        navMeshAgent.enabled = false;
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
        animator.SetTrigger("Dead");
        Destroy(gameObject,2.5f);
    }

}
