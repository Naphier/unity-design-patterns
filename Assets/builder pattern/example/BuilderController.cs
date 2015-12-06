using UnityEngine;
using System.Collections;
using NG.builder_pattern.example;

public class BuilderController : MonoBehaviour
{
    void Start()
    {
        // Instantiate the director and builders
        ShopForeman shopForeman = new ShopForeman();
        CarBuilder carBuilder = new CarBuilder();
        MotorCycleBuilder motorCycleBuilder = new MotorCycleBuilder();
        ScooterBuilder scooterBuilder = new ScooterBuilder();

        // Make the products
        shopForeman.Construct(carBuilder);
        shopForeman.Construct(motorCycleBuilder);
        shopForeman.Construct(scooterBuilder);

        // Get the vehicles and do stuff with them
        Vehicle car = carBuilder.vehicle;
        car.parent.transform.position = new Vector3(-6f, 0, 0);
        Debug.Log(car.GetPartsList());
        
        Vehicle motorCycle = motorCycleBuilder.vehicle;
        motorCycle.parent.transform.position = new Vector3(6f, 0, 0);
        Debug.Log(motorCycle.GetPartsList());

        
        Vehicle scooter = scooterBuilder.vehicle;
        scooter.parent.transform.localScale *= 0.5f;
        Debug.Log(scooter.GetPartsList());
        
    }

    void Update()
    {

    }
}
