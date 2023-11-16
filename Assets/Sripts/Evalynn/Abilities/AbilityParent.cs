using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AbilityParent : MonoBehaviour
{
    public enum AbilityType
    {
        nuetral,
        Q,
        W,
        E,
        R
    }
    public enum CombatState
    {
        OutOfCombat,
        leavingCombat,
        inCombat
    }

    public AbilityType abilityType = AbilityType.nuetral;
    public CombatState combatState = CombatState.OutOfCombat;

    public bool passive;
    

    public int ManaCost;
    public float cooldown;
    
    public float outOfCombatTimer;

    // Start is called before the first frame update
    void Start()
    {
        abilityType = AbilityType.nuetral;
        combatState = CombatState.OutOfCombat;
    }

    // Update is called once per frame
    void Update()
    {
        combatCheck();
        abilityCheck();
        passiveCheck();
    }
    
    void abilityCheck()
    {
        if (abilityType != AbilityType.nuetral)
        {
            combatState = CombatState.inCombat;
        }
        else
        {
            combatState = CombatState.leavingCombat;
        }
    }

    void combatCheck()
    {
        if (combatState == CombatState.leavingCombat)
        {
            StartCoroutine(outOfCombat());
        }
    }

    private IEnumerator outOfCombat()
    {
        print("out of combat");
        while (combatState == CombatState.leavingCombat)
        {
            
            yield  return new WaitForSeconds(outOfCombatTimer);
            Debug.Log("passive triggered");
            combatState = CombatState.OutOfCombat;
            
        }
        

    }
    void passiveCheck()
    {
        if (combatState == CombatState.OutOfCombat)
        {
            passive = true;
        }
        else
        {
            passive = false;
        }
    }

    

}
