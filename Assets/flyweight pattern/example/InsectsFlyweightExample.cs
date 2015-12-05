using UnityEngine;
using System.Collections.Generic;

using NG.Flyweight.Example;

public class InsectsFlyweightExample : MonoBehaviour
{
    
        
    void Start()
    {
        // Illustrate that factory reuses already made insects
        InsectFlyweightFactory insectFactory = new InsectFlyweightFactory();
        insectFactory.showMessages = true;

        Debug.LogError("Testing reuse of insects");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                insectFactory.GetInsectData( (InsectType)i );
            }
        }

        Debug.LogError("Testing the pattern in action");
        // An example of how this might work to our advantage.
        for (int i = 0; i < 3; i++)
        {
            Insect challenger = insectFactory.GetInsectData( (InsectType)i );
            Debug.Log("Insect to test: " + challenger.insectType.ToString());

            List<InsectType> defeatedInsect = new List<InsectType>();

            // At what point can challenger be stronger than other insects at varying health.
            for (int j = 0; j < challenger.maxHealth; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (k == i) // Don't attack insects of the same type.
                        continue;

                    InsectType insectType = (InsectType)k;

                    if (defeatedInsect.Contains(insectType))
                        continue;

                    Insect defender = insectFactory.GetInsectData(insectType);

                    for (int m = defender.maxHealth; m >= 0; m--)
                    {
                        int challengerStrength = challenger.GetStrength(j);
                        int defenderStrength = defender.GetStrength(m);

                        if (challengerStrength > defenderStrength)
                        {
                            defeatedInsect.Add(insectType);
                            Debug.LogWarning(challenger.insectType.ToString() + " at health: " + j.ToString() + " defeated " + defender.insectType.ToString() + " at full health of " + defender.maxHealth.ToString());
                            break;
                        }
                    }
                    
                }
            }

            // Check if anyone wasn't defeated.
            for (int h = 0; h < 3; h++)
            {
                if (h == i) // Insects of the same type won't be checked since we didn't even try to attack them.
                    continue;

                InsectType insectType = (InsectType)h;
                if (!defeatedInsect.Contains(insectType))
                    Debug.LogError(challenger.insectType.ToString() + " could not defeat " + insectType.ToString());
            }
        }
    }

    void Update()
    {

    }
}
