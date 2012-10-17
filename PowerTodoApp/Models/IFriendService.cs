using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerTodoApp.Models
{
    public interface IFriendService
    {
        IEnumerable<Friend> All { get; }
    }
}
