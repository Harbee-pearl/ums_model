using System;

namespace ums_model
{
    /// <summary>
    /// This is the queue class to hold the users
    /// </summary>

    public  class UserQueueClass<T>
    {
        public UserNode<T> Head { get; set; }
        public UserNode<T> Tail { get; set; }
        public int Count { get; set; }

        /// <summary>
        /// This methods add a user to the queue
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="email"></param>
        /// <param name="favFood"></param>
        /// <returns> the new user</returns>
        public UserNode<T> Enqueue( T fName, T lName, T email, T favFood)
        {
            UserNode<T> node = new UserNode<T>(fName, lName, email, favFood);

            if (this.Head == null)
            {
                Head = Tail = node;
                this.Count++;
                return node;
            }

            this.Tail.Next = node;
            this.Tail = Tail.Next;
            this.Count++;
            return node;

        }

        /// <summary>
        /// This methods removes the first user on the queue
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="email"></param>
        /// <param name="favFood"></param>
        /// <returns> the first name of the removed user</returns>

        public T Dequeue()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T removedUser = this.Head.FirstName;
            this.Head = this.Head.Next;
            this.Count--;
            return removedUser;
        }

        /// <summary>
        /// This methods prints the users in the queue
        /// </summary>

        public void SeeUserList()
        {
            var holder = this.Head;
            while (holder != null)
            {
                System.Console.WriteLine("First Name: " + holder.FirstName);
                System.Console.WriteLine("Last Name: " + holder.LastName);
                System.Console.WriteLine("Email: " + holder.Email);
                System.Console.WriteLine("Favourite food: " + holder.FavFood);
                System.Console.WriteLine("----------------------------");
                holder = holder.Next;
            }
        }
    }
}
