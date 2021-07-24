using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameObject 
{
   public void Death();
   public void Damage(int dmg);
}
