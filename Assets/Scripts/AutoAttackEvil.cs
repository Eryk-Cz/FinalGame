using UnityEngine;
using System.Linq;

public class AutoAttackEvil : MonoBehaviour
{
    public int damage = 10;
    public float attackRange = 2f;
    public float attackCooldown = 1f;
    public float moveSpeed = 2f;

    private float nextAttackTime = 0f;
    private Team myTeam;

    void Start()
    {
        myTeam = GetComponent<Team>();
    }

    void Update()
    {
        // Find all units
        var allUnits = FindObjectsOfType<Team>();

        // Find closest enemy
        var targetTeam = allUnits
            .Where(t => t.team != myTeam.team)
            .OrderBy(t => Vector3.Distance(transform.position, t.transform.position))
            .FirstOrDefault();

        if (targetTeam == null) return; // No enemies left

        Transform target = targetTeam.transform;
        float distance = Vector3.Distance(transform.position, target.position);

        // If too far, move toward the target
        if (distance > attackRange)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
            return;
        }

        // If in range, attack when cooldown allows
        if (Time.time >= nextAttackTime)
        {
            target.GetComponent<Health>().TakeDamage(damage);
            nextAttackTime = Time.time + attackCooldown;
        }
    }
}
