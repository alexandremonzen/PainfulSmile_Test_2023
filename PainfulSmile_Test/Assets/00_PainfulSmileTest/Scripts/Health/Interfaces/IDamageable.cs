public interface IDamageable
{
    public void TakeDamage(int damageValue, Team team);
    public void Die();
    public Team GetTeamSide();
}
