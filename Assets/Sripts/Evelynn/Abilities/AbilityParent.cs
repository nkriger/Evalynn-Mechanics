using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityParent : MonoBehaviour
{
    public static AbilityParent instance;
    public enum AbilityState
    {
        Ready,
        Casting,
        Cooldown
    }
    AbilityState state = AbilityState.Ready;

    public List<AbilitySO> ability;

    //public AbilityState State { get; private set; } = AbilityState.Ready;
    
    public int ManaCost;
    public float cooldownTime;
    public float activeTime;
    public GameObject abilityTarget;

    [Header ("Ability Cooldowns")]
    public float QCooldown;
    public Image qImage;
    public float WCooldown;
    public Image wImage;
    public float ECooldown;
    public Image eImage;
    public float RCooldown;
    public Image rImage;

    float qCD;
    float wCD;
    float eCD;
    float rCD;

    [Header("AbilityReady?")]
    public bool QReady;
    public bool WReady;
    public bool EReady;
    public bool RReady;


    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("2 scripts found");
            return;
        }
        instance = this;
    }

    public void Start()
    {
        state = AbilityState.Ready;
        CDSet();
        abilityFillAmoutSet();
    }

    // Update is called once per frame
    void Update()
    {       
        activateAbility();
        AbilityCD();
    }

    void activateAbility()
    {
        for (int i = 0; i < ability.Count; i++)
        {
            ability[i].Update();

            if (Input.GetKeyDown(ability[i].abilityKey))
            {
                if (state == AbilityState.Ready)
                {
                    ability[i].Activate();
                    //abilityStates(ability[i]);
                }
                else if(state == AbilityState.Cooldown)
                {
                    Debug.Log("Ability on Cooldown");
                }
            }
        }
    }
    
    void readyState()
    {
        Debug.Log("Ability Activated");
        //activeTime = ability.activeTime;
        state = AbilityState.Casting;
    }

    void CDSet()
    {
        qCD = QCooldown;
        wCD = WCooldown;
        eCD = ECooldown;
        rCD = RCooldown;
    }
    void abilityFillAmoutSet()
    {
        qImage.fillAmount = 0;
        wImage.fillAmount = 0;
        eImage.fillAmount = 0;
        rImage.fillAmount = 0;
    }

    void AbilityCD()
    {
        QAbilityCD();
        WAbilityCD();
        EAbilityCD();
        RAbilityCD();
    }

    void QAbilityCD()
    {
        if (QReady == false)
        {
            if (QCooldown > 0)
            {
                qImage.fillAmount -= 1 / qCD * Time.deltaTime;
                QCooldown -= Time.deltaTime;
            }
            else
            {
                qImage.fillAmount = 0;
                QReady = true;
                QCooldown = qCD;
            }
        }
        
    }
    void WAbilityCD()
    {
        if (WReady == false)
        {
            
            if (WCooldown > 0)
            {
                wImage.fillAmount -= 1 / qCD * Time.deltaTime;
                WCooldown -= Time.deltaTime;
            }
            else
            {
                wImage.fillAmount = 0;
                WCooldown = wCD;
                WReady = true;
            }
        }
        
    }
    void EAbilityCD()
    {
        if (EReady == false)
        {
            
            if (ECooldown > 0)
            {
                eImage.fillAmount -= 1 / qCD * Time.deltaTime;
                ECooldown -= Time.deltaTime;
            }
            else
            {
                eImage.fillAmount = 0;
                ECooldown = eCD;
                EReady = true;
            }
        }
        
    }
    void RAbilityCD()
    {
        if (RReady == false)
        {           
            if (RCooldown > 0)
            {        
                rImage.fillAmount -= 1 / qCD * Time.deltaTime;
                RCooldown -= Time.deltaTime;
            }
            else
            {
                rImage.fillAmount = 0;
                RCooldown = rCD;
                RReady = true;
            }
        }
      
    }





    void abilityStates(AbilitySO ability)
    {
        switch (state)
        {
            case AbilityState.Ready:
               
                readyState();
                //cast ability StartCoroutine(Cast());
                 
                
                break;
            case AbilityState.Casting:
                Debug.Log("Ability Casting");
                /*
                Debug.Log("Ability started Cast");
                if (activeTime > 0)
                {
                    Debug.Log("Ability Casting");
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    cooldownTime = ability.activeTime;
                    state = AbilityState.Cooldown;
                }
                */
                
                state = AbilityState.Cooldown;
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
