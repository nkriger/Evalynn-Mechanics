using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AbilityController : MonoBehaviour
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
    
    public float outOfCombatTimer;
    public bool outOfCombatTimerActive;
    private Coroutine exitingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("start");
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
            outOfCombatTimerActive = false;
        }
        else
        {
            if (outOfCombatTimerActive == false)
            {
                combatState = CombatState.leavingCombat;
            }
            
        }
    }

    //generate a code that calls the IEnumerator exitingCombat only Once when the combatState is leavingCombat


    void combatCheck()
    {
        if (combatState == CombatState.leavingCombat)
        {
            //Debug.Log("leaving combat");
            startLeavingCombat();
        }
    }

    void startLeavingCombat()
    {
        
        if (combatState == CombatState.leavingCombat)
        {        
            if (outOfCombatTimerActive == false)
            {
                //Debug.Log("out of combat");
                outOfCombatTimerActive = true;
                exitingCoroutine = StartCoroutine(exitingCombat());
                
                
            }
            else
            {
                //if timer has started and combat state changes cancel the timer
                
                if (exitingCoroutine != null)
                {
                    StopCoroutine(exitingCoroutine);
                    exitingCoroutine = null;
                    outOfCombatTimerActive = false;
                }
                
            }
        }
    }

    IEnumerator exitingCombat()
    {
            //Debug.Log("leaving combat");
            yield return new WaitForSeconds(outOfCombatTimer);
            combatState = CombatState.OutOfCombat;    
    }
    void passiveCheck()
    {
        if (combatState == CombatState.OutOfCombat)
        {
            passive = true;
            //Debug.Log("passive triggered");
        }
        else
        {
            passive = false;
        }
    }
}
