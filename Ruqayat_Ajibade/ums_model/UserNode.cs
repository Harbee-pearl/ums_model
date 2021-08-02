namespace ums_model
{
    /// <summary>
    /// This models the user
    /// </summary>
    public  class UserNode<T>
    {
        /// <summary>
        /// This is the consructor for each user
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="email"></param>
        /// <param name="favFood"></param>
        public UserNode( T fName, T lName, T email, T favFood)
        {
            // this.Value = value;
            this.FirstName = fName;
            this.LastName = lName;
            this.Email = email;
            this.FavFood = favFood;
        }


        // public T Value { get; set; }
        public T FirstName { get; set; }
        public T LastName { get; set; }
        public T Email { get; set; }
        public T FavFood { get; set; }

        public UserNode<T> Next { get; set; }
    }


}