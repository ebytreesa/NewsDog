using NewsDog.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Newsdog.Model
{
    public class UserInformation:ObservableBase
    {
        private string displayName;
        public string DisplayName
        {
            get { return this.displayName; }
            set { this.SetProperty(ref this.displayName, value); }
        }

        private string bioContent;
        public string BioContent
        {
            get { return this.bioContent; }
            set { this.SetProperty(ref this.bioContent, value); }
        }

        private string profileImageUrl;
        public string ProfileImageUrl
        {
            get { return this.profileImageUrl; }
            set { this.SetProperty(ref this.profileImageUrl, value); }
        }
    }
}
