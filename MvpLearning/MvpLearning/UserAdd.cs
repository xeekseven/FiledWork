using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvpLearning.Interface;

namespace MvpLearning
{
    public class UserAdd : UiInterface
    {
        public event EventHandler UserAddEvent;
        public string UserName
        {
            set {}
        }
    }
}
