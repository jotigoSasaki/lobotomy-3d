using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace EntityComponents
{


    public abstract class EntityComponent
    {

    }


    public class IntelectComponent : EntityComponent {
        
    }
    public class PsycheComponent : EntityComponent
    {
        //Sanity Point
        public float SP;
    }
    public class PhysiqueComponent : EntityComponent
    {
        // Health Points
        public float HP;
    }
    public class MotoricsComponent : EntityComponent
    {

    }
    public class EquipmentComponent : EntityComponent
    {
    }
    public class EnvironmentComponent : EntityComponent
    {

    }
}