using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public interface IMoveable
    {
    /// <summary>
    /// logic for moving the object
    /// </summary>
        void Move();
    /// <summary>
    /// listens for input from user, calls Move()
    /// </summary>
        void moveListener();

        float MoveSpeed
        {
            get;
            set;
        }
    }
