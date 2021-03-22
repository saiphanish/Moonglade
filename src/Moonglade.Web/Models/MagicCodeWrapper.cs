﻿namespace Moonglade.Web.Models
{
    // Used to wrap models so that Model Binders can recognize ModelPrefix_ModelProperty
    // This is a temp workaround
    public class MagicCodeWrapper<T> where T : class
    {
        public T ViewModel { get; set; }

        public MagicCodeWrapper()
        {
            
        }

        public MagicCodeWrapper(T model)
        {
            ViewModel = model;
        }
    }
}