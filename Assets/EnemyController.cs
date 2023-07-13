using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour,IDamagable
{
    public Enemies MyStats;
    [Space(25)]
    Transform player;
    public LayerMask whatIsGround,whatIsPlayer;
    public GameObject treasure;
    //Patroling
    Vector3 walkPoint;
    bool walkPointSet;
    bool waiting;
    //Attacking
    float timeBetweenAttacks;
    bool alreadyAttacked;
    //States
    bool playerChaseRange,playerInSightRange, playerInAttackRange;

    //MyWalkingBox
    Vector2 startPos;

    private void Start()
    {
        waiting = false;
        startPos = transform.position;
        MyCurrentHealth = MyStats.StartHealth;
        player = GameObject.Find("Player").transform;
        timeBetweenAttacks = 1/MyStats.AttackSpeed;
    }
    private void Update()
    {
        if (MyStats.SightRadius == 0) { return; }
        playerInSightRange = Physics2D.OverlapCircle(transform.position, MyStats.SightRadius, whatIsPlayer);
        playerInAttackRange = Physics2D.OverlapCircle(transform.position, MyStats.AttackRange, whatIsPlayer);
        if(!playerInSightRange && !playerInAttackRange) { Patroling(); }
        if (playerInSightRange && !playerInAttackRange) { ChasePlayer(); }
        if (playerInSightRange && playerInAttackRange) { AttackPlayer(); }
    }
    private void Patroling()
    {
        if(waiting == true)
        {
            return;
        }

        if(!walkPointSet) { SearchWalkPoint(); }

        if (walkPointSet)
        {
            Move(walkPoint);
        }
        float angle = Mathf.Atan2(walkPoint.y-transform.position.y, walkPoint.x-transform.position.x);
        this.transform.localRotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * angle - 90);
        Vector2 distanceToWalkPoint = transform.position - walkPoint;
        if(distanceToWalkPoint.magnitude < 0.01f) {  StartCoroutine(WaitIdle()); }
    }
    private void SearchWalkPoint()
    {

        float randomY = startPos.y + Random.Range(-MyStats.WalkPointRange, MyStats.WalkPointRange);
        float randomX = startPos.x + Random.Range(-MyStats.WalkPointRange, MyStats.WalkPointRange);
        walkPoint = new Vector2(randomX, randomY);
        //if (Physics2D.Raycast(walkPoint, transform.TransformDirection(Vector2.up),3f, whatIsGround)) { walkPointSet = true; }

        walkPointSet = true;

    }
    IEnumerator WaitIdle()
    {
        waiting = true;
        yield return new WaitForSeconds(Random.Range(3f, 10f));
        walkPointSet = false;
        waiting = false;
    }
    private void ChasePlayer()
    {
        walkPointSet = false;
        float angle = Mathf.Atan2(player.position.y - transform.position.y, player.position.x - transform.position.x);
        this.transform.localRotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * angle - 90);
        Move(player.position);

    }
    private void Move(Vector2 movePoint)
    {
        transform.position = Vector2.MoveTowards(transform.position, movePoint, MyStats.MoveSpeed * Time.deltaTime * 0.05f * 12f);
    }
    private void AttackPlayer()
    {
        /*
        transform.LookAt(player);

        if (!alreadyAttacked)
        {

            //Attack here


            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }*/
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, MyStats.AttackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, MyStats.SightRadius);
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(startPos, new Vector2(2*MyStats.WalkPointRange,2*MyStats.WalkPointRange));
    }

    public int MyCurrentHealth { get; set; }
    public void TakeDamage(int damage)
    {
        MyCurrentHealth -= damage;
        if(MyCurrentHealth <= 0) { Death(); }
    }
    public void Death()
    {

        Debug.Log("Dead");
        Treasure treasureObj = Instantiate(treasure,transform.position,Quaternion.identity).GetComponent<Treasure>();
        treasureObj.health = MyStats.Treasure[0];
        treasureObj.fuel = MyStats.Treasure[1];
        treasureObj.energy = MyStats.Treasure[2];
        treasureObj.coin = MyStats.Treasure[3];
        Destroy(this.gameObject);
    }
}
