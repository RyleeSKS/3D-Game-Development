using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class OOP : MonoBehaviour
{

    private void Start()

    {

        BMW bmw;

        bmw = new BMW("BMW", 89);

        bmw.Drive();

    }



}





public abstract class Vehicle : MonoBehaviour
{

    private int speed;

    private string vehicleType;



    public Vehicle(string _vehicleType, int _speed)
    {

        speed = _speed;

        vehicleType = _vehicleType;

    }



    public virtual void Drive()

    {

        Debug.Log(vehicleType + " is driving at " + speed + "KM/H");



    }



    public int GetSpeed() { return speed; }



}



public class BMW : Vehicle

{

    public BMW(string _vehicleType, int _speed) : base(_vehicleType, _speed)

    {

        _vehicleType = "BMW";

        _speed = 100;

    }



    public override void Drive()
    {

        base.Drive();

        Debug.Log("Fancyyyy");

    }

}

//public abstract class Animal

//{

//    private string name;

//    private int age;

//    public Animal(string _name, int _age) {

//        name = _name;

//        age = _age;

//    }



//    // Abstract must be overriden

//    public abstract void Eat();

//    public abstract void Eat(string food);



//    // Virtual Method can, but doesnt need to, have method overriden

//    public virtual void PrintAnimal()

//    {

//        Debug.Log("Name: " + name);

//        Debug.Log("Age: " + age);

//    }

//}



//public class Fish : Animal

//{

//    public Fish(string _name, int _age): base(_name, _age)

//    {



//    }



//    public override void Eat()

//    {

//        Debug.Log("Fish is eating");

//    }



//    public override void Eat(string food)

//    {

//        Debug.Log("Fish has eaten " + food);

//    }



//    public override void PrintAnimal()

//    {

//            base.PrintAnimal();

//            Debug.Log("This is a fish");



//    }

//}