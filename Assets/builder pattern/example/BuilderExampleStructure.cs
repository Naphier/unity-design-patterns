using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NG.builder_pattern.example
{
    // Our 'Director' class. Tells us how to construct the vehicles.
    class ShopForeman
    {
        public void Construct(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.BuildFrame();
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWheels();
            vehicleBuilder.BuildDoors();
        }
    }

    // Our 'abstract Builder' class
    // Definition of what methods will be used to actually build the vehicles.
    abstract class VehicleBuilder
    {
        protected Vehicle _vehicle;

        // Gets the vehicle instance
        public Vehicle vehicle { get { return _vehicle; } }

        // Abstract building methods
        public abstract void BuildFrame();
        public abstract void BuildEngine();
        public abstract void BuildWheels();
        public abstract void BuildDoors();

        // Unfortunately we can't enforce a constructor via an abstract class.
        // This is where an abstract factory pattern might come in handy for manufacturing the VehicleBuilder classes.
    }

    enum VehicleType { Scooter, Car, MotorCycle }
    // Our final product
    class Vehicle
    {
        public VehicleType vehicleType { get; private set; }
        public GameObject parent { get; private set; }
        private List<GameObject> _parts = new List<GameObject>();

        // Constructor method
        public Vehicle(VehicleType vehicleType)
        {
            this.vehicleType = vehicleType;
            parent = new GameObject(vehicleType.ToString());
        }

        public void AddPart(GameObject part, Vector3 localPosition)
        {
            part.transform.SetParent(parent.transform);
            part.transform.localPosition = localPosition;
            _parts.Add(part);
        }

        public string GetPartsList()
        {
            string partsList = vehicleType.ToString() + " parts:\n\t";
            foreach (GameObject part in _parts)
            {
                partsList += part.name + " ";
            }

            return partsList;
        }

    }

    // Provides a common function to make the parts.
    class Part
    {
        public static GameObject MakePart(PrimitiveType primitiveType, string name, Vector3 scale, Color color)
        {
            GameObject go = GameObject.CreatePrimitive(primitiveType);
            go.name = name;
            go.transform.localScale = scale;
            MeshRenderer meshRenderer = go.GetComponent<MeshRenderer>();
            if (meshRenderer != null)
                meshRenderer.material.color = color;

            return go;
        }
    }
}
