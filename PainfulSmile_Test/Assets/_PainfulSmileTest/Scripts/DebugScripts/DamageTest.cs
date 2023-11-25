using UnityEngine;

public sealed class DamageTest : MonoBehaviour
{
    [SerializeField] private Team _team = Team.None;

    private void OnTriggerEnter2D(Collider2D col)
    {
        IDamageable damageable = col.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(25, _team);
        }
    }
}