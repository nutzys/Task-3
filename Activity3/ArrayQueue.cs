using System;

namespace CSharp.Activity.Datastore
{
    /// <summary>
    /// Summary description for ArrayQueue.
    /// </summary>
    public class ArrayQueue<T> : ArrayBase<T>
    {
        // The following instance variables are accessible to all methods inside this class. You are not allowed to declare additional class members.

        // The indices of the first and last objects in the queue:
        private int first;
        private int last;


        // HINT: In addition to the above variables,
        // the indexer this[] (represents the queue)
        // and the Count (represents the number of objects inside the queue)
        // can be used also in this class because of inheritance.

        // HINT: Also the methods IsFull() and Contains() from ArrayBase<T>
        // can be used in this class because of inheritance.


        /// <summary>
        ///     Default constructor. Calls the base constructor.
        /// </summary>
        public ArrayQueue()
        {
            //No Logic
        }


        /// <summary>
        ///     Constructor to initialize the data structure to the specified size.
        ///     Call the overloaded base class constructor and pass the size of the array.
        /// </summary>
        /// <param name="size">The maximum length of the array.</param>
        public ArrayQueue(int size) : base(size)
        {
            //No logic
        }


        /// <summary>
        ///     Method to accept an object and add to the end of the queue.
        /// </summary>
        /// <param name="next">object to enqueue</param>
        /// <returns></returns>
        public virtual bool Enqueue(T next) 
        {
            //TODO Activity 3.0
            //This method adds the object 'next' to the end of the queue assuming that the queue is not full 
            //and that a similar object is not already it he queue.  Return true if the queue is successful, and
            //false otherwise.
            //If 'next' is a null object, throw an ArgumentNullException with a descriptive message.

            //start solution
            if(next == null)
            {
                throw new ArgumentNullException("next is null");
                
            }
            if(IsFull() || Contains(next))
            {
                return false;
            }

            this[last] = next;
            last = (last + 1) % Capacity;
            Count++;

            return true;

        }


        /// <summary>
        ///     Method to remove the object from the queue.
        /// </summary>
        /// <returns></returns>
        public virtual T Dequeue() 
        {
            //TODO Activity 3.1
            //This removes the next object from the start of queue and returns it. If there is nothing to return
            //then throw InvalidOperationException() exception.

            //start solution
            if (!IsEmpty())
            {
                T removed = this[first];
                this[first] = default;

                first = (first + 1) % Capacity;
                Count--;
                return removed;
            }
            else
            {
                throw new InvalidOperationException("Nothing to remove");
            }
            
        }


        /// <summary>
        ///     Method to check an object at the beginning of the queue.
        /// </summary>
        /// <returns></returns>
        public T CheckNext()
            => base[first];

        /// <summary>
        ///     Method to check whether there is any other object in the queue.
        /// </summary>
        /// <returns></returns>
        public bool HasNext()
            => (base.Count != 0);


        /// <summary>
        ///     Method to accept an object and find whether the object exists in the array structure.
        /// </summary>
        /// <param name="arg">object</param>
        /// <returns></returns>
        public override int IndexOf(T arg) 
        {
            //TODO Activity 3.2
            //Compares 'arg' using the Equals() method and returns its place relative to the start of the queue.
            //If there is no object in the queue that qualifies, then return NOT_IN_STRUCTURE.
            //Trying to find a null object should throw an ArgumentNullException.

            //start solution
            if(arg != null)
            {
                for(int i = 0; i < this.Count; i++)
                {
                    if (this[first + i].Equals(arg))
                    {
                        return i;
                    }
                }
            }
            else
            {
                throw new ArgumentNullException("arg is null");
            }
            return NOT_IN_STRUCTURE;
        }


        /// <summary>
        ///     Method to accept the index of for and array object and return the corresponding object.
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>the object for the specified index</returns>
  
        public T Check(int index) 
        {
            //TODO Activity 3.3
            //Find which object is currently at the specified index relative to the start of the queue.
            //The start of the queue is index 0

            //start solution

            if(index < 0 || index == null)
            {
                throw new IndexOutOfRangeException("Invalid index");
                
            }
            return this[index];
        }
    }
}