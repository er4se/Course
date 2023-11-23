using System;

namespace DSL_MVP
{
    public class Presenter
    {
        Model model = null;
        View view = null;

        public Presenter(View view)
        {
            this.model = new Model();
            this.view = view;
            this.view.myEvent += new EventDelegate(View_myEvent);
        }

        void View_myEvent()
        {
            string variable = model.DB_Connect(this.view.LogicString);

            this.view.LogicString = variable;
        }
    }
}