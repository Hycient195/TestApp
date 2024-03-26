using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestApp.Mocking
{
    public interface IMessageBox
    {
        void Show(string s, string houseKeeperStatements, MessageBoxButtons ok);
    }

    public class MessageBox : IMessageBox
    {
        public void Show(string s, string housekeeperStatements, MessageBoxButtons ok)
        {
        }
    }
}
