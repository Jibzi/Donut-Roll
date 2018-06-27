using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inter_GummyBear : Interactable
{
    
    
    public override void Interact(Donut interactor)
    {
        base.Interact(interactor);

        this.isCollectable = true;

        //Do effect
<<<<<<< HEAD:DonutGit/Assets/Scripts/George/Inter_GummyBear.cs
        interactor.Score += 10;

        //Play sound
        CheckTypeThenDoThings();

=======
        interactor.Score+= 10;
        
        //Play sound
        AMa.Play("Pickup");
        
>>>>>>> 9771e25a3c8360d0700e5cfbb84dd8df897f3f36:DonutGit/Assets/Scripts/George/Interact/Inter_GummyBear.cs
        //Do visuals
        
        
        //Destroy self
        Destroy(gameObject);
    }
}
