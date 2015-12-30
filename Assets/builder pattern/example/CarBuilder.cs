using UnityEngine;

namespace NG.builder_pattern.example
{
    // Makes the parts and adds them to the vehicle at the correct local position.
    class CarBuilder : VehicleBuilder
    {
        private Vehicle _vehicle;
        public Vehicle vehicle
        {
            get
            {
                return _vehicle;
            }
        }

        public CarBuilder()
        {
            _vehicle = new Vehicle(VehicleType.Car);
        }


        public void BuildFrame()
        {
            GameObject frame = _vehicle.MakePart(PrimitiveType.Cube, "frame", new Vector3(2, 1, 1), Color.blue);

            _vehicle.AddPart(frame, Vector3.zero);
        }


        public void BuildDoors()
        {
            Vector3 doorScale = new Vector3(1, 1, 0.05f);

            GameObject leftDoor = _vehicle.MakePart(PrimitiveType.Cube, "left door", doorScale, Color.cyan);
            _vehicle.AddPart(leftDoor, new Vector3(0, 0, 0.5f));

            GameObject rightDoor = _vehicle.MakePart(PrimitiveType.Cube, "right door", doorScale, Color.cyan);
            _vehicle.AddPart(rightDoor, new Vector3(0, 0, -0.5f));
        }



        public void BuildEngine()
        {
            GameObject engine = _vehicle.MakePart(PrimitiveType.Cube, "engine", 0.5f * Vector3.one, Color.gray);
            _vehicle.AddPart(engine, new Vector3(1, -0.25f, 0));
        }

        

        public void BuildWheels()
        {
            Vector3 wheelScale = new Vector3(0.5f, 0.1f, 0.5f);

            GameObject wheel = _vehicle.MakePart(PrimitiveType.Cylinder, "wheel", wheelScale, Color.black);
            _vehicle.AddPart(wheel, new Vector3(0.75f, -0.5f, 0.5f));
            wheel.transform.Rotate(new Vector3(90, 0, 0));

            wheel = _vehicle.MakePart(PrimitiveType.Cylinder, "wheel", wheelScale, Color.black);
            _vehicle.AddPart(wheel, new Vector3(-0.75f, -0.5f, 0.5f));
            wheel.transform.Rotate(new Vector3(90, 0, 0));

            wheel = _vehicle.MakePart(PrimitiveType.Cylinder, "wheel", wheelScale, Color.black);
            _vehicle.AddPart(wheel, new Vector3(-0.75f, -0.5f, -0.5f));
            wheel.transform.Rotate(new Vector3(90, 0, 0));

            wheel = _vehicle.MakePart(PrimitiveType.Cylinder, "wheel", wheelScale, Color.black);
            _vehicle.AddPart(wheel, new Vector3(0.75f, -0.5f, -0.5f));
            wheel.transform.Rotate(new Vector3(90, 0, 0));

        }
    }
}
