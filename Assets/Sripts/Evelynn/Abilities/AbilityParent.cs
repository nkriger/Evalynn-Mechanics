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


    //public AbilityState State { get; private set; } = AbilityState.Ready;
    /// <summary>
    /// public float ActiveTime { get; private set; }
    /// </summary>
    ///public float CooldownTime { get; private set; }


    public int ManaCost;
    public float cooldownTime;
    public float activeTime;
    public GameObject abilityTarget;
   
    public float castRange;
    public int damage;

    public void Activate()
    {
        if (state == AbilityState.Ready)
        {
            // Your activation code here...

            state = AbilityState.Casting;
            //ActiveTime = activeTime;
        }
    }

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
            ability[i].Update();

            if (Input.GetKeyDown(ability[i].abilityKey))
            {
                ability[i].Activate();
            }

            abilityStates(ability[i]); 
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
                Debug.Log("Ability started Cast");
                if (activeTime > 0)
                {
                    Debug.Log("Ability Casting");
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
                    Debug.Log("Ability on Cooldown");
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    Debug.Log("Ability Ready");
                    state = AbilityState.Ready;
                }
                break;

        }
    }
}
