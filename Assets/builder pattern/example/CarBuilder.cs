using UnityEngine;

namespace NG.builder_pattern.example
{
    // Makes the parts and adds them to the vehicle at the correct local position.
    class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
        {
            _vehicle = new Vehicle(VehicleType.Car);
        }


        public override void BuildFrame()
        {
            GameObject frame = Part.MakePart(PrimitiveType.Cube, "frame", new Vector3(2, 1, 1), Color.blue);

            _vehicle.AddPart(frame, Vector3.zero);
        }


        public override void BuildDoors()
        {
            Vector3 doorScale = new Vector3(1, 1, 0.05f);

            GameObject leftDoor = Part.MakePart(PrimitiveType.Cube, "left door", doorScale, Color.cyan);
            _vehicle.AddPart(leftDoor, new Vector3(0, 0, 0.5f));

            GameObject rightDoor = Part.MakePart(PrimitiveType.Cube, "right door", doorScale, Color.cyan);
            _vehicle.AddPart(rightDoor, new Vector3(0, 0, -0.5f));
        }



        public override void BuildEngine()
        {
            GameObject engine = Part.MakePart(PrimitiveType.Cube, "engine", 0.5f * Vector3.one, Color.gray);
            _vehicle.AddPart(engine, new Vector3(1, -0.25f, 0));
        }

        

        public override void BuildWheels()
        {
            Vector3 wheelScale = new Vector3(0.5f, 0.1f, 0.5f);

            GameObject wheel = Part.MakePart(PrimitiveType.Cylinder, "wheel", wheelScale, Color.black);
            _vehicle.AddPart(wheel, new Vector3(0.75f, -0.5f, 0.5f));
            wheel.transform.Rotate(new Vector3(90, 0, 0));

            wheel = Part.MakePart(PrimitiveType.Cylinder, "wheel", wheelScale, Color.black);
            _vehicle.AddPart(wheel, new Vector3(-0.75f, -0.5f, 0.5f));
            wheel.transform.Rotate(new Vector3(90, 0, 0));

            wheel = Part.MakePart(PrimitiveType.Cylinder, "wheel", wheelScale, Color.black);
            _vehicle.AddPart(wheel, new Vector3(-0.75f, -0.5f, -0.5f));
            wheel.transform.Rotate(new Vector3(90, 0, 0));

            wheel = Part.MakePart(PrimitiveType.Cylinder, "wheel", wheelScale, Color.black);
            _vehicle.AddPart(wheel, new Vector3(0.75f, -0.5f, -0.5f));
            wheel.transform.Rotate(new Vector3(90, 0, 0));

        }
    }
}
