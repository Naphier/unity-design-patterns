using UnityEngine;
using System.Collections.Generic;

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
    interface VehicleBuilder
    {
        // Gets the vehicle instance
        Vehicle vehicle { get; }

        // Contract methods for building the components
        void BuildFrame();
        void BuildEngine();
        void BuildWheels();
        void BuildDoors();
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

        // Provides a common function to make the parts. Not truly a part of the standard
        // pattern, but included in this example to make part creation easier.
        public GameObject MakePart(PrimitiveType primitiveType, string name, Vector3 scale, Color color)
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
