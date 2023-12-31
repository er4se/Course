﻿using System;

namespace DSL_MVP
{
    public delegate void EventDelegate();

    public class View
    {
        public event EventDelegate myEvent = null;

        public string LogicString = "Логика View";

        public View()
        {
            new Presenter(this);
            View_Event();
        }

        private void View_Event()
        {
            myEvent.Invoke();
        }
    }
}