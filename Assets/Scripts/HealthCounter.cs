using UnityEngine;
using System.Collections;

public class HealthCounter : MonoBehaviour 
{
    public int InitialHealth = 100;
    
    public int CurrentHealth { get; private set; }

    void Start () 
    {
        CurrentHealth = InitialHealth;
	}

    public void Restore(int qtyToRestore)
    {
        if (qtyToRestore < 0)
        {
            return;
        }
        ChangeCurrentHealth(qtyToRestore);
    }
    
    public void Damage(int qtyToDamage)
    {
        if (qtyToDamage < 0)
        {
            return;
        }
        ChangeCurrentHealth(-qtyToDamage);
    }

    private void ChangeCurrentHealth(int quantity)
    {
        CurrentHealth += quantity;
        if (CurrentHealth > InitialHealth)
        {
            CurrentHealth = InitialHealth;
        }
        if (CurrentHealth <= 0)
        {
            Transform currentTransform = this.transform;
            while (currentTransform.parent != null)
            {
                currentTransform = currentTransform.transform.parent;
            }
            Destroy(currentTransform.gameObject);
        }
    }
}
