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


    public AbilitySO ability;
    public int ManaCost;
    public float cooldownTime;
    float activeTime;
    public GameObject abilityTarget;
   
    public float castRange;
    public int damage;
    
    public KeyCode abilityKey;

    public void Start()
    {
        state = AbilityState.Ready;
    }
    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case AbilityState.Ready:
                if (Input.GetKeyDown(abilityKey))
                {
                    Debug.Log("Ability Activated");
                    ability.Activate(gameObject);
                    state = AbilityState.Casting;
                    //cast ability StartCoroutine(Cast());
                    activeTime = ability.activeTime;
                }
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
