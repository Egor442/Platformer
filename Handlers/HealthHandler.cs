using System;

public class HealthHandler
{
    private int _minHealth;
    private int _maxHealth;
    private int _health;

    public HealthHandler(int maxHealth)
    {
        _minHealth = 0;
        _maxHealth = maxHealth;
        _health = _maxHealth;

        Validator.Validate(ref _health, _minHealth, _maxHealth);
    }

    public int Health => _health;

    public void AddHealth(int heal)
    {
        _health += heal;
        Validator.Validate(ref _health, _minHealth, _maxHealth);
    }

    public void RemoveHealth(int damage) 
    {
        _health -= damage;
        Validator.Validate(ref _health, _minHealth, _maxHealth);
    }
}