using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthHandler : PlayerScript
{
    private int _currentHP;

    public event UnityAction<int,bool> OnHealthChange;
    public event UnityAction OnDeath;

    private void Awake()
    {
        _currentHP = Settings.HP;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return;

        TakeDamage(1);
    }

    private void TakeDamage(int value)
    {
        if (_currentHP <= 0) return;

        _currentHP -= value;
        OnHealthChange.Invoke(_currentHP, false);

        if (_currentHP <= 0)
        {
            _currentHP = 0;
            OnDeath.Invoke();
        }      
    }
    private void Heal(int value)
    {
        _currentHP += value;
        if(_currentHP > Settings.HP) _currentHP = Settings.HP; 

        OnHealthChange.Invoke(_currentHP, true);
    }
}
