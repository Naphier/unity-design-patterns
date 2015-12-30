using UnityEngine;
using System.Collections;
using Assets.flyweight_pattern.example2;

public class SoldierSceneController : MonoBehaviour
{
    // We can create as many soldiers as we want and the max
    // flyweight count will be 3. Thus reducing memory overhead
    // for handling large amounts of soldiers.
    public int numberOfSoldiersToCreate = 99;
    public Vector2 minPosition;
    public Vector2 maxPosition;

    void Start()
    {
        int weaponType = 0;
        for (int i = 0; i < numberOfSoldiersToCreate; i++)
        {
            //Make visual representations of the soldiers
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            SoldierGameObject soldierGameObject = go.AddComponent<SoldierGameObject>();
            soldierGameObject.Create((WeaponType)weaponType);
            go.name = ((WeaponType)weaponType).ToString();
            int startHealth = SoldierFlyweightFactory.Soldier((WeaponType)weaponType).Stats.MaxHealth;
            soldierGameObject.health = startHealth;

            float x = Random.Range(minPosition.x, maxPosition.x);
            float y = Random.Range(minPosition.y, maxPosition.y);

            go.transform.position = new Vector3(x, 0.45f * go.transform.localScale.y, y);

            go.GetComponent<MeshRenderer>().material.color = SoldierFlyweightFactory.Soldier((WeaponType)weaponType).GetColor(startHealth);

            weaponType = (weaponType + 1) % 3;
        }

        Debug.LogFormat("Created {0} soldiers. Flyweight count: {1}", numberOfSoldiersToCreate, SoldierFlyweightFactory.SoldierCount);
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 1000, 1000), "LMB=Damage unit -- RMB=Level up units");
    }
}
