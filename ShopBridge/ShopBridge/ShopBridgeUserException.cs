using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge
{
    public class ShopBridgeUserException:Exception
    {
        public ShopBridgeUserException(string msg):base(msg)
        {

        }
    }
}