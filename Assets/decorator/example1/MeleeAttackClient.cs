using UnityEngine;
using System.Collections;
using Assets.decorator.example1;

public class MeleeAttackClient : MonoBehaviour
{
    public ParticleSystem kiParticles;
    MeleeAttack baseMeleeAttack;
    HardPunch hardPunch;
    KiPunch kiPunch;
    MeleeAttack superKiPunch;
        
    void Start()
    {
        baseMeleeAttack = new BaseMelee();

        hardPunch = new HardPunch();
        hardPunch.SetMeleeAttack(baseMeleeAttack);

        kiPunch = new KiPunch(kiParticles);
        kiPunch.SetMeleeAttack(baseMeleeAttack);

        HardPunch hpDeco = new HardPunch();
        hpDeco.SetMeleeAttack(baseMeleeAttack);
        superKiPunch = hpDeco;
        KiPunch kpDeco = new KiPunch(kiParticles);
        kpDeco.SetMeleeAttack(superKiPunch);
        superKiPunch = kpDeco;

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            Debug.Log("Base attack value: " + baseMeleeAttack.Attack());

        if (Input.GetKeyDown(KeyCode.W))
            Debug.Log("Hard punch value: " + hardPunch.Attack());

        if (Input.GetKeyDown(KeyCode.E))
            Debug.Log("Ki Punch value: " + kiPunch.Attack());

        if (Input.GetKeyDown(KeyCode.R))
            Debug.Log("Super Ki Punch value: " + superKiPunch.Attack());
    }

    void OnGUI()
    {
        string label = "Left click to attack\nSpacebar to decorate attack with hard punch\nLeft Shift to decorate with Ki Attack";

        GUI.Label(new Rect(0, 0, 500, 500), label);
    }
}
