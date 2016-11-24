using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvpLearning.Interface
{
    public interface UiInterface
    {
        event EventHandler UserAddEvent;
        string UserName { get; set; }
        string UserAge { get; set; }
    }
}
