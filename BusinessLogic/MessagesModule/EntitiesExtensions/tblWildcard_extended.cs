﻿using Business_Logic.MessagesModule.DataObjects;
using Business_Logic.MessagesModule.EntitiesExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic.MessagesModule {
    public partial class tblWildcard : IMessagesModuleEntity, IWildcard {

        public IEnumerable<KeyValuePair<string, string>> ToKeyValues() {
            return new[] { new KeyValuePair<string, string>(Code, Key) };
        }
    }
}