using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace library_system
{
    interface IUserInterfaceElement
    {
       // void Display();
       // void Update();
    //}
    //Interface Segregation Principle - Magazine and Book used the Display method, but not the Update method. 
        //Putting them in seperate constructors means neither Books or Magazine are forced to implement them 

    //interface IDisplay
   //     void Display();
    //}

    //interface IUpdate

    //{
      // void Update();
   }
   //Removed Update Method into it's own class to allow following of the Interface Segregation Principle for both this class and the new IUpdate class.
}
