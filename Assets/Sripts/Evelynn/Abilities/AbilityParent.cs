using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityParent : MonoBehaviour
{

    public enum AbilityState
    {
        Ready,
        Casting,
        Cooldown
    }
    AbilityState state = AbilityState.Ready;

    public List<AbilitySO> ability;

   

    

    public int ManaCost;
    public float cooldownTime;
    float activeTime;
    public GameObject abilityTarget;
   
    public float castRange;
    public int damage;
    
    

    public void Start()
    {
        state = AbilityState.Ready;
    }
    // Update is called once per frame
    void Update()
    {
        //abilityStates();
        activateAbility();
    }

    void activateAbility()
    {
        for (int i = 0; i < ability.Count; i++)
        {
            if (Input.GetKeyDown(ability[i].abilityKey))
            {
                abilityStates(ability[i]);
            }
        }
    }

    void abilityStates(AbilitySO ability)
    {
        switch (state)
        {
            case AbilityState.Ready:
               
                 Debug.Log("Ability Activated");
                 ability.Activate();
                 state = AbilityState.Casting;
                 //cast ability StartCoroutine(Cast());
                 activeTime = ability.activeTime;
                
                break;
            case AbilityState.Casting:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.Cooldown;
                    cooldownTime = ability.activeTime;
                }
                break;
            case AbilityState.Cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.Ready;
                }
                break;

        }
    }
}
