using System;
using System.Reflection;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lisa.Excelsis.Mobile
{
    public class CommandBehavior : Behavior<View>
    {
        public static readonly BindableProperty EventNameProperty =
            BindableProperty.Create("EventName", typeof(string), typeof(CommandBehavior), null);
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(CommandBehavior), null);
        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create("CommandParameter", typeof(object), typeof(CommandBehavior), null);

        public string EventName
        {
            get { return (string)GetValue(EventNameProperty); }
            set { SetValue(EventNameProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return (ICommand)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        protected override void OnAttachedTo(View bindable)
        {
            bindable.BindingContextChanged += (sender, e) => { this.BindingContext = bindable.BindingContext; };

            var eventInfo = bindable.GetType().GetTypeInfo().GetDeclaredEvent(EventName);
            if (eventInfo == null)
            {
                throw new ArgumentException(string.Format("CommandBehavior: Can't register the '{0}' event.", EventName));
            }
            MethodInfo eventHandlerInfo = this.GetType().GetTypeInfo().GetDeclaredMethod("ExecuteCommand");
            var eventHandler = eventHandlerInfo.CreateDelegate(eventInfo.EventHandlerType, this);
            eventInfo.AddEventHandler(bindable, eventHandler);
        }

        private void ExecuteCommand(object sender, EventArgs e)
        {
            if (Command == null)
                return;

            if (Command.CanExecute(CommandParameter))
            {
                Command.Execute(CommandParameter);
            }
        }
    }
}