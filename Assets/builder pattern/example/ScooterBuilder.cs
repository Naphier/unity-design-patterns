using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NG.builder_pattern.example
{
    class ScooterBuilder : VehicleBuilder
    {
        public ScooterBuilder()
        {
            _vehicle = new Vehicle(VehicleType.Scooter);
        }

        public override void BuildDoors()
        {
            // We don't need no doors.
        }


        public override void BuildEngine()
        {
            GameObject engine = Part.MakePart(PrimitiveType.Cube, "engine", new Vector3(.5f, 0.5f, 0.25f), Color.gray);
            _vehicle.AddPart(engine, new Vector3(1.25f, 0.3f, 0));
        }


        public override void BuildFrame()
        {
            GameObject frame = Part.MakePart(PrimitiveType.Cube, "frame", new Vector3(2, 0.5f, 0.5f), Color.magenta);
            _vehicle.AddPart(frame, Vector3.zero);

            frame = Part.MakePart(PrimitiveType.Cube, "frame2", new Vector3(0.25f, 2f, 0.5f), Color.magenta);
            _vehicle.AddPart(frame, new Vector3(1f, 0.75f, 0f));
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
