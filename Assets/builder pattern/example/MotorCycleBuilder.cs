using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NG.builder_pattern.example
{
    class MotorCycleBuilder : VehicleBuilder
    {
        public MotorCycleBuilder()
        {
            _vehicle = new Vehicle(VehicleType.MotorCycle);
        }


        public override void BuildDoors()
        {   
            // We don't need no doors.
        }


        public override void BuildEngine()
        {
            GameObject engine = Part.MakePart(PrimitiveType.Cube, "engine", new Vector3(0.75f, 0.5f, 0.75f), Color.gray);
            _vehicle.AddPart(engine, new Vector3(0, -0.25f, 0));
        }


        public override void BuildFrame()
        {
            GameObject frame = Part.MakePart(PrimitiveType.Cube, "frame", new Vector3(2, 0.5f, 0.5f), Color.red);
            _vehicle.AddPart(frame, Vector3.zero);
        }


        public override void BuildWheels()
        {
            Vector3 scale = new Vector3(0.75f, 0.1f, 0.75f);

            GameObject wheel = Part.MakePart(PrimitiveType.Cylinder, "wheel", scale, Color.black);
            _vehicle.AddPart(wheel, new Vector3(1, -0.25f, 0));
            wheel.transform.Rotate(new Vector3(90f, 0, 0));

            wheel = Part.MakePart(PrimitiveType.Cylinder, "wheel", scale, Color.black);
            _vehicle.AddPart(wheel, new Vector3(-1, -0.25f, 0));
            wheel.transform.Rotate(new Vector3(90f, 0, 0));
        }
    }
}
