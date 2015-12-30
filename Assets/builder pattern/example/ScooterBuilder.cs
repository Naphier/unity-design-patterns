using UnityEngine;

namespace NG.builder_pattern.example
{
    class ScooterBuilder : VehicleBuilder
    {
        private Vehicle _vehicle;
        public Vehicle vehicle
        {
            get
            {
                return _vehicle;
            }
        }


        public ScooterBuilder()
        {
            _vehicle = new Vehicle(VehicleType.Scooter);
        }

        

        public void BuildDoors()
        {
            // We don't need no doors.
        }


        public void BuildEngine()
        {
            GameObject engine = _vehicle.MakePart(PrimitiveType.Cube, "engine", 0.5f * (new Vector3(.5f, 0.5f, 0.25f)), Color.gray);
            _vehicle.AddPart(engine, new Vector3(1.25f, 0.3f, 0));
        }


        public void BuildFrame()
        {
            GameObject frame = _vehicle.MakePart(PrimitiveType.Cube, "frame", 0.5f * new Vector3(2, 0.5f, 0.5f), Color.magenta);
            _vehicle.AddPart(frame, Vector3.zero);

            frame = _vehicle.MakePart(PrimitiveType.Cube, "frame2", 0.5f * new Vector3(0.25f, 2f, 0.5f), Color.magenta);
            _vehicle.AddPart(frame, new Vector3(1f, 0.75f, 0f));
        }


        public void BuildWheels()
        {
            Vector3 scale = 0.5f * new Vector3(0.75f, 0.1f, 0.75f);

            GameObject wheel = _vehicle.MakePart(PrimitiveType.Cylinder, "wheel", scale, Color.black);
            _vehicle.AddPart(wheel, new Vector3(1, -0.25f, 0));
            wheel.transform.Rotate(new Vector3(90f, 0, 0));

            wheel = _vehicle.MakePart(PrimitiveType.Cylinder, "wheel", scale, Color.black);
            _vehicle.AddPart(wheel, new Vector3(-1, -0.25f, 0));
            wheel.transform.Rotate(new Vector3(90f, 0, 0));
        }
    }
}
