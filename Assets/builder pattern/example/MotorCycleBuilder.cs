using UnityEngine;

namespace NG.builder_pattern.example
{
    class MotorCycleBuilder : VehicleBuilder
    {
        private Vehicle _vehicle;
        public Vehicle vehicle
        {
            get
            {
                return _vehicle;
            }
        }


        public MotorCycleBuilder()
        {
            _vehicle = new Vehicle(VehicleType.MotorCycle);
        }

        

        public void BuildDoors()
        {   
            // We don't need no doors.
        }


        public void BuildEngine()
        {
            GameObject engine = _vehicle.MakePart(PrimitiveType.Cube, "engine", new Vector3(0.75f, 0.5f, 0.75f), Color.gray);
            _vehicle.AddPart(engine, new Vector3(0, -0.25f, 0));
        }


        public void BuildFrame()
        {
            GameObject frame = _vehicle.MakePart(PrimitiveType.Cube, "frame", new Vector3(2, 0.5f, 0.5f), Color.red);
            _vehicle.AddPart(frame, Vector3.zero);
        }


        public void BuildWheels()
        {
            Vector3 scale = new Vector3(0.75f, 0.1f, 0.75f);

            GameObject wheel = _vehicle.MakePart(PrimitiveType.Cylinder, "wheel", scale, Color.black);
            _vehicle.AddPart(wheel, new Vector3(1, -0.25f, 0));
            wheel.transform.Rotate(new Vector3(90f, 0, 0));

            wheel = _vehicle.MakePart(PrimitiveType.Cylinder, "wheel", scale, Color.black);
            _vehicle.AddPart(wheel, new Vector3(-1, -0.25f, 0));
            wheel.transform.Rotate(new Vector3(90f, 0, 0));
        }
    }
}
