using UnityEngine;
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

        // Make the products, the vehicles.
        shopForeman.Construct(carBuilder);
        shopForeman.Construct(motorCycleBuilder);
        shopForeman.Construct(scooterBuilder);

        // Get the vehicles and access their methods.
        Vehicle car = carBuilder.vehicle;
        Debug.Log(car.GetPartsList());
        
        Vehicle motorCycle = motorCycleBuilder.vehicle;
        Debug.Log(motorCycle.GetPartsList());

        Vehicle scooter = scooterBuilder.vehicle;
        Debug.Log(scooter.GetPartsList());


        // These calls don't have anything to do with the pattern.
        // They are simply here to make our visual display of the vehicles
        // in the Unity scene look nice.
        car.parent.transform.position = new Vector3(-6f, 0, 0);
        motorCycle.parent.transform.position = new Vector3(6f, 0, 0);
    }

    void Update()
    {

    }
}
