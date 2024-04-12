﻿namespace Entities.Exceptions
{
    public sealed class BookNotFound : NotFound
    {
        public BookNotFound(int id) : base($"The book with id : {id} is not found.")
        {

        }
    }

}
