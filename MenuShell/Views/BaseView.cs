using System;

namespace MenuShell.Views
{
    public abstract class BaseView
    {
        protected BaseView(string title)
        {
            Title = title;

            Console.Title = Title;
        }

        private string Title { get; }

        public abstract void Display();
    }
}